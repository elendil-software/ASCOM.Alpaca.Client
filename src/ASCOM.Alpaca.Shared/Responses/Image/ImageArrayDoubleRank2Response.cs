namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDoubleRank2Response : ImageArrayResponse<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}