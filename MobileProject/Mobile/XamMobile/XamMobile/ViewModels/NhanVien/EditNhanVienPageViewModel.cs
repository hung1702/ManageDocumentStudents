using Acr.UserDialogs;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services;
using XamMobile.Services.Interface;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.NhanVien
{
    public class EditNhanVienPageViewModel : ViewModelBase
    {
        private ObservableCollection<string> _actionDatasource;
        public ObservableCollection<string> ActionDatasource
        {
            get { return _actionDatasource; }
            set { SetProperty(ref _actionDatasource, value); }
        }
        public UserPage CurrentPage { get; set; }

        private NhanVienEntity _userInfoModel;
        public NhanVienEntity UserInfoModel
        {
            get { return _userInfoModel; }
            set { SetProperty(ref _userInfoModel, value); }
        }

        private string _ngayCapFormat;
        public string NgayCapFormat
        {
            get { return _ngayCapFormat; }
            set { SetProperty(ref _ngayCapFormat, value); }
        }

        private string _ngaySinhFormat;
        public string NgaySinhFormat
        {
            get { return _ngaySinhFormat; }
            set { SetProperty(ref _ngaySinhFormat, value); }
        }


        private ImageSource _imageSource;
        public ImageSource ImageSourceAvatar
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        IUserService iUserService;
        public DelegateCommand UpdatePictureCommand { get; private set; }


        public EditNhanVienPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            UserInfoModel = UserInfoSetting.UserInfos;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var nhanVienId = 3;
            LoadAllData(nhanVienId);
        }

        private async void LoadAllData(int nhanVienId)
        {
            try
            {
                using (UserDialogs.Instance.Loading("Đang tải"))
                {
                    NgayCapFormat = UserInfoSetting.UserInfos.NgayCapFormat;
                    NgaySinhFormat = UserInfoSetting.UserInfos.NgaySinhFormat;
                    var nhanVienRes = await iUserService.GetNhanVien(nhanVienId);
                    if (nhanVienRes == null)
                    {
                        UserDialogs.Instance.Alert("Có lỗi khi tải thông tin nhân viên");
                        return;
                    }
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async void OpenUserPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new NhanVienEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("UserPopupPage", navigationParamters);
        }
    }
}
