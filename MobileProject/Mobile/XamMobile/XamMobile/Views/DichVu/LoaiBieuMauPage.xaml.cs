using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.DichVu;

namespace XamMobile.Views.DichVu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoaiBieuMauPage : ContentPage
	{
        public LoaiBieuMauPageViewModel viewModel { get; set; }

        public LoaiBieuMauPage ()
		{
			InitializeComponent ();
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (LoaiBieuMauPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.GotoBieuMauPage(e.SelectedItem);
            listView.SelectedItem = null;
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (LoaiBieuMauPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            if (picker.SelectedItem.Equals("Tên biểu mẫu"))
                this.viewModel.SortByTen();
            else if (picker.SelectedItem.Equals("Thời gian xử lý"))
                this.viewModel.SortByNgayXuLy();
            else
                this.viewModel.SortByNgayTao();
        }
    }
}