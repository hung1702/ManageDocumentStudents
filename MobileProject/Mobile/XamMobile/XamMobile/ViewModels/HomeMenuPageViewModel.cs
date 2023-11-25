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

        public DelegateCommand GotoUserInfoPageCommand { get; private set; }
        public DelegateCommand GotoLogPageCommand { get; private set; }
        public DelegateCommand GotoNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoHoSoPageCommand { get; private set; }
        public DelegateCommand GotoDiemMenuPageCommand { get; private set; }
        public DelegateCommand GotoMenuTienIchPageCommand { get; private set; }
        public DelegateCommand GotoThuVienMenuPageCommand { get; private set; }
        public DelegateCommand GotoCongNoMenuPageCommand { get; private set; }
        public DelegateCommand GotoDichVuMenuPageCommand { get; private set; }

        //INotificationService iNotificationService;
        IHoSoService hoSoService;

        public HomeMenuPageViewModel(INavigationService navigationService, IHoSoService hoSoService) : base(navigationService)
        {
            this.hoSoService = hoSoService;
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
                //var notificationResults = (await hoSoService.GetDSHoSo()).OrderBy(x => x.TrangThai);
                //if (notificationResults == null)
                //{
                //    UserDialogs.Instance.Alert("Có lỗi khi tải thông báo");
                //    return;
                //}
                //Notifications.Clear();
                //foreach (var item in notificationResults)
                //{
                //    Notifications.Add(item);
                //}
                //Console.WriteLine("");
            }
        }

        public async void OpenUserPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("NotificationPopupPage", navigationParamters);
        }
    }
}
