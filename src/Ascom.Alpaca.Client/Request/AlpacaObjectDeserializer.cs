using ES.Ascom.Alpaca.Responses;
using Newtonsoft.Json;

namespace ES.Ascom.Alpaca.Client.Request
{
    internal class AlpacaObjectDeserializer
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new NewtonsoftJsonPrivateResolver()
        };

        public TASCOMRemoteResponse DeserializeObject<TASCOMRemoteResponse>(string jsonObject)
            where TASCOMRemoteResponse : IResponse
        {
            return JsonConvert.DeserializeObject<TASCOMRemoteResponse>(jsonObject, _jsonSerializerSettings);
        }
    }
}