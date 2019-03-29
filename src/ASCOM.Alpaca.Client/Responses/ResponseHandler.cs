using ASCOM.Alpaca.Client.Exceptions;

namespace ASCOM.Alpaca.Client.Responses
{
    internal static class ResponseHandler
    {
        public static T HandleResponse<T, TASCOMResponse>(this TASCOMResponse response) where TASCOMResponse : IValueResponse<T>
        {
            if (response.ErrorNumber != 0)
            {
                throw new ASCOMRemoteResponseException(response.ErrorMessage, response.ErrorNumber);
            }
            else
            {
                return response.Value;
            }
        }
        
        public static void HandleResponse(this MethodResponse response)
        {
            if (response.ErrorNumber != 0)
            {
                throw new ASCOMRemoteResponseException(response.ErrorMessage, response.ErrorNumber);
            }
        }
    }
}