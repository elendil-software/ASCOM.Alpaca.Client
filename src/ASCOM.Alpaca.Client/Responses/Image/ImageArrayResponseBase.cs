namespace ASCOM.Alpaca.Client.Responses.Image
{
    public abstract class ImageArrayResponseBase<T> : ResponseBase, IImageArrayResponse<T>
    {
        public virtual T Value { get; set; }
        public ImageArrayType ArrayType { get; set; }
        public ImageRank Rank { get; set; }
    }
}