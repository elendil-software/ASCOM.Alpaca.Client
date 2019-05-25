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
        ///  3D image array of short (int16) values
        /// </summary>
        public short[,,] Value { get; private set; }

        /// <summary>
        /// Image array type (int16)
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Short;

        /// <summary>
        /// The array's rank, will be 3 (multi plane image (colour)).
        /// </summary>
        public int Rank { get; } = 3;
    }
}