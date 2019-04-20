namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayIntRank3Response : ImageArrayResponse<int[,]>
    {
        public override int[,] Value { get; set; }
    }
}