using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Services;
using XamMobile.Views.MasterDetail;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.HoSo
{
    public class HoSoPageViewModel : ViewModelBase
    {
        private ObservableCollection<string> _actionDatasource;
        public ObservableCollection<string> ActionDatasource
        {
            get { return _actionDatasource; }
            set { SetProperty(ref _actionDatasource, value); }
        }
        public UserPage CurrentPage { get; set; }


        //private List<NhanVienEntity> _listNhanVien;
        //public List<NhanVienEntity> ListNhanVien
        //{
        //    get { return _listNhanVien; }
        //    set { SetProperty(ref _listNhanVien, value); }
        //}

        //public List<string> SortByList { get; set; }

        //private List<string> _selectedSortBy;
        //public List<string> SelectedSortBy
        //{
        //    get { return _selectedSortBy; }
        //    set { SetProperty(ref _selectedSortBy, value); }
        //}

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
        private ObservableCollection<HoSoEntity> _hoSoList;
        public ObservableCollection<HoSoEntity> HoSoList
        {
            get { return _hoSoList; }
            set { SetProperty(ref _hoSoList, value); }
        }

        IHoSoService hoSoService;
        IPermissionService _permissionService;
        DownloadService downloadService { get; set; }
        IFileService _fileService;
        IUserService iUserService;
        IUploadFileService iUploadFileService;
        public DelegateCommand UpdatePictureCommand { get; private set; }
        public DelegateCommand GotoAddNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoEditNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoDetailNhanVienPageCommand { get; private set; }

        public HoSoPageViewModel(INavigationService navigationService,
            IHoSoService hoSoService) : base(navigationService)
        {
            this.hoSoService = hoSoService;
            HoSoList = new ObservableCollection<HoSoEntity>();

            //SortByList = new List<string> { "NVID", "Name" };
            //this.iUserService = iUserService;
            //this.iUploadFileService = iUploadFileService;
            ////UserInfoModel = UserInfoSetting.UserInfos;
            ////ActionDatasource = new ObservableCollection<string>(new List<string>() { "Chỉnh sửa", "Xóa" });

            //GotoAddNhanVienPageCommand = new DelegateCommand(() => { GotoPage("AddNhanVienPage"); });
            //GotoEditNhanVienPageCommand = new DelegateCommand(() => { GotoPage("EditNhanVienPage"); });
            //GotoDetailNhanVienPageCommand = new DelegateCommand(() => { GotoPage("DetailNhanVienPage"); });

            //_permissionService = DependencyService.Get<IPermissionService>();
            //_fileService = DependencyService.Get<IFileService>();

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
            //ListNhanVien = new List<NhanVienEntity>();
            LoadAllData();
        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            await NavigationService.NavigateAsync(page);
        }

        private async void LoadAllData()
        {
            using (UserDialogs.Instance.Loading("Đang tải"))
            {
                var hoSoResults = (await hoSoService.GetDSHoSo());
                if (hoSoResults == null)
                {
                    UserDialogs.Instance.Alert("Có lỗi khi tải Data");
                    return;
                }
                HoSoList.Clear();
                foreach (var item in hoSoResults)
                {
                    HoSoList.Add(item);
                }
            }
        }
        
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }


        public async void OpenPopUpAddNhanVien(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new NhanVienEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("DetailNhanVienPage", navigationParamters);
        }

        public async void OpenHoSoPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("DetailHoSoPage", navigationParamters);
        }
        //public void SortById()
        //{
        //    ListNhanVien = ListNhanVien.OrderBy(nv => nv.NhanVienID).ToList();
        //}

        //public void SortByName()
        //{
        //    ListNhanVien = ListNhanVien.OrderBy(nv => nv.TenNhanVien).ToList();
        //}
    }
}
