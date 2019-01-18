using System.Net.Http;

namespace Pexip.Lib
{
    public interface IHttpClientFactory
    {
        HttpClient NewClient(string apiUser, string apiPass);
    }
}
