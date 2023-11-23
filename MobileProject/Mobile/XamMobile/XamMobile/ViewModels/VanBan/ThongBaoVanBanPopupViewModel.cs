using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.VanBan
{
    public class ThongBaoVanBanPopupViewModel : ViewModelBase
    {
        IUserService iUserService;

        public ThongBaoVanBanPopupViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
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
