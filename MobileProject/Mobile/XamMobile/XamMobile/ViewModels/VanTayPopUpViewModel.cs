using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels
{
    public class VanTayPopUpViewModel : ViewModelBase
    {
        IUserService iUserService;

        public DelegateCommand HuyCommand { get; private set; }

        public VanTayPopUpViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            HuyCommand = new DelegateCommand(async () => { await GotoCommonPopUp(); });
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

        public async Task GotoCommonPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new LoaiBieuMauEntity();
            navigationParamters.Add("title", "Thông Báo");
            navigationParamters.Add("message", "Lỗi khi lấy vân tay");
            navigationParamters.Add("buttonname", "Đồng ý");
            await NavigationService.NavigateAsync(nameof(CommonPopUp), navigationParamters);
        }
    }
}
