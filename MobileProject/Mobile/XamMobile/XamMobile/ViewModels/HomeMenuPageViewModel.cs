using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services;
using XamMobile.Services.Interface;
using XamMobile.Views;

namespace XamMobile.ViewModels
{
    public class HomeMenuPageViewModel : ViewModelBase
    {
        private ObservableCollection<HoSoEntity> _notifications;
        public ObservableCollection<HoSoEntity> Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }

        private List<TinTucEntity> _listTinTuc;
        public List<TinTucEntity> ListTinTuc
        {
            get { return _listTinTuc; }
            set
            {
                _listTinTuc = value;
                OnPropertyChanged(nameof(ListTinTuc));
            }
        }

        private List<TinTucEntity> _dataTinTucList;
        public List<TinTucEntity> DataTinTucList
        {
            get { return _dataTinTucList; }
            set
            {
                _dataTinTucList = value;
                OnPropertyChanged(nameof(DataTinTucList));
                OnPropertyChanged(nameof(HasDataAll));
                OnPropertyChanged(nameof(IsNoDataAll));
            }
        }

        public bool HasDataAll => DataTinTucList != null && DataTinTucList.Count > 0;
        public bool IsNoDataAll => !HasDataAll;


        public DelegateCommand GotoUserInfoPageCommand { get; private set; }
        public DelegateCommand GotoLogPageCommand { get; private set; }
        public DelegateCommand GotoNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoHoSoPageCommand { get; private set; }
        public DelegateCommand GotoDiemMenuPageCommand { get; private set; }
        public DelegateCommand GotoMenuTienIchPageCommand { get; private set; }
        public DelegateCommand GotoThuVienMenuPageCommand { get; private set; }
        public DelegateCommand GotoCongNoMenuPageCommand { get; private set; }
        public DelegateCommand GotoDichVuMenuPageCommand { get; private set; }
        public DelegateCommand GotoTinTucPageCommand { get; private set; }

        //INotificationService iNotificationService;
        IHoSoService hoSoService;
        ITinTucService iTinTucService;
        IUserService iUserService;

        public HomeMenuPageViewModel(INavigationService navigationService, IHoSoService hoSoService, ITinTucService iTinTucService, IUserService iUserService) : base(navigationService)
        {
            this.hoSoService = hoSoService;
            this.iTinTucService = iTinTucService;
            this.iUserService = iUserService;
            Notifications = new ObservableCollection<HoSoEntity>();

            GotoUserInfoPageCommand = new DelegateCommand(() => { GotoPage("UserPage"); });
            GotoLogPageCommand = new DelegateCommand(() => { GotoPage("LogPage"); });
            GotoNhanVienPageCommand = new DelegateCommand(() => { GotoPage("NhanVienPage"); });
            GotoHoSoPageCommand = new DelegateCommand(() => { GotoPage("HoSoPage"); });
            GotoDiemMenuPageCommand = new DelegateCommand(() => { GotoPage("DiemMenuPage"); });
            GotoMenuTienIchPageCommand = new DelegateCommand(() => { GotoPage("MenuTienIchPage"); });
            //GotoThuVienMenuPageCommand = new DelegateCommand(() => { GotoPage("MenuThuVienPage"); });
            GotoThuVienMenuPageCommand = new DelegateCommand(() => { GotoPage("LichSuThuVienPage"); });
            GotoCongNoMenuPageCommand = new DelegateCommand(() => { GotoPage("MenuCongNoPage"); });
            GotoDichVuMenuPageCommand = new DelegateCommand(() => { GotoPage("DichVuMenuPage"); });
            GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });

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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        private async void LoadAllData()
        {
            using (UserDialogs.Instance.Loading("Đang tải"))
            {

            }
            LoadAllTinTucData();
        }

        public async void LoadAllTinTucData()
        {
            try
            {
                var tinTuc = await iTinTucService.GetAllTinTuc();
                DataTinTucList = tinTuc.Where(x => x.IsActive).ToList();
                ListTinTuc = DataTinTucList.Where(x => x.IsNoiBat).ToList();
                if(ListTinTuc == default || ListTinTuc.Count == 0)
                    ListTinTuc = DataTinTucList.OrderBy(x => x.NgayTao).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void GotoTinTucDetailPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new TinTucEntity();
            //var fromHomePage = true;
            navigationParamters.Add("obj", obj);
            //navigationParamters.Add("fromhomepage", fromHomePage);
            await NavigationService.NavigateAsync("TinTucDetailPage", navigationParamters);
        }

        public async void OpenUserPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("NotificationPopupPage", navigationParamters);
        }
    }
}
