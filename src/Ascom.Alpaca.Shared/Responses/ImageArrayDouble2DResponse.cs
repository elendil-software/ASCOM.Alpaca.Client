namespace ES.Ascom.Alpaca.Responses
{
    /// <summary>
    /// 2 dimension image array response
    /// </summary>
    public class ImageArrayDouble2DResponse : CommandResponse, IImageResponse<double[,]>
    {
        private ImageArrayDouble2DResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageArrayDouble2DResponse" /> class with the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value to set in the object</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public ImageArrayDouble2DResponse(double[,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new double[0,0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageArrayDouble2DResponse" /> class with the specified <paramref name="errorNumber"/> and <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorNumber">An error code in the <see cref="ES.Ascom.Alpaca.Exceptions.ErrorCodes"/> code range</param>
        /// <param name="errorMessage">The message that describes the error</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public ImageArrayDouble2DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 2D image array of double values
        /// </summary>
        public double[,] Value { get; set; }

        /// <summary>
        /// Image array type
        /// For this object it will always be <see cref="ImageArrayType.Double"/> 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Double;

        /// <summary>
        /// The array's rank
        /// For this object it will always be <see cref="ImageArrayRank.SinglePlane"/> 
        /// </summary>
        public ImageArrayRank Rank { get; } = ImageArrayRank.SinglePlane;
    }
}