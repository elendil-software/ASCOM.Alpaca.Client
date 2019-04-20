namespace ASCOM.Alpaca.Responses.Image
{
    public abstract class ImageArrayResponse<T> : Response, IImageArrayResponse<T>
    {
        public virtual T Value { get; set; }
        public ImageArrayType ArrayType { get; set; }
        public ImageRank Rank { get; set; }
    }
}