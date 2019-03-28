using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Responses
{
    public class StringArrayResponse : ResponseBase, IValueResponse<List<string>>
    {
        public List<string> Value { get; set; }
    }
}