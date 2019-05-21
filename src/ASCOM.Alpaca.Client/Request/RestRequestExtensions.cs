using RestSharp;

namespace AscomAlpacaClient.Request
{
    internal static class RestRequestExtensions
    {
        internal static void SetTimeout(this IRestRequest restRequest, int? timeout)
        {
            if (restRequest != null && timeout.HasValue && timeout.Value > 0)
            {
                restRequest.Timeout = timeout.Value * 1000;
            }
        }
    }
}