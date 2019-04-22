namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayInt2DResponse : ImageArrayResponse<int[,]>
    {
        public override int[,] Value { get; set; }
    }
}