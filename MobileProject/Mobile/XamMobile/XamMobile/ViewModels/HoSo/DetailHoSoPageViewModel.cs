using Acr.UserDialogs;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.HoSo
{
    public class DetailHoSoPageViewModel : ViewModelBase
    {
        private HoSoEntity _currentData;
        public HoSoEntity CurrentData
        {
            get { return _currentData; }
            set { SetProperty(ref _currentData, value); }
        }

        private string _htmlString;
        public string HtmlString
        {
            get { return _htmlString; }
            set { SetProperty(ref _htmlString, value); }
        }

        private HtmlWebViewSource _htmlWebViewSource;
        public HtmlWebViewSource HtmlWebViewSource
        {
            get { return _htmlWebViewSource; }
            set { SetProperty(ref _htmlWebViewSource, value); }
        }

        public DetailHoSoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CurrentData = new HoSoEntity();
            HtmlWebViewSource = new HtmlWebViewSource() { Html = "" };
            HtmlString = "";
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CurrentData = parameters.GetValue<HoSoEntity>("obj");
            //HtmlWebViewSource.Html = CurrentData.Content;
            base.OnNavigatedTo(parameters);
        }
    }
}
