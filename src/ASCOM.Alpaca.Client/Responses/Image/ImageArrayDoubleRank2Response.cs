namespace ASCOM.Alpaca.Client.Responses.Image
{
    public class ImageArrayDoubleRank2Response : ImageArrayResponseBase<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}