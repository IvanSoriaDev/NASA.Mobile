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

        [ObservableProperty]
        private bool _isBusy;
        #endregion

        public BaseViewModel(IConfiguration configuration, IAlertService alertService)
        {
            _configuration = configuration;
            _alertService = alertService;
        }
    }
}
