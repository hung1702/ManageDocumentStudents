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


            // Services dependence injection
            //containerRegistry.Register<IBaseService, BaseService>();
            containerRegistry.RegisterSingleton<IHoSoService, HoSoService>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IVanBanService, VanBanService>();
            containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
            containerRegistry.RegisterSingleton<ILogService, LogService>();
            containerRegistry.RegisterSingleton<IUploadFileService, UploadFileService>();



            //
            containerRegistry.RegisterPopupNavigationService();
        }
    }
}
