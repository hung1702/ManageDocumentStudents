using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.Services.Interface;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.CaNhan
{
    public class CaNhanMenuPageViewModel : ViewModelBase
    {
        IUserService iUserService;

        public DelegateCommand GotoTrangCaNhanPageCommand { get; private set; }
        public DelegateCommand GotoTouchPageCommand { get; private set; }
        public DelegateCommand GotoLogoutPopUpCommand { get; private set; }


        public CaNhanMenuPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoTrangCaNhanPageCommand = new DelegateCommand(() => { GotoPage(nameof(UserPage)); });
            GotoTouchPageCommand = new DelegateCommand(() => { GotoPage(nameof(VanTayPopUp)); });
            GotoLogoutPopUpCommand = new DelegateCommand( () => { GotoPage(nameof(LogOutPopUp)); });
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
