using NASA.Mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mobile.Services
{
    public class HttpService(IHttpHelper httpHelper) : IHttpService
    {
        private readonly IHttpHelper _httpHelper = httpHelper;
        public Task<T> DeleteAsync<T>(string endpoint, object data, Dictionary<string, string>? headers)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string endpoint, Dictionary<string, string>? headers = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PatchAsync<T>(string endpoint, object data, Dictionary<string, string>? headers)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostAsync<T>(string endpoint, object data, Dictionary<string, string>? headers = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PutAsync<T>(string endpoint, object data, Dictionary<string, string>? headers)
        {
            throw new NotImplementedException();
        }
    }
}
