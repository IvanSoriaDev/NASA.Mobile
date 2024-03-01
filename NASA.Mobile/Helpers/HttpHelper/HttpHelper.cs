using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mobile.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        public Task<T?> Execute<T>(Task<T> task, string? errorMessage = null)
        {
            throw new NotImplementedException();
        }

        public IFlurlRequest GetRequest(string endpoint, Dictionary<string, string>? headers = null)
        {
            throw new NotImplementedException();
        }
    }
}
