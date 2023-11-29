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
using XamMobile.ViewModels.TabbedPage;

namespace XamMobile.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VanTayPopUp : PopupPage
    {
        private VanTayPopUpViewModel viewModel { get; set; }

        public VanTayPopUp()
        {
            InitializeComponent();
        }
        public async void OnPopupClose(object sender, EventArgs e)
        {
            viewModel = (VanTayPopUpViewModel)BindingContext;

            await PopupNavigation.Instance.PopAsync(true);
            await this.viewModel.GotoCommonPopUp();
        }
    }
}