namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDoubleRank3Response : ImageArrayResponseBase<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}