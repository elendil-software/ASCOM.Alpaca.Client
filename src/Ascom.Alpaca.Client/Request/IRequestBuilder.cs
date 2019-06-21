using System;
using System.Collections.Generic;
using RestSharp;

namespace ES.Ascom.Alpaca.Client.Request
{
    /// <summary>
    /// A request builder can be use to prepare a <see cref="IRestRequest"/>
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Create a <see cref="IRestRequest"/> with the given parameters
        /// </summary>
        /// <param name="command">An ASCOM Alpaca command</param>
        /// <param name="httpMethod">HTTP method to use to send the request</param>
        /// <param name="clientTransactionId">The Client Transaction ID</param>
        /// <returns>The initialised <see cref="IRestRequest"/></returns>
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, int clientTransactionId = -1);

        /// <summary>
        /// Create a <see cref="IRestRequest"/> with the given parameters
        /// </summary>
        /// <param name="command">An ASCOM Alpaca command</param>
        /// <param name="httpMethod">HTTP method to use to send the request</param>
        /// <param name="parameters">Request parameters</param>
        /// <param name="clientTransactionId">The Client Transaction ID</param>
        /// <returns>The initialised <see cref="IRestRequest"/></returns>
        IRestRequest BuildRestRequest(Enum command, Method httpMethod, Dictionary<string, object> parameters, int clientTransactionId = -1);
    }
}