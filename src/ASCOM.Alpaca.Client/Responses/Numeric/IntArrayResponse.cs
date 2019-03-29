using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Responses.Numeric
{
    public class IntArrayResponse : ResponseBase, IValueResponse<List<int>>
    {
        public List<int> Value { get; set; }
    }
}