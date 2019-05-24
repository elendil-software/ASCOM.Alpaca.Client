using System;
using System.Collections.Generic;
using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    public interface IRequestBuilder
    {
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, int clientTransactionId = -1);
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, Dictionary<string, object> parameters, int clientTransactionId = -1);
    }
}