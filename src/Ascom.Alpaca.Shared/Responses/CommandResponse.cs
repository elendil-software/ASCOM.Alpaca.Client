﻿
using System;
using ES.Ascom.Alpaca.Exceptions;

namespace ES.Ascom.Alpaca.Responses
{
    /// <summary>
    /// Defines the base of an Alpaca response.
    /// This type can be use for request that does not return any value
    /// </summary>
    public class CommandResponse : IResponse
    {
        private CommandResponse()
        {
            ErrorMessage = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse" /> class
        /// </summary>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public CommandResponse(uint clientTransactionId = 0, uint serverTransactionId = 0)
        {
            ErrorMessage = "";
            ClientTransactionID = clientTransactionId;
            ServerTransactionID = serverTransactionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse" /> class with the specified <paramref name="errorNumber"/> and <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorNumber">An error code in the <see cref="ES.AscomAlpaca.Exceptions.ErrorCodes"/> code range</param>
        /// <param name="errorMessage">The message that describes the error</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public CommandResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0)
        {
            if (errorNumber == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(errorNumber), "Must be different from zero");
            }
            
            ErrorNumber = errorNumber;
            ErrorMessage = errorMessage ?? "";
            ClientTransactionID = clientTransactionId;
            ServerTransactionID = serverTransactionId;
        }

        /// <summary>
        /// Client's transaction ID (0 to 4294967295), as supplied by the client in the command request.
        /// </summary>
        public uint ClientTransactionID { get; private set; }

        /// <summary>
        /// Server's transaction ID (0 to 4294967295), should be unique for each client transaction so that log messages on the client can be associated with logs on the device.
        /// </summary>
        public uint ServerTransactionID { get; private set; }

        /// <summary>
        /// Zero for a successful transaction, or a non-zero integer(-2147483648 to 2147483647) if the device encountered an issue.Devices must use ASCOM reserved error
        /// numbers whenever appropriate so that clients can take informed actions. E.g.returning 0x401 (1025) to indicate that an invalid value was received.
        /// </summary>
        /// <seealso cref="ErrorCodes"/>
        public int ErrorNumber { get; private set; }

        /// <summary>
        /// Empty string for a successful transaction, or a message describing the issue that was encountered. If an error message is returned,
        /// a non zero <see cref="ErrorNumber"/> must also be returned.
        /// </summary>
        public string ErrorMessage { get; private set; }
    }
}