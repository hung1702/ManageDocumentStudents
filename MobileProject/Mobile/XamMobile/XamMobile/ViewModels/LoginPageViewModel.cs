using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services.Interface;
using XamMobile.Views;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public DelegateCommand GotoHomePageCommand { get; private set; }
        public DelegateCommand GotoHoTroCommand { get; private set; }
        public DelegateCommand GotoQuenMatKhauCommand { get; private set; }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        IUserService iUserService;
        public LoginPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            GotoHomePageCommand = new DelegateCommand(GotoHomePage);
            GotoHoTroCommand = new DelegateCommand(() => { GotoCommonPopUp("Hỗ trợ", "Liên hệ với Admin để lấy lại mật khẩu", "Đồng ý"); });
            GotoQuenMatKhauCommand = new DelegateCommand(() => { GotoCommonPopUp("Quên mật khẩu", "Liên hệ với Admin để lấy lại mật khẩu", "Đồng ý"); });

            this.iUserService = iUserService;
        }

        //tai icon font: https://fonts.google.com/icons
        public async void GotoHomePage()
        {
            //username1: admin1
            //password: admin
            using (UserDialogs.Instance.Loading("Đang đăng nhập"))
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                {
                    UserDialogs.Instance.Alert("Không được để trống mục tài khoản hoặc mật khẩu");
                    return;
                }
                //var res = await iUserService.Login(UserName, Password);
                //if (res.IsSuccess)
                if (true)
                {
                    var userInfoResponses = await iUserService.GetUsers();
                    var dsNhanVien = await iUserService.GetNhanViens();
                    var userInfo = userInfoResponses.FirstOrDefault(x => x.UserName == UserName);
                    var nhanVienEntity = new NhanVienEntity()
                    {
                        UserID = userInfo.UserID
                    };
                    if (dsNhanVien != null)
                    {
                        nhanVienEntity = dsNhanVien.FirstOrDefault(x => x.UserID == userInfo.UserID);
                    }
                    else
                    {

                    }
                    if (nhanVienEntity != null)
                    {
                        UserInfoSetting.UserInfos = nhanVienEntity;
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Có lỗi xảy ra khi lấy thông tin người dùng");
                        return;
                    }

                    //await NavigationService.NavigateAsync(nameof(MenuPage) + "/" + nameof(NavigationPage) + "/" + nameof(HomeMenuPage));
                    await NavigationService.NavigateAsync(nameof(MenuPage) + "/" + nameof(NavigationPage) + "/" + nameof(CommonTabbedPage));
                }
                else
                {
                    UserDialogs.Instance.Alert("Tài khoản hoặc mật khẩu không hợp lệ");
                }
            }
        }

        public async void GotoCommonPopUp(string tilte, string message, string buttonName)
        {
            var navigationParamters = new NavigationParameters();
            navigationParamters.Add("title", tilte);
            navigationParamters.Add("message", message);
            navigationParamters.Add("buttonname", buttonName);
            await NavigationService.NavigateAsync(nameof(CommonPopUp), navigationParamters);
        }
    }
}
