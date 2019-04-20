namespace ASCOM.Alpaca.Responses.Image
{
    public class ImageArrayIntRank2Response : ImageArrayResponse<int[,]>
    {
        public override int[,] Value { get; set; }
    }
}