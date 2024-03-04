using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using NASA.Mobile.Services;

namespace NASA.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        #region Properties
        protected IConfiguration _configuration;
        protected IAlertService _alertService;
        protected IRestService _restService;

        [ObservableProperty]
        private bool _isBusy;
        #endregion

        public BaseViewModel(IConfiguration configuration, IAlertService alertService, IRestService restService)
        {
            _configuration = configuration;
            _alertService = alertService;
            _restService = restService;

            Initialize();
        }

        protected virtual void Initialize() { }
    }
}
