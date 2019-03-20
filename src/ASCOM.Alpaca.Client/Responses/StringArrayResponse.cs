using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Responses
{
    public class StringArrayResponse : ResponseBase, IValueResponse<string[]>
    {
        public string[] Value { get; set; }
    }
}