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
        private ObservableCollection<Photo> _marsPhotos= new();

        [ObservableProperty]
        public List<string> _pictureDatesList = new List<string> 
        { 
            new DateTime(2016, 7, 13).ToString("MMM-dd-yyyy"),
            new DateTime(2017, 2, 27).ToString("MMM-dd-yyyy"),
            new DateTime(2018, 4, 30).ToString("MMM-dd-yyyy"),
            new DateTime(2018, 6, 2).ToString("MMM-dd-yyyy")
        };

        private readonly IImageService _imageService;

        public MainViewModel(IConfiguration configuration, IAlertService alertService, IRestService restService, IImageService imageService) : base(configuration, alertService, restService)
        {
            _imageService = imageService;
            OnGet();
        }

        [RelayCommand]
        async void ChangeDate(int sender)
        {   
            IsBusy = true;
            DateTime date = DateTime.ParseExact(_pictureDatesList[sender], "MMM-dd-yyyy", CultureInfo.InvariantCulture);
            var result = await _restService.GetRovers(date);
            result.Photos.ToList().ForEach(photo => MarsPhotos.Add(photo));

            //await _imageService.DownloadAndSaveImageAsync("http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/01622/opgs/edr/fcam/FLB_541484941EDR_F0611140FHAZ00341M_.JPG");
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
