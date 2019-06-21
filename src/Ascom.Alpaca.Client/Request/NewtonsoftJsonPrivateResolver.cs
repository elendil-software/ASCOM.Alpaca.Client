using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ES.AscomAlpaca.Client.Request
{
    internal class NewtonsoftJsonPrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member , MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
 
            if (!jsonProperty.Writable)
            {
                var propertyInfo = member as PropertyInfo;
                if (propertyInfo != null)
                {
                    var hasPrivateSetter = propertyInfo.GetSetMethod(true) != null;
                    jsonProperty.Writable = hasPrivateSetter;
                }
            }
 
            return jsonProperty;
        }
    }
}