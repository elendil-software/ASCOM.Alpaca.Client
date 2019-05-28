namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 2 dimension image array response
    /// </summary>
    public class ImageArrayDouble2DResponse : CommandResponse, IImageResponse<double[,]>
    {
        private ImageArrayDouble2DResponse()
        {
        }

        public ImageArrayDouble2DResponse(double[,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new double[0,0];
        }

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