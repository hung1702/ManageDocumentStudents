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
            this.iUploadFileService = iUploadFileService;
            _permissionService = Xamarin.Forms.DependencyService.Get<DependencyServices.IPermissionService>();
            _fileService = Xamarin.Forms.DependencyService.Get<DependencyServices.IFileService>();
            downloadService = new DownloadService(_permissionService, _fileService);



            SaveNhanVienCommand = new DelegateCommand(async () => { await SaveNhanVien(); });
            UpdatePictureCommand = new DelegateCommand(async () => { await UpdatePicture(); });

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
                    //ImageSourceAvatar = string.IsNullOrEmpty(CurrentData.AnhDaiDien)
                    //    ? null
                    //    : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{CurrentData.AnhDaiDien}");
                    // var nhanVienRes = await iUserService.GetNhanVien(UserInfoSetting.UserInfos.NhanVienID);
                    //if (nhanVienRes == null)
                    //{
                    //    UserDialogs.Instance.Alert("Có lỗi khi tải thông tin nhân viên");
                    //    return;
                    //}
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async Task SaveNhanVien()
        {
            //Random rnd = new Random();
            //CurrentData.NhanVienID = rnd.Next(1, 1000000000);
            //CurrentData.UserID = rnd.Next(1, 1000000000);
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

        private async Task UpdatePicture()
        {
            try
            {
                await _permissionService.RequestExternalPermssion();

                var fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking
                var fileName = fileData.FileName;
                var contents = fileData.DataArray;

                var file = new Services.Models.FileUploaded() { FileName = fileName, Content = contents };

                var imageRes = await iUploadFileService.UploadFile(file);
                if (!string.IsNullOrEmpty(imageRes))
                {
                    CurrentData.AnhDaiDien = imageRes.Replace("\"", "");
                    //var updateAvatar = await iUserService.SaveNhanVien(UserInfoSetting.UserInfos);
                    //if (!string.IsNullOrEmpty(updateAvatar.AnhDaiDien))
                    //{
                    //    ImageSourceAvatar = string.IsNullOrEmpty(UserInfoSetting.UserInfos.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{UserInfoSetting.UserInfos.AnhDaiDien}");
                    //    UserDialogs.Instance.Toast("Cập nhật ảnh đại diện thành công");
                    //}
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }

    }
}
