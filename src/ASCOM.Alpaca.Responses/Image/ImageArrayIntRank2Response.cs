namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayIntRank2Response : ImageArrayResponseBase<int[,]>
    {
        public override int[,] Value { get; set; }
    }
}