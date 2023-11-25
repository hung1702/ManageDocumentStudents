using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.Diem;
using XamMobile.ViewModels.ThuVien;

namespace XamMobile.Views.ThuVien
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LichSuThuVienPage : ContentPage
	{
        public LichSuThuVienPageViewModel viewModel { get; set; }

        public LichSuThuVienPage ()
		{
			InitializeComponent ();
		}

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (LichSuThuVienPageViewModel)BindingContext;
            Picker picker = sender as Picker;
            if (picker == null)
                return;
            if (picker.SelectedItem.Equals("Cả ngày"))
                this.viewModel.ChonCaNgay();
            else if (picker.SelectedItem.Equals("Sáng"))
                this.viewModel.ChonSang();
            else
                this.viewModel.ChonChieu();
        }
    }
}