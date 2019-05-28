namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 3 dimension image array response
    /// </summary>
    public class ImageArrayInt3DResponse : CommandResponse, IImageResponse<int[,,]>
    {
        private ImageArrayInt3DResponse()
        {
        }

        public ImageArrayInt3DResponse(int[,,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new int[0,0,0];
        }

        public ImageArrayInt3DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 3D image array of int32 values
        /// </summary>
        public int[,,] Value { get; private set; }

        /// <summary>
        /// Image array type
        /// For this object it will always be <see cref="ImageArrayType.Int"/> 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Int;

        /// <summary>
        /// The array's rank
        /// For this object it will always be <see cref="ImageArrayRank.MultiPlane"/> 
        /// </summary>
        public ImageArrayRank Rank { get; } = ImageArrayRank.MultiPlane;
    }
}