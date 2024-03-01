using NASA.Mobile.Models;

namespace NASA.Mobile.Services
{
    public interface IAlertService
    {
        Task ExecuteDefaultPopup(string title, string message, PopupType popupType);
    }
}
