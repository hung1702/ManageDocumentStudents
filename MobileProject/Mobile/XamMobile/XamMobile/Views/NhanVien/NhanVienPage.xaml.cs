using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;
using XamMobile.ViewModels.NhanVien;

namespace XamMobile.Views.NhanVien
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NhanVienPage : ContentPage
    {
        private NhanVienPageViewModel viewModel { get; set; }
        public NhanVienPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (NhanVienPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.OpenPopUpAddNhanVien(e.SelectedItem);
            listView.SelectedItem = null;
        }

        protected override bool OnBackButtonPressed() => true;

        private void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            if(picker == null)
                return;
            if(picker.SelectedItem.Equals("NVID"))
                this.viewModel.SortById();
            else
                this.viewModel.SortByName();
        }
        //public override Oppear
    }
}