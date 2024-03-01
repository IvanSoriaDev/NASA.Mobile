using Mopups.Services;
using NASA.Mobile.Controls.Popups;
using NASA.Mobile.Models;

namespace NASA.Mobile.Services
{
    public class AlertService : IAlertService
    {
        public async Task ExecuteDefaultPopup(string title, string message, PopupType popupType) =>
            await MopupService.Instance.PushAsync(new DefaultInformativePopup(title, message, popupType));
    }
}
