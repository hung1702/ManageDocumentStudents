using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services;
using XamMobile.Services.Interface;
using XamMobile.Views;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.TabbedPage
{
    public partial class HomeMenuPageViewModel : ViewModelBase
    {
        IHoSoService hoSoService;
        ITinTucService iTinTucService;
        IUserService iUserService;

        public CaNhanTabbedPage CurrentPage { get; set; }

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

        //HomeMenuPage

        public DelegateCommand GotoUserInfoPageCommand { get; private set; }
        public DelegateCommand GotoLogPageCommand { get; private set; }
        public DelegateCommand GotoNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoHoSoPageCommand { get; private set; }
        public DelegateCommand GotoDiemMenuPageCommand { get; private set; }
        public DelegateCommand GotoMenuTienIchPageCommand { get; private set; }
        public DelegateCommand GotoThuVienMenuPageCommand { get; private set; }
        public DelegateCommand GotoCongNoMenuPageCommand { get; private set; }
        public DelegateCommand GotoDichVuMenuPageCommand { get; private set; }

        //HocTap
        public DelegateCommand GotoListDiemPageCommand { get; private set; }
        public DelegateCommand GotoGiaLapDiemPageCommand { get; private set; }

        //DichVu
        public DelegateCommand GotoLoaiBieuMauPageCommand { get; private set; }
        public DelegateCommand GotoLichSuDichVuPageCommand { get; private set; }

        public DelegateCommand GotoHocPhiPageCommand { get; private set; }
        public DelegateCommand GotoKhoanDaNopPageCommand { get; private set; }
        public DelegateCommand GotoKhoanChuaNopPageCommand { get; private set; }

        public DelegateCommand GotoTimKiemSachPageCommand { get; private set; }
        public DelegateCommand GotoLichSuMuonPageCommand { get; private set; }

        //TienIch
        public DelegateCommand GotoListHuongDanPageCommand { get; private set; }
        public DelegateCommand GotoGioiThieuPageCommand { get; private set; }
        public DelegateCommand GotoTinTucPageCommand { get; private set; }
        public DelegateCommand GotoQuetMaQRPageCommand { get; private set; }
        public DelegateCommand GotoTruyCapMapPageCommand { get; private set; }
        public DelegateCommand GotoHuongDanPageCommand { get; private set; }
        public DelegateCommand GotoHuongDanSlidePageCommand { get; private set; }

        //CaNhan
        public DelegateCommand GotoTrangCaNhanPageCommand { get; private set; }
        public DelegateCommand GotoLogoutCommand { get; private set; }
        public DelegateCommand GotoTouchPageCommand { get; private set; }
        public DelegateCommand GotoLogoutPopUpCommand { get; private set; }


        public HomeMenuPageViewModel(INavigationService navigationService, IHoSoService hoSoService, ITinTucService iTinTucService, IUserService iUserService) : base(navigationService)
        {
            this.hoSoService = hoSoService;
            this.iTinTucService = iTinTucService;
            this.iUserService = iUserService;

            Notifications = new ObservableCollection<HoSoEntity>();

            //HomeMenuPage
            GotoUserInfoPageCommand = new DelegateCommand(() => { GotoPage("CaNhanMenuPage"); });
            GotoLogPageCommand = new DelegateCommand(() => { GotoPage("LogPage"); });
            GotoNhanVienPageCommand = new DelegateCommand(() => { GotoPage("NhanVienPage"); });
            GotoHoSoPageCommand = new DelegateCommand(() => { GotoPage("HoSoPage"); });
            GotoDiemMenuPageCommand = new DelegateCommand(() => { GotoPage("DiemMenuPage"); });
            GotoMenuTienIchPageCommand = new DelegateCommand(() => { GotoPage("MenuTienIchPage"); });
            GotoThuVienMenuPageCommand = new DelegateCommand(() => { GotoPage("LichSuThuVienPage"); });
            GotoCongNoMenuPageCommand = new DelegateCommand(() => { GotoPage("MenuCongNoPage"); });
            GotoDichVuMenuPageCommand = new DelegateCommand(() => { GotoPage("DichVuMenuPage"); });

            //HocTap
            GotoListDiemPageCommand = new DelegateCommand(() => { GotoPage("ListDiemPage"); });
            //GotoListDiemPageCommand = new DelegateCommand(() => { GotoPage("DetailDiemPage"); });
            GotoGiaLapDiemPageCommand = new DelegateCommand(() => { GotoPage("GiaLapDiemPage"); });

            //DichVu
            GotoLoaiBieuMauPageCommand = new DelegateCommand(() => { GotoPage("LoaiBieuMauPage"); });
            GotoLichSuDichVuPageCommand = new DelegateCommand(() => { GotoPage("LichSuDichVuPage"); });
            GotoHocPhiPageCommand = new DelegateCommand(() => { GotoPage("HocPhiPage"); });
            GotoKhoanDaNopPageCommand = new DelegateCommand(() => { GotoPage("KhoanDaNopPage"); });
            GotoKhoanChuaNopPageCommand = new DelegateCommand(() => { GotoPage("KhoanChuaNopPage"); });
            GotoTimKiemSachPageCommand = new DelegateCommand(() => { GotoPage("TimKiemThuVienPage"); });
            GotoLichSuMuonPageCommand = new DelegateCommand(() => { GotoPage("LichSuThuVienPage"); });

            //TienIch
            GotoListHuongDanPageCommand = new DelegateCommand(() => { GotoPage("ListHuongDanPage"); });
            GotoGioiThieuPageCommand = new DelegateCommand(() => { GotoPage("GioiThieuPage"); });
            GotoQuetMaQRPageCommand = new DelegateCommand(() => { GotoPage("QuetMaQRPage"); });
            GotoTruyCapMapPageCommand = new DelegateCommand(() => { GotoPage("TruyCapMapPage"); });
            GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });
            GotoHuongDanPageCommand = new DelegateCommand(() => { GotoPage("HuongDanPage"); });
            GotoHuongDanSlidePageCommand = new DelegateCommand(() => { GotoPage("HuongDanSlidePage"); });

            //CaNhan
            GotoTrangCaNhanPageCommand = new DelegateCommand(() => { GotoPage(nameof(UserPage)); });
            GotoTouchPageCommand = new DelegateCommand(() => { GotoPage(nameof(VanTayPopUp)); });
            GotoLogoutCommand = new DelegateCommand(async () => { await LogOut(navigationService); });
            GotoLogoutPopUpCommand = new DelegateCommand(() => { GotoPage(nameof(LogOutPopUp)); });

            LoadAllData();
        }

        public async Task LogOut(INavigationService navigationService)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();

        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            NavigationService.NavigateAsync(page);
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
                ListTinTuc = DataTinTucList.Where(x => x.IsNoiBat).OrderBy(x => x.NgayTao).ToList();
                if (ListTinTuc == default || ListTinTuc.Count == 0)
                    ListTinTuc = DataTinTucList.OrderBy(x => x.NgayTao).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void GotoTinTucDetailPage(object obj = null)
        {
            var navigationParamters = new Prism.Navigation.NavigationParameters();
            if (obj == null)
                obj = new TinTucEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("TinTucDetailPage", navigationParamters);
        }

        public async void OpenUserPopUp(object obj = null)
        {
            var navigationParamters = new Prism.Navigation.NavigationParameters();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("NotificationPopupPage", navigationParamters);
        }
    }
}
