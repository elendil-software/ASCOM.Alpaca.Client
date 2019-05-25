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

        public ImageArrayInt2DResponse(int[,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new int[0,0];
        }

        public ImageArrayInt2DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 2D image array of int32 values
        /// </summary>
        public int[,] Value { get; set; }

        /// <summary>
        /// Image array type (int32)
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Int;

        /// <summary>
        /// The array's rank, will be 2 (single plane image (monochrome)).
        /// </summary>
        public int Rank { get; } = 2;
    }
}