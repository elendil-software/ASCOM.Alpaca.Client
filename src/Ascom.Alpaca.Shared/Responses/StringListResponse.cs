﻿using System.Collections.Generic;

namespace ES.Ascom.Alpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of strings
    /// </summary>
    public class StringListResponse : CommandResponse, IValueResponse<IList<string>>
    {
        private StringListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringListResponse" /> class with the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value to set in the object</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public StringListResponse(IList<string> value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringListResponse" /> class with the specified <paramref name="errorNumber"/> and <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorNumber">An error code in the <see cref="ES.AscomAlpaca.Exceptions.ErrorCodes"/> code range</param>
        /// <param name="errorMessage">The message that describes the error</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public StringListResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// String collection returned by the device
        /// </summary>
        public IList<string> Value  { get; private set; }
    }
}