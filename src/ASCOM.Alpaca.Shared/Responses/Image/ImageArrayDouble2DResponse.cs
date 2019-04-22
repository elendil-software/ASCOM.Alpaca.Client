namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDouble2DResponse : ImageArrayResponse<double[,]>
    {
        public override double[,] Value { get; set; }
    }
}