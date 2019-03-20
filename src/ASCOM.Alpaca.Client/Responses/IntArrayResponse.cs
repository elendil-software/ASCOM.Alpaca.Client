namespace ASCOM.Alpaca.Client.Responses
{
    public class IntArrayResponse : ResponseBase, IValueResponse<int[]>
    {
        public int[] Value { get; set; }
    }
}