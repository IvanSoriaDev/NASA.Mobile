using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using NASA.Mobile.Helpers;
using NASA.Mobile.Services;

namespace NASA.Mobile.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ValidatableObject<string> _demo = new();

        public MainViewModel(IConfiguration configuration, IAlertService alertService) : base(configuration, alertService)
        {
            Demo.Value = "This is a demo";
            OnGet();
        }

        public void OnGet()
        {
            var moviesApiKey = _configuration["BaseUrl"];

            // call Movies service with the API key
        }
    }
}
