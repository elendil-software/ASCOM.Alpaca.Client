using System.Threading.Tasks;
using ES.Ascom.Alpaca.Responses;
using RestSharp;

namespace ES.Ascom.Alpaca.Client.Request
{
    /// <summary>
    /// An <see cref="ICommandSender"/> is to send a <see cref="IRestRequest"/> to an ASCOM Alpaca device
    /// </summary>
    public interface ICommandSender
    {
        /// <summary>
        /// <para>Send the <paramref name="request"/> to <paramref name="baseUrl"/></para>
        /// </summary>
        /// <param name="baseUrl">The device host</param>
        /// <param name="request">The request to send</param>
        /// <returns>The unparsed response</returns>
        IRestResponse ExecuteRequest(string baseUrl, IRestRequest request);

        /// <summary>
        /// <para>Send the <paramref name="request"/> to <paramref name="baseUrl"/></para>
        /// </summary>
        /// <param name="baseUrl">The device host</param>
        /// <param name="request">The request to send</param>
        /// <returns>The parsed response</returns>
        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse;

        /// <summary>
        /// <para>Send the <paramref name="request"/> to <paramref name="baseUrl"/></para>
        /// </summary>
        /// <param name="baseUrl">The device host</param>
        /// <param name="request">The request to send</param>
        /// <returns>The unparsed response</returns>
        Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request);

        /// <summary>
        /// <para>Send the <paramref name="request"/> to <paramref name="baseUrl"/></para>
        /// </summary>
        /// <param name="baseUrl">The device host</param>
        /// <param name="request">The request to send</param>
        /// <returns>The parsed response</returns>
        Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse;
    }
}