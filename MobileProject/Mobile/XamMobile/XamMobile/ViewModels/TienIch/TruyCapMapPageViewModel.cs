using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class TruyCapMapPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        public ICommand MoveToUserLocationCommand { get; }

        //public DelegateCommand GotoListHuongDanPageCommand { get; private set; }
        //public DelegateCommand GotoGioiThieuPageCommand { get; private set; }
        //public DelegateCommand GotoTinTucPageCommand { get; private set; }

        public TruyCapMapPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            MoveToUserLocationCommand = new Command(MoveToUserLocation);

            //GotoListHuongDanPageCommand = new DelegateCommand(() => { GotoPage("ListHuongDanPage"); });
            //GotoGioiThieuPageCommand = new DelegateCommand(() => { GotoPage("GioiThieuPage"); });
            //GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });
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


        private async void MoveToUserLocation()
        {
            //try
            //{
            //    var location = await Geolocation.GetLastKnownLocationAsync();

            //    if (location != null)
            //    {
            //        // Move to the user's location on the map
            //        MessagingCenter.Send(this, "MoveToLocation", new Position(location.Latitude, location.Longitude));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle error when unable to get location
            //    Console.WriteLine($"Error getting location: {ex.Message}");
            //}
        }
    }
}
