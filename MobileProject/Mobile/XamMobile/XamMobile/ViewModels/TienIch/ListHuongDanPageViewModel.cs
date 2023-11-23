using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class ListHuongDanPageViewModel : ViewModelBase
    {
        IUserService iUserService;


        public DelegateCommand GotoHuongDanPageCommand { get; private set; }
        public DelegateCommand GotoHuongDanSlidePageCommand { get; private set; }

        public ListHuongDanPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoHuongDanPageCommand = new DelegateCommand(() => { GotoPage("HuongDanPage"); });
            GotoHuongDanSlidePageCommand = new DelegateCommand(() => { GotoPage("HuongDanSlidePage"); });
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
