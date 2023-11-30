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
    public class AddNhanVienPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        IPermissionService _permissionService;
        DownloadService downloadService { get; set; }
        IFileService _fileService;
        IUploadFileService iUploadFileService;


        public DelegateCommand ClosePopupCommand { get; private set; }
        public DelegateCommand SaveNhanVienCommand { get; private set; }
        public DelegateCommand UpdatePictureCommand { get; private set; }


        private NhanVienEntity _currentData;
        public NhanVienEntity CurrentData
        {
            get { return _currentData; }
            set { SetProperty(ref _currentData, value); }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSourceAvatar
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        public AddNhanVienPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;

            SaveNhanVienCommand = new DelegateCommand(async () => { await SaveNhanVien(); });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CurrentData = parameters.GetValue<NhanVienEntity>("obj");
            if(CurrentData == null)
            {
                CurrentData = new NhanVienEntity();
                CurrentData.GioiTinh = true;
            }
            base.OnNavigatedTo(parameters);

            LoadAllData();
        }

        private async void LoadAllData()
        {
            try
            {
                using (UserDialogs.Instance.Loading("Đang tải"))
                {
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async Task SaveNhanVien()
        {
            if (string.IsNullOrEmpty(CurrentData.TenNhanVien))
            {
                UserDialogs.Instance.Toast("save failed");
                await App.Current.MainPage.DisplayAlert("Alert", "Ho Ten not empty!", "OK");
            }
            else if (!CurrentData.Email.Contains("@gmail.com"))
            {
                UserDialogs.Instance.Toast("save failed");
                await App.Current.MainPage.DisplayAlert("Alert", "Email not correct format!", "OK");
            }
            else
            {
                if (CurrentData.NgaySinh == null)
                    CurrentData.NgaySinh = DateTime.Now;

                if (CurrentData.GioiTinhStr.ToLower().Equals("Nam".ToLower()))
                    CurrentData.GioiTinh = true;
                else
                    CurrentData.GioiTinh = false;
                var newNhanVien = CurrentData;
                var res = await iUserService.SaveNhanVien(newNhanVien);
                if (res != null)
                {
                    MessagingCenter.Send((App)Application.Current, "UpdateNhanVien", res);
                    UserDialogs.Instance.Toast("Succeeded");
                    await App.Current.MainPage.DisplayAlert("Alert", "Created successfully!", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Employee creation failed!", "OK");
                    UserDialogs.Instance.Toast("save failed");
                }
            }
        }
    }
}
