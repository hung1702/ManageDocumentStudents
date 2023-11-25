using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.ThuVien
{
    public class LichSuThuVienPageViewModel : ViewModelBase
    {
        private DateTime _ngayBatDau;
        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
            set { SetProperty(ref _ngayBatDau, value); }
        }

        private DateTime _ngayKetThuc;
        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { SetProperty(ref _ngayKetThuc, value); }
        }

        private List<string> _selectedItem;
        public List<string> SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
        private bool _isNoResult;
        public bool IsNoResult
        {
            get { return _isNoResult; }
            set { SetProperty(ref _isNoResult, value); }
        }
        public ICommand TimKiemCommand { get; private set; }

        IUserService iUserService;

        public LichSuThuVienPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            SelectedItem = new List<string> { "Cả ngày", "Sáng", "Chiều" };
            this.iUserService = iUserService;
            NgayBatDau = DateTime.Now.AddDays(-7);
            NgayKetThuc = DateTime.Now;
            TimKiemCommand = new Command(TimKiem);
            IsNoResult = false;
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

        private void TimKiem()
        {
            IsNoResult = true;
            //GotoPage("MenuTienIchPage");
        }
        public void ChonCaNgay()
        {
        }
        public void ChonSang()
        {
        }
        public void ChonChieu()
        {
        }
    }
}
