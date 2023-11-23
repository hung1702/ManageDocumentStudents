using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class MenuTienIchPageViewModel : ViewModelBase
    {
        IUserService iUserService;

        public DelegateCommand GotoListHuongDanPageCommand { get; private set; }
        public DelegateCommand GotoGioiThieuPageCommand { get; private set; }
        public DelegateCommand GotoTinTucPageCommand { get; private set; }

        public MenuTienIchPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoListHuongDanPageCommand = new DelegateCommand(() => { GotoPage("ListHuongDanPage"); });
            GotoGioiThieuPageCommand = new DelegateCommand(() => { GotoPage("GioiThieuPage"); });
            GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });
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
