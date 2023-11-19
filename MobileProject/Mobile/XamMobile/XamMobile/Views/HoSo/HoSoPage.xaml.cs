using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;
using XamMobile.ViewModels.HoSo;

namespace XamMobile.Views.HoSo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoSoPage : ContentPage
    {
        private HoSoPageViewModel viewModel { get; set; }

        public HoSoPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (HoSoPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.OpenHoSoPopUp(e.SelectedItem);
            listView.SelectedItem = null;
        }
        protected override bool OnBackButtonPressed() => true;
    }
}