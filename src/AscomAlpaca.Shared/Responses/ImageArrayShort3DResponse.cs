namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 3 dimension image array response
    /// </summary>
    public class ImageArrayShort3DResponse : CommandResponse, IImageResponse<short[,,]>
    {
        private ImageArrayShort3DResponse()
        {
        }

        public ImageArrayShort3DResponse(short[,,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new short[0,0,0];
        }

        public ImageArrayShort3DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 3D image array of short (int16) values
        /// </summary>
        public short[,,] Value { get; private set; }

        /// <summary>
        /// Image array type.
        /// For this object it will always be <see cref="ImageArrayType.Short"/> 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Short;

        /// <summary>
        /// The array's rank
        /// For this object it will always be <see cref="ImageArrayRank.SinglePlane"/> 
        /// </summary>
        public ImageArrayRank Rank { get; } = ImageArrayRank.MultiPlane;
    }
}