namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayShort2DResponse : ImageArrayResponse<short[,]>
    {
        public override short[,] Value { get; set; }
    }
}