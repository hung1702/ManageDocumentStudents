using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.Diem;
using XamMobile.ViewModels.TienIch;

namespace XamMobile.Views.TienIch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TinTucTaoMoiPage : ContentPage
    {
        private bool isFirstTime = true;
        public TinTucTaoMoiPageViewModel viewModel { get; set; }
        public TinTucTaoMoiPage()
        {
            InitializeComponent();
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (TinTucTaoMoiPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            this.viewModel.SelectedNoiBat = true;
            if (picker.SelectedItem.Equals("Có"))
                this.viewModel.TinTucCurrent.IsNoiBat = true;
            else
                this.viewModel.TinTucCurrent.IsNoiBat = false;
        }
    }
}