namespace ASCOM.Alpaca.Client.Responses.Image
{
    public class ImageArrayIntRank3Response : ImageArrayResponseBase<int[,]>
    {
        public override int[,] Value { get; set; }
    }
}