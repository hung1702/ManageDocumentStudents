

namespace XamMobile.ViewModels.TabbedPage
{
    public partial class HomeMenuPageViewModel
    {

        //public CaNhanTabbedPage CurrentPage { get; set; }

        //public ObservableCollection<MyMenuItem> MenuItems { get; set; }

        //private MyMenuItem selectedMenuItem;
        //public MyMenuItem SelectedMenuItem
        //{
        //    get => selectedMenuItem;
        //    set => SetProperty(ref selectedMenuItem, value);
        //}

        //public DelegateCommand NavigateCommand { get; private set; }

        //public void LoadCaNhanPageViewModel(INavigationService navigationService)
        //{
        //    MenuItems = new ObservableCollection<MyMenuItem>();

        //    MenuItems.Add(new MyMenuItem()
        //    {
        //        Icon = "home_icon_red.png",
        //        PageName = nameof(HomeMenuPage),
        //        Title = "Trang chủ"
        //    });

        //    MenuItems.Add(new MyMenuItem()
        //    {
        //        Icon = "conference_red_icon.png",
        //        PageName = nameof(UserPage),
        //        Title = "Tài khoản"
        //    });

        //    MenuItems.Add(new MyMenuItem()
        //    {
        //        Icon = "logout_icon_red.png",
        //        PageName = "Logout",
        //        Title = "Đăng xuất"
        //    });

        //    NavigateCommand = new DelegateCommand(Navigate);
        //}

        //async void Navigate()
        //{
        //    if (SelectedMenuItem == null)
        //        return;
        //    var pageName = SelectedMenuItem.PageName;
        //    if (pageName == "Logout")
        //    {
        //        await CurrentPage.Navigation.PopToRootAsync(true);
        //    }
        //    //await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + pageName);
        //    await _navigationService.NavigateAsync(nameof(pageName));
        //    SelectedMenuItem = null;
        //}



        //IUserService iUserService;

        //public DelegateCommand GotoListHuongDanPageCommand { get; private set; }
        //public DelegateCommand GotoGioiThieuPageCommand { get; private set; }
        //public DelegateCommand GotoTinTucPageCommand { get; private set; }
        //public DelegateCommand GotoQuetMaQRPageCommand { get; private set; }
        //public DelegateCommand GotoTruyCapMapPageCommand { get; private set; }

        //public CaNhanTabbedPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        //{
        //    this.iUserService = iUserService;
        //    GotoListHuongDanPageCommand = new DelegateCommand(() => { GotoPage("ListHuongDanPage"); });
        //    GotoGioiThieuPageCommand = new DelegateCommand(() => { GotoPage("GioiThieuPage"); });
        //    GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });
        //    GotoQuetMaQRPageCommand = new DelegateCommand(() => { GotoPage("QuetMaQRPage"); });
        //    GotoTruyCapMapPageCommand = new DelegateCommand(() => { GotoPage("TruyCapMapPage"); });
        //}

        //public void GotoPage(string page)
        //{
        //    NavigatetoPage(page);
        //}

        //public async void NavigatetoPage(string page)
        //{
        //    await NavigationService.NavigateAsync(page);
        //}

        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);
        //}
    }
}
