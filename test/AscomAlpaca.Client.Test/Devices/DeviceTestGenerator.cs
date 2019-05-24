using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Devices
{
    public class DeviceTestGenerator
    {
        public static void BuildTests(Type deviceType)
        {
            string typeName = deviceType.Name;
            string implementationName = typeName.Substring(1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System.Threading.Tasks;")
                .AppendLine("using ASCOM.Alpaca.Client.Configuration;")
                .AppendLine("using ASCOM.Alpaca.Client.Devices;")
                .AppendLine("using ASCOM.Alpaca.Client.Request;")
                .AppendLine("using ASCOM.Alpaca.Client.Transactions;")
                .AppendLine("using ASCOM.Alpaca.Devices;")
                .AppendLine("using ASCOM.Alpaca.Responses;")
                .AppendLine("using Moq;")
                .AppendLine("using RestSharp;")
                .AppendLine("using Xunit;")
                .AppendLine("")
                .AppendLine("namespace ASCOM.Alpaca.Client.Test.Devices")
                .AppendLine("{")
                .AppendLine($"    public class {implementationName}RequestTest : DeviceRequestsTestBase")
                .AppendLine("    {")
                .AppendLine($"        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration {{ DeviceNumber = 5, DeviceType = DeviceType.{implementationName} }};")
                .AppendLine("        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();")
                .AppendLine("        ");
            
            foreach (MethodInfo method in deviceType.GetMethods())
            {
                string responseType = "<Response>";
                string responseObject = "new Response()";
                bool isAsync = false;
                Type returnType = method.ReturnType;

                if (typeof(Task).IsAssignableFrom(returnType))
                {
                    isAsync = true;
                    if (returnType.GenericTypeArguments.Length > 0)
                    {
                        returnType = returnType.GenericTypeArguments[0];
                    }
                }

                if (typeof(System.Collections.ICollection).IsAssignableFrom(returnType) && returnType.Name != "Array")
                {
                    Type genericType = returnType.GenericTypeArguments[0];
                    
                    switch (Type.GetTypeCode(genericType))
                    {
                        case TypeCode.Int32:
                            responseType = "<IntArrayResponse>";
                            responseObject = "new IntArrayResponse()";
                            break;

                        case TypeCode.Double:
                            responseType = "<DoubleArrayResponse>";
                            responseObject = "new DoubleArrayResponse()";
                            break;

                        case TypeCode.Boolean:
                            responseType = "<BoolArrayResponse>";
                            responseObject = "new BoolArrayResponse()";
                            break;

                        case TypeCode.String:
                            responseType = "<StringArrayResponse>";
                            responseObject = "new StringArrayResponse()";
                            break;
                    }
                }
                else
                {
                    switch (Type.GetTypeCode(returnType))
                    {
                        case TypeCode.Int32:
                            responseType = "<IntResponse>";
                            responseObject = "new IntResponse()";
                            break;

                        case TypeCode.Double:
                            responseType = "<DoubleResponse>";
                            responseObject = "new DoubleResponse()";
                            break;

                        case TypeCode.Boolean:
                            responseType = "<BoolResponse>";
                            responseObject = "new BoolResponse()";
                            break;

                        case TypeCode.String:
                            responseType = "<StringResponse>";
                            responseObject = "new StringResponse()";
                            break;
                    }
                }

                if (isAsync)
                {
                    responseObject = $"Task.FromResult({responseObject})";
                }

                StringBuilder parametersArrange = new StringBuilder();
                StringBuilder parametersAct = new StringBuilder();
                StringBuilder parametersAssert = new StringBuilder();

                foreach (var parameter in method.GetParameters())
                {
                    parametersArrange.AppendLine($"            string {parameter.Name}ParameterName = \"{char.ToUpper(parameter.Name[0]) + parameter.Name.Substring(1)}--\"; //TODO to check");
                    
                    switch (Type.GetTypeCode(parameter.ParameterType))
                    {
                        case TypeCode.Int32:
                            parametersArrange.AppendLine($"            int {parameter.Name}ParameterValue = 2;");
                            break;

                        case TypeCode.Double:
                            parametersArrange.AppendLine($"            double {parameter.Name}ParameterValue = 2;");
                            break;

                        case TypeCode.Boolean:
                            parametersArrange.AppendLine($"            bool {parameter.Name}ParameterValue = true;");
                            break;

                        case TypeCode.String:
                            parametersArrange.AppendLine($"            string {parameter.Name}ParameterValue = \"{parameter.Name}ParameterValue\";");
                            break;
                    }

                    parametersAct.Append($"{parameter.Name}ParameterValue, ");
                    parametersAssert.AppendLine($"            AssertParameter(sentRequest.Parameters, {parameter.Name}ParameterName, {parameter.Name}ParameterValue);");
                }
                
                var implementationInstanceName = char.ToLower(implementationName[0]) + implementationName.Substring(1);

                List<string> getMethodPrefixes = new List<string> { "Get", "Is", "Can", "Has"};
                string httpMethod = getMethodPrefixes.Any(o => method.Name.StartsWith(o)) ? "GET" : "PUT";
                
                sb.AppendLine("        [Fact]")
                    .AppendLine($"        public {(isAsync ? "async Task" :"void")} {method.Name}_SendValidRequest()")
                    .AppendLine("        {")
                    .AppendLine("            //Arrange")
                    .AppendLine("            string commandName = \"\";")
                    .Append(parametersArrange)
                    .AppendLine("            RestRequest sentRequest = null;")
                    .AppendLine("            var commandSenderMock = new Mock<ICommandSender>();")
                    .AppendLine("            commandSenderMock")
                    .AppendLine($"                .Setup(x => x.ExecuteRequest{(isAsync ? "Async" :"")}{responseType}(It.IsAny<string>(), It.IsAny<RestRequest>()))")
                    .AppendLine("                .Callback((string baseUrl, RestRequest request) => sentRequest = request)")
                    .AppendLine($"                .Returns({responseObject});")
                    .AppendLine($"            var {implementationInstanceName} = new {typeName.Substring(1)}(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);")
                    .AppendLine("            ")
                    .AppendLine("            //Act")
                    .AppendLine($"            {(isAsync ? "await " :"")}{implementationInstanceName}.{method.Name}({parametersAct.ToString().Trim(' ', ',')});")
                    .AppendLine("            ")
                    .AppendLine("            //Assert")
                    .AppendLine($"            Assert.Equal(Method.{httpMethod}, sentRequest.Method);")
                    .AppendLine("            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);")
                    .Append(parametersAssert)
                    .AppendLine("        }")
                    .AppendLine("        ");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");
                    
            Debug.WriteLine(sb.ToString());
        }
    }
}