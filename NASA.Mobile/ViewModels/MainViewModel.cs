using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using NASA.Mobile.Helpers;
using NASA.Mobile.Models;
using NASA.Mobile.Services;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace NASA.Mobile.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ValidatableObject<string> _demo = new();

        [ObservableProperty]
        private ObservableCollection<Photo> _marsPhotos= new();

        [ObservableProperty]
        public List<string> _pictureDatesList = new List<string> 
        { 
            new DateTime(2016, 7, 13).ToString("MMM-dd-yyyy"),
            new DateTime(2017, 2, 27).ToString("MMM-dd-yyyy"),
            new DateTime(2018, 4, 30).ToString("MMM-dd-yyyy"),
            new DateTime(2018, 6, 2).ToString("MMM-dd-yyyy")
        };

        public MainViewModel(IConfiguration configuration, IAlertService alertService, IRestService restService) : base(configuration, alertService, restService)
        {
            Demo.Value = "This is a demo";
            OnGet();
        }

        [RelayCommand]
        async void ChangeDate(int sender)
        {   
            IsBusy = true;
            DateTime date = DateTime.ParseExact(_pictureDatesList[sender], "MMM-dd-yyyy", CultureInfo.InvariantCulture);
            var result = await _restService.GetRovers(date);
            result.Photos.ToList().ForEach(photo => MarsPhotos.Add(photo));
            IsBusy = false;
        }

        protected async override void Initialize()
        {
        }

        public void OnGet()
        {
            var moviesApiKey = _configuration["BaseUrl"];

            // call Movies service with the API key
        }
    }
}
