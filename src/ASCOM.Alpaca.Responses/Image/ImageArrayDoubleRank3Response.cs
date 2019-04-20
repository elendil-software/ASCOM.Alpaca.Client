namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDoubleRank3Response : ImageArrayResponse<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}