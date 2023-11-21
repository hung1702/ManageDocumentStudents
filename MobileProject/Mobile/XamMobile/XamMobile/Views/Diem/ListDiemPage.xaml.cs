using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.Diem;
using XamMobile.ViewModels.NhanVien;

namespace XamMobile.Views.Diem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDiemPage : ContentPage
    {
        private bool isFirstTime = true;
        public ListDiemPageViewModel viewModel { get; set; }

        public ListDiemPage()
        {
            InitializeComponent();
            //this.Appearing += OnPageAppearing;
        }

        private void OnPageAppearing(object sender, EventArgs e)
        {
            //viewModel = (ListDiemPageViewModel)BindingContext;
            //Picker picker = sender as Picker;
            //if (picker == null)
            //    return;
            //picker.SelectedItem = "Tên";
            //((ListDiemPageViewModel)BindingContext).SelectedHocky = 0;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (ListDiemPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.GotoDetailDiemPage(e.SelectedItem);
            listView.SelectedItem = null;
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (ListDiemPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            if (picker.SelectedItem.Equals("Tên"))
                this.viewModel.SortByName();
            else if (picker.SelectedItem.Equals("Số TC"))
                this.viewModel.SortBySoTC();
            else
                this.viewModel.SortByDiemTB();
        }

        public void OnPickerHocKySelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                return;
            }
            viewModel = (ListDiemPageViewModel)BindingContext;

            int selectedIndex = ((Picker)sender).SelectedIndex;
            ((ListDiemPageViewModel)BindingContext).SelectedHocky = selectedIndex;
            this.viewModel.FilterByHocKy(selectedIndex);
        }

        protected override bool OnBackButtonPressed() => true;

    }
}