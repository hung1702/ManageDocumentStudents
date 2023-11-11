using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.NhanVien;

namespace XamMobile.Views.NhanVien
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNhanVienPage : ContentPage
    {
        private AddNhanVienPageViewModel viewModel { get; set; }

        public AddNhanVienPage()
        {
            InitializeComponent();
        }
    }
}