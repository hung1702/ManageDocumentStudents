using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class QuetMaQRPageViewModel : ViewModelBase
    {
        IUserService iUserService;

        private bool isScanning;
        public bool IsScanning
        {
            get { return isScanning; }
            set
            {
                if (isScanning != value)
                {
                    isScanning = value;
                    OnPropertyChanged(nameof(IsScanning));
                }
            }
        }
        public ICommand StopScanningCommand { get; private set; }

        public QuetMaQRPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            StopScanningCommand = new Command(StopScanning);
        }

        private void StopScanning()
        {
            IsScanning = false;
            GotoPage("MenuTienIchPage");
        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            await NavigationService.NavigateAsync(page);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
