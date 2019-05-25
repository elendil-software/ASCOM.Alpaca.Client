namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 3 dimension image array response
    /// </summary>
    public class ImageArrayDouble3DResponse : CommandResponse, IImageResponse<double[,,]>
    {
        public ImageArrayDouble3DResponse()
        {
        }

        public ImageArrayDouble3DResponse(double[,,] value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new double[0,0,0];
        }

        public ImageArrayDouble3DResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// 3D image array of double values
        /// </summary>
        public double[,,] Value { get; private set; }

        /// <summary>
        /// Image array type (double)
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Double;

        /// <summary>
        /// The array's rank, will be 3 (multi plane image (colour)).
        /// </summary>
        public int Rank { get; } = 3;
    }
}