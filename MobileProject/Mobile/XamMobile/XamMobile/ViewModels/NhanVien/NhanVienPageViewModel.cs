using Acr.UserDialogs;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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
    public class NhanVienPageViewModel : ViewModelBase
    {
        private ObservableCollection<string> _actionDatasource;
        public ObservableCollection<string> ActionDatasource
        {
            get { return _actionDatasource; }
            set { SetProperty(ref _actionDatasource, value); }
        }
        public UserPage CurrentPage { get; set; }


        private List<NhanVienEntity> _listNhanVien;
        public List<NhanVienEntity> ListNhanVien
        {
            get { return _listNhanVien; }
            set { SetProperty(ref _listNhanVien, value); }
        }

        public List<string> SortByList { get; set; }

        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
        }

        //private NhanVienEntity _userInfoModel;
        //public NhanVienEntity UserInfoModel
        //{
        //    get { return _userInfoModel; }
        //    set { SetProperty(ref _userInfoModel, value); }
        //}

        //private string _ngayCapFormat;
        //public string NgayCapFormat
        //{
        //    get { return _ngayCapFormat; }
        //    set { SetProperty(ref _ngayCapFormat, value); }
        //}

        //private string _ngaySinhFormat;
        //public string NgaySinhFormat
        //{
        //    get { return _ngaySinhFormat; }
        //    set { SetProperty(ref _ngaySinhFormat, value); }
        //}


        //private ImageSource _imageSource;
        //public ImageSource ImageSourceAvatar
        //{
        //    get { return _imageSource; }
        //    set { SetProperty(ref _imageSource, value); }
        //}

        IPermissionService _permissionService;
        DownloadService downloadService { get; set; }
        IFileService _fileService;
        IUserService iUserService;
        IUploadFileService iUploadFileService;
        public DelegateCommand UpdatePictureCommand { get; private set; }
        public DelegateCommand GotoAddNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoEditNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoDetailNhanVienPageCommand { get; private set; }

        public NhanVienPageViewModel(INavigationService navigationService, IUserService iUserService, IUploadFileService iUploadFileService) : base(navigationService)
        {
            SortByList = new List<string> { "NVID", "Name" };
            this.iUserService = iUserService;
            this.iUploadFileService = iUploadFileService;
            //UserInfoModel = UserInfoSetting.UserInfos;
            //ActionDatasource = new ObservableCollection<string>(new List<string>() { "Chỉnh sửa", "Xóa" });

            GotoAddNhanVienPageCommand = new DelegateCommand(() => { GotoPage("AddNhanVienPage"); });
            GotoEditNhanVienPageCommand = new DelegateCommand(() => { GotoPage("EditNhanVienPage"); });
            GotoDetailNhanVienPageCommand = new DelegateCommand(() => { GotoPage("DetailNhanVienPage"); });

            _permissionService = DependencyService.Get<IPermissionService>();
            _fileService = DependencyService.Get<IFileService>();

            //downloadService = new DownloadService(_permissionService, _fileService);
            //UpdatePictureCommand = new DelegateCommand(async () => { await UpdatePicture(); });
            //MessagingCenter.Unsubscribe<App, NhanVienEntity>((App)Application.Current, "UpdateNhanVien");
            //MessagingCenter.Subscribe<App, NhanVienEntity>((App)Application.Current, "UpdateNhanVien", (o, serverItem) =>
            //{
            //    try
            //    {
            //        if (serverItem != null)
            //        {
            //            UserInfoSetting.UserInfos = serverItem;
            //            NgayCapFormat = serverItem.NgayCapFormat;
            //            NgaySinhFormat = serverItem.NgaySinhFormat;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        UserDialogs.Instance.Alert("Lỗi cập nhật ui");
            //    }
            //});
            ListNhanVien = new List<NhanVienEntity>();
        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            await NavigationService.NavigateAsync(page);
        }
        //private async Task UpdatePicture()
        //{
        //    try
        //    {
        //        await _permissionService.RequestExternalPermssion();

        //        var fileData = await CrossFilePicker.Current.PickFile();
        //        if (fileData == null)
        //            return; // user canceled file picking
        //        var fileName = fileData.FileName;
        //        var contents = fileData.DataArray;

        //        var imageRes = await iUploadFileService.UploadFile(new Services.Models.FileUploaded() { FileName = fileName, Content = contents });
        //        if (!string.IsNullOrEmpty(imageRes))
        //        {
        //            UserInfoSetting.UserInfos.AnhDaiDien = imageRes.Replace("\"", "");
        //            var updateAvatar = await iUserService.SaveNhanVien(UserInfoSetting.UserInfos);
        //            if (!string.IsNullOrEmpty(updateAvatar.AnhDaiDien))
        //            {
        //                ImageSourceAvatar = string.IsNullOrEmpty(UserInfoSetting.UserInfos.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{UserInfoSetting.UserInfos.AnhDaiDien}");
        //                UserDialogs.Instance.Toast("Cập nhật ảnh đại diện thành công");
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine("Exception choosing file: " + ex.ToString());
        //    }
        //}
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoadAllData();
        }

        private async void LoadAllData()
        {
            try
            {
                using (UserDialogs.Instance.Loading("Đang tải"))
                {
                    //NgayCapFormat = UserInfoSetting.UserInfos.NgayCapFormat;
                    //NgaySinhFormat = UserInfoSetting.UserInfos.NgaySinhFormat;
                    //ImageSourceAvatar = string.IsNullOrEmpty(UserInfoSetting.UserInfos.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{UserInfoSetting.UserInfos.AnhDaiDien}");
                    //var nhanVienRes = await iUserService.GetNhanVien(UserInfoSetting.UserInfos.NhanVienID);
                    //if (nhanVienRes == null)
                    //{
                    //    UserDialogs.Instance.Alert("Có lỗi khi tải thông tin nhân viên");
                    //    return;
                    //}

                    var nhanViens = await iUserService.GetNhanViens();
                    if (nhanViens == null || !nhanViens.Any())
                    {
                        UserDialogs.Instance.Alert("Có lỗi khi tải thông tin nhân viên");
                        return;
                    }
                    ListNhanVien = nhanViens;
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async void OpenPopUpAddNhanVien(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new NhanVienEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("DetailNhanVienPage", navigationParamters);
        }

        private async Task DeleteNhanVien(int id)
        {
            try
            {
                var nhanVien = ListNhanVien.FirstOrDefault(x => x.NhanVienID == id);
                var result = await iUserService.DeleteNhanVien(nhanVien);
                if (result)
                    UserDialogs.Instance.Toast("Xoa nhan vien thanh cong");
                else
                    UserDialogs.Instance.Toast("Xoa nhan vien khong thanh cong");
            }
            catch (Exception ex)
            {
                throw new Exception("Khong xoa duoc nhan vien");
            }

        }

        private async Task ThemNhanVien()
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw new Exception("Khong tao duoc nhan vien");
            }


            //try
            //{
            //    await _permissionService.RequestExternalPermssion();

            //    var fileData = await CrossFilePicker.Current.PickFile();
            //    if (fileData == null)
            //        return; // user canceled file picking
            //    var fileName = fileData.FileName;
            //    var contents = fileData.DataArray;

            //    var imageRes = await iUploadFileService.UploadFile(new Services.Models.FileUploaded() { FileName = fileName, Content = contents });
            //    if (!string.IsNullOrEmpty(imageRes))
            //    {
            //        UserInfoSetting.UserInfos.AnhDaiDien = imageRes.Replace("\"", "");
            //        var updateAvatar = await iUserService.SaveNhanVien(UserInfoSetting.UserInfos);
            //        if (!string.IsNullOrEmpty(updateAvatar.AnhDaiDien))
            //        {
            //            ImageSourceAvatar = string.IsNullOrEmpty(UserInfoSetting.UserInfos.AnhDaiDien) ? null : await downloadService.DownloadFileIntoMemory($"{AppConstant.AppConstant.Endpoint}{AppConstant.AppConstant.APIGetImage}{UserInfoSetting.UserInfos.AnhDaiDien}");
            //            UserDialogs.Instance.Toast("Cập nhật ảnh đại diện thành công");
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            //}
        }

        public void SortById()
        {
            ListNhanVien = ListNhanVien.OrderBy(nv => nv.NhanVienID).ToList();
        }

        public void SortByName()
        {
            ListNhanVien = ListNhanVien.OrderBy(nv => nv.TenNhanVien).ToList();
        }
    }
}
