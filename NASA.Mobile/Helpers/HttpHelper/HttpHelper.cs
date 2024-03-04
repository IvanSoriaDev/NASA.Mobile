using Flurl;
using Flurl.Http;
using NASA.Mobile.Services;

namespace NASA.Mobile.Helpers
{
    public class HttpHelper(IAlertService alertService) : IHttpHelper
    {
        private readonly IAlertService _alertService = alertService;

        string _baseUrl = "https://api.nasa.gov";

        public async Task<T?> Execute<T>(Task<T> task, string? errorMessage = null)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await _alertService.ExecuteDefaultPopup("Alert", "No internet Connection available", Models.PopupType.Warning);
                return default;
            }

            try
            {
                return await task;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response != null)
                {
                    //Here we can handle all status code in the app, for demo I will let it empty
                    var statusCode = ex.Call.Response.StatusCode;

                    switch (statusCode)
                    {
                        default:
                            break;
                    }
                }
                return default;
            }
            catch(Exception ex) 
            {
                await _alertService.ExecuteDefaultPopup("Error", ex.Message, Models.PopupType.Erorr);
                return default;
            }
        }

        public IFlurlRequest GetRequest(string endpoint, object data, Dictionary<string, string> parameters, Dictionary<string, string>? headers = null) =>
            _baseUrl.AppendPathSegment(endpoint).WithHeaders(headers).SetQueryParams(parameters);
    }
}
