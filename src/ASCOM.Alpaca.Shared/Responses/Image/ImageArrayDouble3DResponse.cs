namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayDouble3DResponse : ImageArrayResponse<double[,,]>
    {
        public override double[,,] Value { get; set; }
    }
}