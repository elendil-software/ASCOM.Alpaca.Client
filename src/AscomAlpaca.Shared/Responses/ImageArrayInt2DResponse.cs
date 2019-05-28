namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 2 dimension image array response
    /// </summary>
    public class ImageArrayInt2DResponse : CommandResponse, IImageResponse<int[,]>
    {
        private ImageArrayInt2DResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageArrayInt2DResponse" /> class with the specified <paramref name="value"/>
        /// </summary>
        /// <param name="value">The value to set in the object</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public ImageArrayInt2DResponse(int[,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new int[0,0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageArrayInt2DResponse" /> class with the specified <paramref name="errorNumber"/> and <paramref name="errorMessage"/>
        /// </summary>
        /// <param name="errorNumber">An error code in the <see cref="ES.AscomAlpaca.Exceptions.ErrorCodes"/> code range</param>
        /// <param name="errorMessage">The message that describes the error</param>
        /// <param name="clientTransactionId">The client transaction Id that has been sent by the client</param>
        /// <param name="serverTransactionId">Server transaction id generated by the server</param>
        public ImageArrayInt2DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 2D image array of int32 values
        /// </summary>
        public int[,] Value { get; set; }

        /// <summary>
        /// Image array type
        /// For this object it will always be <see cref="ImageArrayType.Int"/> 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Int;

        /// <summary>
        /// The array's rank
        /// For this object it will always be <see cref="ImageArrayRank.SinglePlane"/> 
        /// </summary>
        public ImageArrayRank Rank { get; } = ImageArrayRank.SinglePlane;
    }
}