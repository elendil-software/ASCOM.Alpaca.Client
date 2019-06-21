namespace ES.Ascom.Alpaca.Responses
{
    /// <summary>
    /// ImageArrayResponse interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImageResponse<T> : IValueResponse<T>
    {
        /// <summary>
        /// The type of data contained in <see cref="IValueResponse{T}.Value"/>
        /// </summary>
        ImageArrayType ArrayType { get; }

        /// <summary>
        /// The array's rank. It defines the image type (monochrome or colour).
        /// </summary>
        /// <seealso cref="ImageArrayRank"/>
        ImageArrayRank Rank { get; }
    }
}