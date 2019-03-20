namespace ASCOM.Alpaca.Client.Responses
{
    //TODO find a way to support short and double types
    public class ImageArrayResponse : ResponseBase, IImageArrayResponse<int[][]>
    {
        public int[][] Value { get; set; }
        public int ArrayType { get; set; }
        public int Rank { get; set; }
    }
}