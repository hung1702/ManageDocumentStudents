using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class TinTucPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        ITinTucService iTinTucService;

        public TinTucPageViewModel(INavigationService navigationService, IUserService iUserService, ITinTucService iTinTucService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iTinTucService = iTinTucService;
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
            LoadAllData();
        }

        public async void LoadAllData()
        {
            try
            {
                var tinTuc = await iTinTucService.GetAllTinTuc();
                var tmp = tinTuc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
