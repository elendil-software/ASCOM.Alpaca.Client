namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageArrayShort2DResponse : CommandResponse, IImageResponse<short[,]>
    {
        private ImageArrayShort2DResponse()
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
        /// Image array type.
        /// For this object it will always be <see cref="ImageArrayType.Short"/> 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Short;

        /// <summary>
        /// The array's rank
        /// For this object it will always be <see cref="ImageArrayRank.SinglePlane"/> 
        /// </summary>
        public ImageArrayRank Rank { get; } = ImageArrayRank.SinglePlane;
    }
}