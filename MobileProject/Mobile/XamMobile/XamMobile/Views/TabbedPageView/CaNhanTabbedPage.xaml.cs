using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;
using XamMobile.ViewModels.TabbedPage;

namespace XamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaNhanTabbedPage : ContentPage
    {
        private HomeMenuPageViewModel viewModel { get; set; }

        public CaNhanTabbedPage()
        {
            InitializeComponent();
            //viewModel = (HomeMenuPageViewModel)BindingContext;
            //viewModel.CurrentPage = this;
        }
    }
}