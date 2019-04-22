namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayInt3DResponse : ImageArrayResponse<int[,,]>
    {
        public override int[,,] Value { get; set; }
    }
}