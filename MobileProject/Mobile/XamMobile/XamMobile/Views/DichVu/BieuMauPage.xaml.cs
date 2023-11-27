using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.DichVu;
using XamMobile.ViewModels.TienIch;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace XamMobile.Views.DichVu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BieuMauPage : ContentPage
    {
        public BieuMauPageViewModel viewModel { get; set; }

        public BieuMauPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            viewModel = (BieuMauPageViewModel)BindingContext;
            base.OnAppearing();
            await this.viewModel.GotoQuyTrinhBieuMauPopUp(this.viewModel.LoaiBieuMau);
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (BieuMauPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            //this.viewModel.SelectedNoiBat = true;
            //if (picker.SelectedItem.Equals("Có"))
            //    this.viewModel.TinTucCurrent.IsNoiBat = true;
            //else
            //    this.viewModel.TinTucCurrent.IsNoiBat = false;
        }
    }
}