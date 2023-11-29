using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.CaNhan
{
    public class LogOutPopUpViewModel : ViewModelBase
    {
        IUserService iUserService;
        public DelegateCommand GotoLogoutCommand { get; private set; }

        public LogOutPopUpViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoLogoutCommand = new DelegateCommand(async () => { await LogOut(); });
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


        public async Task LogOut()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            UserDialogs.Instance.Toast("Logout thành công");
        }
    }
}
