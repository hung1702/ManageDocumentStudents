using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.Diem;

namespace XamMobile.Views.Diem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GiaLapDiemPage : ContentPage
	{
        public GiaLapDiemPageViewModel viewModel { get; set; }

        public GiaLapDiemPage ()
		{
			InitializeComponent ();
		}

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                // Update the underlying data with the entered value
                //var selectedItem = entry.BindingContext as YourDataType; // Replace YourDataType with the actual type of items in ListDiem
                //if (selectedItem != null)
                //{
                //    selectedItem.DiemTB = entry.Text;
                //    // Handle any additional logic you need when the value is updated
                //}
                return;
            }
        }

        public void Picker_OnSelectedSortBy(object sender, EventArgs e)
        {
            viewModel = (GiaLapDiemPageViewModel)BindingContext;
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
    }
}