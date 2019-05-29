using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    /// <summary>
    /// This factory create new instance of IRestClient 
    /// </summary>
    public interface IRestClientFactory
    {
        /// <summary>
        /// Create a new instance of <see cref="IRestClient"/>
        /// </summary>
        /// <param name="baseUrl">The bases URL to configure in the restClient</param>
        /// <returns>The new created instance</returns>
        IRestClient Create(string baseUrl);
    }
}