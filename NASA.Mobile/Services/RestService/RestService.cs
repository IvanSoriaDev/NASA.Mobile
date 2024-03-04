using NASA.Mobile.Models;

namespace NASA.Mobile.Services
{
    public class RestService(IHttpService httpService) : IRestService
    {
        private readonly IHttpService _httpService = httpService;
        public async Task<MarsPhotoResponse> GetRovers(DateTime dateTime) =>
            await _httpService.GetAsync<MarsPhotoResponse>(endpoint:"mars-photos/api/v1/rovers/curiosity/photos",
                                                           data: null,
                                                           parameters: new Dictionary<string, string> { { "earth_date", dateTime.ToString("yyyy-MM-dd") }, { "api_key", "COPtAU572aL4YQXJHjbMoLXjSw7SxGCNbsGhxcB0" } }, 
                                                           headers: null);
    }
}
