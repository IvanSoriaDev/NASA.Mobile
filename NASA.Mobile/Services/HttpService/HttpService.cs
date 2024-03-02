using Flurl.Http;
using NASA.Mobile.Helpers;

namespace NASA.Mobile.Services
{
    public class HttpService(IHttpHelper httpHelper) : IHttpService
    {
        private readonly IHttpHelper _httpHelper = httpHelper;
        public async Task<T> DeleteAsync<T>(string endpoint, object data, Dictionary<string, string>? headers) =>
            await _httpHelper.Execute(_httpHelper.GetRequest(endpoint, headers).DeleteAsync().ReceiveJson<T>());

        public async Task<T> GetAsync<T>(string endpoint, object data, Dictionary<string, string>? headers = null) =>
            await _httpHelper.Execute(_httpHelper.GetRequest(endpoint, headers).GetAsync().ReceiveJson<T>());

        public async Task<T> PatchAsync<T>(string endpoint, object data, Dictionary<string, string>? headers) =>
            await _httpHelper.Execute(_httpHelper.GetRequest(endpoint, headers).PatchAsync().ReceiveJson<T>());

        public async Task<T> PostAsync<T>(string endpoint, object data, Dictionary<string, string>? headers = null) =>
            await _httpHelper.Execute(_httpHelper.GetRequest(endpoint, headers).PostAsync().ReceiveJson<T>());

        public async Task<T> PutAsync<T>(string endpoint, object data, Dictionary<string, string>? headers) =>
            await _httpHelper.Execute(_httpHelper.GetRequest(endpoint, headers).PutAsync().ReceiveJson<T>());
    }
}
