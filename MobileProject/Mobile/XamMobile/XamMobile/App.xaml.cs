using Prism;
using Prism.Ioc;
using XamMobile.ViewModels;
using XamMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.Views.MasterDetail;
using Prism.Plugin.Popups;
using XamMobile.Services;
using XamMobile.ViewModels.NhanVien;
using XamMobile.Views.NhanVien;
using XamMobile.ViewModels.HoSo;
using XamMobile.Views.HoSo;
using XamMobile.Services.Interface;
using XamMobile.Views.Diem;
using XamMobile.ViewModels.Diem;
using XamMobile.Views.CongNo;
using XamMobile.ViewModels.CongNo;
using XamMobile.Views.ThuVien;
using XamMobile.ViewModels.ThuVien;
using XamMobile.ViewModels.TienIch;
using XamMobile.Views.TienIch;
using XamMobile.Views.VanBan;
using XamMobile.ViewModels.VanBan;
using XamMobile.Views.DichVu;
using XamMobile.ViewModels.DichVu;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamMobile
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<MenuPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<HomeMenuPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<HomeMenuPage, HomeMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<UserPage, UserPageViewModel>();
            containerRegistry.RegisterForNavigation<UserPopupPage, UserPopupPageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPopupPage, NotificationPopupPageViewModel>();
            containerRegistry.RegisterForNavigation<LogPage, LogViewModel>();
            containerRegistry.RegisterForNavigation<NhanVienPage, NhanVienPageViewModel>();
            containerRegistry.RegisterForNavigation<EditNhanVienPage, EditNhanVienPageViewModel>();
            containerRegistry.RegisterForNavigation<AddNhanVienPage, AddNhanVienPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailNhanVienPage, DetailNhanVienPageViewModel>();
            containerRegistry.RegisterForNavigation<HoSoPage, HoSoPageViewModel>();
            containerRegistry.RegisterForNavigation<AddHoSoPage, AddHoSoPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailHoSoPage, DetailHoSoPageViewModel>();

            containerRegistry.RegisterForNavigation<DiemMenuPage, DiemMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<ListDiemPage, ListDiemPageViewModel>();
            containerRegistry.RegisterForNavigation<DuKienDiemPopup, DuKienDiemPopupViewModel>();

            containerRegistry.RegisterForNavigation<GiaLapDiemPage, GiaLapDiemPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailDiemPage, DetailDiemPageViewModel>();

            containerRegistry.RegisterForNavigation<HocPhiPage, HocPhiPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuCongNoPage, MenuCongNoPageViewModel>();
            containerRegistry.RegisterForNavigation<KhoanChuaNopPage, KhoanChuaNopPageViewModel>();
            containerRegistry.RegisterForNavigation<KhoanDaNopPage, KhoanDaNopPageViewModel>();

            containerRegistry.RegisterForNavigation<LichSuThuVienPage, LichSuThuVienPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuThuVienPage, MenuThuVienPageViewModel>();

            containerRegistry.RegisterForNavigation<GioiThieuPage, GioiThieuPageViewModel>();
            containerRegistry.RegisterForNavigation<HuongDanPage, HuongDanPageViewModel>();
            containerRegistry.RegisterForNavigation<HuongDanSlidePage, HuongDanSlidePageViewModel>();
            containerRegistry.RegisterForNavigation<ListHuongDanPage, ListHuongDanPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuTienIchPage, MenuTienIchPageViewModel>();
            containerRegistry.RegisterForNavigation<TinTucPage, TinTucPageViewModel>();
            containerRegistry.RegisterForNavigation<QuetMaQRPage, QuetMaQRPageViewModel>();
            containerRegistry.RegisterForNavigation<TruyCapMapPage, TruyCapMapPageViewModel>();

            containerRegistry.RegisterForNavigation<LichSuVanBanPage, LichSuVanBanPageViewModel>();
            containerRegistry.RegisterForNavigation<LoaiVanBanPage, LoaiVanBanPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuVanBanPage, MenuVanBanPageViewModel>();
            containerRegistry.RegisterForNavigation<ThanhCongVanBanPopup, ThanhCongVanBanPopupViewModel>();
            containerRegistry.RegisterForNavigation<ThongBaoVanBanPopup, ThongBaoVanBanPopupViewModel>();
           
            containerRegistry.RegisterForNavigation<DichVuMenuPage, DichVuMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<BieuMauPage, BieuMauPageViewModel>();
            containerRegistry.RegisterForNavigation<LichSuDichVuPage, LichSuDichVuPageViewModel>();
            containerRegistry.RegisterForNavigation<QuyTrinhBieuMauPopUp, QuyTrinhBieuMauPopUpViewModel>();

            // Services dependence injection
            //containerRegistry.Register<IBaseService, BaseService>();
            containerRegistry.RegisterSingleton<IHoSoService, HoSoService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IVanBanService, VanBanService>();
            containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
            containerRegistry.RegisterSingleton<ILogService, LogService>();
            containerRegistry.RegisterSingleton<IUploadFileService, UploadFileService>();
            containerRegistry.RegisterSingleton<IDiemService, DiemService>();

            //
            containerRegistry.RegisterPopupNavigationService();
        }
    }
}
