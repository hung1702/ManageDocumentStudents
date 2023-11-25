using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels
{
    public class MenuCongNoPageViewModel : ViewModelBase
    {
        private double _tinChiTotal;
        public double TinChiTotal
        {
            get { return _tinChiTotal; }
            set
            {
                if (_tinChiTotal != value)
                {
                    _tinChiTotal = value;
                    OnPropertyChanged(nameof(TinChiTotal));
                }
            }
        }

        IUserService iUserService;
        public DelegateCommand GotoHocPhiPageCommand { get; private set; }
        public DelegateCommand GotoKhoanDaNopPageCommand { get; private set; }
        public DelegateCommand GotoKhoanChuaNopPageCommand { get; private set; }
        
        public MenuCongNoPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoHocPhiPageCommand = new DelegateCommand(() => { GotoPage("HocPhiPage"); });
            GotoKhoanDaNopPageCommand = new DelegateCommand(() => { GotoPage("KhoanDaNopPage"); });
            GotoKhoanChuaNopPageCommand = new DelegateCommand(() => { GotoPage("KhoanChuaNopPage"); });
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
