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
	public partial class TinTucPage : ContentPage
	{
        private bool isFirstTime = true;
        public TinTucPageViewModel viewModel { get; set; }
        public TinTucPage ()
		{
			InitializeComponent ();
		}
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (TinTucPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.GotoTinTucDetailPage(e.SelectedItem);
            listView.SelectedItem = null;
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (TinTucPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            if (picker.SelectedItem.Equals("Ngày tạo mới nhất"))
                this.viewModel.SortByNgayTaoMoi();
            else if (picker.SelectedItem.Equals("Ngày tạo cũ nhất"))
                this.viewModel.SortByNgayTaoCu();
            else if (picker.SelectedItem.Equals("Tin nổi bật"))
                this.viewModel.SortByTinNoiBat();
            else
                this.viewModel.SortByTieuDe();
        }

        protected override bool OnBackButtonPressed() => true;
    }
}