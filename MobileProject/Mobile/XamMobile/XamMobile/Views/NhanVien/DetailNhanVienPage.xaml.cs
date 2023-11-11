using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.EntityModels;
using XamMobile.ViewModels;
using XamMobile.ViewModels.NhanVien;

namespace XamMobile.Views.NhanVien
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNhanVienPage : ContentPage
    {

        private DetailNhanVienPageViewModel viewModel { get; set; }
        // public PopupMenu Popup { get; set; }
        public DetailNhanVienPage()
        {
            InitializeComponent();
        }

        private void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            this.viewModel = (DetailNhanVienPageViewModel)BindingContext;
            this.viewModel.OpenUserPopUp(this.viewModel.CurrentData);
        }
    }
}