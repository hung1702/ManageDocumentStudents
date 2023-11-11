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
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.NhanVien
{
    public class DetailNhanVienPageViewModel : ViewModelBase
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

        IPermissionService _permissionService;
        DownloadService downloadService { get; set; }
        IFileService _fileService;
        IUserService iUserService;
        IUploadFileService iUploadFileService;
        public DelegateCommand UpdatePictureCommand { get; private set; }
        public DelegateCommand DeleteNhanVienCommand { get; private set; }


        public DetailNhanVienPageViewModel(INavigationService navigationService, IUserService iUserService, IUploadFileService iUploadFileService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iUploadFileService = iUploadFileService;
            UserInfoModel = UserInfoSetting.UserInfos;
            //ActionDatasource = new ObservableCollection<string>(new List<string>() { "Chỉnh sửa", "Xóa" });
            _permissionService = Xamarin.Forms.DependencyService.Get<DependencyServices.IPermissionService>();
            _fileService = Xamarin.Forms.DependencyService.Get<DependencyServices.IFileService>();
            downloadService = new DownloadService(_permissionService, _fileService);
            UpdatePictureCommand = new DelegateCommand(async () => { await UpdatePicture(); });
            MessagingCenter.Unsubscribe<App, NhanVienEntity>((App)Application.Current, "UpdateNhanVien");
            MessagingCenter.Subscribe<App, NhanVienEntity>((App)Application.Current, "UpdateNhanVien", (o, serverItem) =>
            {
                try
                {
                    if (serverItem != null)
                    {
                        UserInfoSetting.UserInfos = serverItem;
                        NgayCapFormat = serverItem.NgayCapFormat;
                        NgaySinhFormat = serverItem.NgaySinhFormat;
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert("Lỗi cập nhật ui");
                }
            });

            DeleteNhanVienCommand = new DelegateCommand(async () => { await DeleteNhanVien(); });
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

                var imageRes = await iUploadFileService.UploadFile(new Services.Models.FileUploaded() { FileName = fileName, Content = contents });
                if (!string.IsNullOrEmpty(imageRes))
                {
                    CurrentData.AnhDaiDien = imageRes.Replace("\"", "");
                    var updateAvatar = await iUserService.SaveNhanVien(CurrentData);
                    if (!string.IsNullOrEmpty(updateAvatar.AnhDaiDien))
                    {
                        ImageSourceAvatar = string.IsNullOrEmpty(CurrentData.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{CurrentData.AnhDaiDien}");
                        UserDialogs.Instance.Toast("Cập nhật ảnh đại diện thành công");
                    }
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            CurrentData = parameters.GetValue<NhanVienEntity>("obj");

            base.OnNavigatedTo(parameters);
            NgaySinhFormat = CurrentData.NgaySinhFormat;
            NgayCapFormat = CurrentData.NgayCapFormat;
            LoadAllData();
        }

        public async void LoadAllData()
        {
            try
            {
                using (UserDialogs.Instance.Loading("Đang tải"))
                {
                    ImageSourceAvatar = string.IsNullOrEmpty(CurrentData.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{CurrentData.AnhDaiDien}");
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

        private async Task DeleteNhanVien()
        {
            try
            {
                var choose = await App.Current.MainPage.DisplayAlert("Alert", "Bạn có chắc chắn muốn xóa không?", "Yes", "No");
                if (choose)
                {
                    var nhanVien = CurrentData;
                    var result = await iUserService.DeleteNhanVien(nhanVien);
                    //var result = true;
                    if (result)
                    {
                        UserDialogs.Instance.Toast("Deleted");
                        await App.Current.MainPage.DisplayAlert("Alert", "Deleted successfully!", "OK");

                        var navigationParamters = new NavigationParameters();
                        await NavigationService.NavigateAsync("NhanVienPage", navigationParamters);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Deletion failed!", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Can not delete this employee!" + ex.ToString());
            }
        }

    }
}
