using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;
using XamMobile.ViewModels.CaNhan;

namespace XamMobile.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogOutPopUp : PopupPage
    {
        private LogOutPopUpViewModel viewModel { get; set; }

        public LogOutPopUp()
        {
            InitializeComponent();
        }
        public async void OnPopupClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        } 

        public async void YesPopupClose(object sender, EventArgs e)
        {
            viewModel = (LogOutPopUpViewModel)BindingContext;
            await PopupNavigation.Instance.PopAsync(true);
            await this.viewModel.LogOut();
        }
    }
}