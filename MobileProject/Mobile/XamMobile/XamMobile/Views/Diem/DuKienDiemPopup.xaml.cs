using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamMobile.Views.Diem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DuKienDiemPopup : PopupPage
    {
		public DuKienDiemPopup ()
		{
			InitializeComponent ();
		}

        public async void OnPopupClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}