using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Responses.String
{
    public class StringArrayResponse : ResponseBase, IValueResponse<List<string>>
    {
        public List<string> Value { get; set; }
    }
}