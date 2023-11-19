using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.Diem
{
    public class DiemMenuPageViewModel : ViewModelBase
    {
        private ObservableCollection<HoSoEntity> _notifications;
        public ObservableCollection<HoSoEntity> Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }

        public DelegateCommand GotoListDiemPageCommand { get; private set; }
        public DelegateCommand GotoGiaLapDiemPageCommand { get; private set; }


        //INotificationService iNotificationService;
        IDiemService iDiemService;

        public DiemMenuPageViewModel(INavigationService navigationService, IDiemService iDiemService) : base(navigationService)
        {
            this.iDiemService = iDiemService;

            GotoListDiemPageCommand = new DelegateCommand(() => { GotoPage("ListDiemPage"); });
            //GotoListDiemPageCommand = new DelegateCommand(() => { GotoPage("DetailDiemPage"); });
            GotoGiaLapDiemPageCommand = new DelegateCommand(() => { GotoPage("GiaLapDiemPage"); });
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
        }

        public async void OpenUserPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("NotificationPopupPage", navigationParamters);
        }
    }
}
