using Mopups.Pages;
using NASA.Mobile.Models;

namespace NASA.Mobile.Controls.Popups;

public partial class DefaultInformativePopup : PopupPage
{
	public DefaultInformativePopup(string title, string message, PopupType popupType)
	{
		InitializeComponent();
		TitleLbl.Text = title;
		MessageLbl.Text = message;

		//ToDo: Implement styles for popupType
	}
}