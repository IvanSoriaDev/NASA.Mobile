using Microsoft.Extensions.Configuration;
using NASA.Mobile.ViewModels;

namespace NASA.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
