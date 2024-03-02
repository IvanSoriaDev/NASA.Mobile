namespace NASA.Mobile.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string endpoint, object data, Dictionary<string, string>? headers = null);
        Task<T> PostAsync<T>(string endpoint, object data, Dictionary<string, string>? headers = null);
        Task<T> PutAsync<T>(string endpoint, object data, Dictionary<string, string>? headers);
        Task<T> DeleteAsync<T>(string endpoint, object data, Dictionary<string, string>? headers);
        Task<T> PatchAsync<T>(string endpoint, object data, Dictionary<string, string>? headers);
    }
}
