namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayShort3DResponse : ImageArrayResponse<short[,,]>
    {
        public override short[,,] Value { get; set; }
    }
}