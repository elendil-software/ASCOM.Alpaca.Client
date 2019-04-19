namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDoubleRank2Response : ImageArrayResponseBase<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}