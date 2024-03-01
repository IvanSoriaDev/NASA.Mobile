using Flurl.Http;


namespace NASA.Mobile.Helpers
{
    public interface IHttpHelper
    {
        Task<T?> Execute<T>(Task<T> task, string? errorMessage = null);
        IFlurlRequest GetRequest(string endpoint, Dictionary<string, string>? headers = null);
    }
}
