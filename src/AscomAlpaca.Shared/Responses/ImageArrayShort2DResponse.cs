namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageArrayShort2DResponse : CommandResponse, IImageResponse<short[,]>
    {
        public ImageArrayShort2DResponse()
        {
        }

        public ImageArrayShort2DResponse(short[,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new short[0,0];
        }

        public ImageArrayShort2DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        public short[,] Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Short;

        /// <summary>
        /// 
        /// </summary>
        public int Rank { get; } = 2;
    }
}