using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Views;

namespace XamMobile.ViewModels.TienIch
{
    public class TinTucDetailPageViewModel : ViewModelBase
    {
        private string _ngayKetThuc;
        public string NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { SetProperty(ref _ngayKetThuc, value); }
        }
        private TinTucEntity _tinTuc;
        public TinTucEntity TinTuc
        {
            get { return _tinTuc; }
            set
            {
                _tinTuc = value;
                OnPropertyChanged(nameof(TinTuc));
            }
        }

        private string _textNoiBat;
        public string TextNoiBat
        {
            get { return _textNoiBat; }
            set { SetProperty(ref _textNoiBat, value); }
        }

        private bool _hasThanTinTuc;
        public bool HasThanTinTuc
        {
            get { return _hasThanTinTuc; }
            set { SetProperty(ref _hasThanTinTuc, value); }
        }
        private bool _hasAnhTinTuc;
        public bool HasAnhTinTuc
        {
            get { return _hasAnhTinTuc; }
            set { SetProperty(ref _hasAnhTinTuc, value); }
        }

        private bool _fromQuanLyTinTuc;
        public bool FromQuanLyTinTuc
        {
            get { return _fromQuanLyTinTuc; }
            set { SetProperty(ref _fromQuanLyTinTuc, value); }
        }

        public DelegateCommand DongTinTucDetailCommand { get; private set; }
        public DelegateCommand SuaTinTucDetailCommand { get; private set; }
        public DelegateCommand XoaTinTucDetailCommand { get; private set; }

        IUserService iUserService;
        ITinTucService iTinTucService;

        public TinTucDetailPageViewModel(INavigationService navigationService, IUserService iUserService, ITinTucService iTinTucService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iTinTucService = iTinTucService;
            DongTinTucDetailCommand = new DelegateCommand(() => { DongTinTucDetailPage(); });
            SuaTinTucDetailCommand = new DelegateCommand(() => { GotoSuaTinTucDetailPage(TinTuc); });
            XoaTinTucDetailCommand = new DelegateCommand(() => { XoaTinTucDetail(); });
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
            TinTuc = parameters.GetValue<TinTucEntity>("obj");
            FromQuanLyTinTuc = parameters.GetValue<bool>("fromquanlytintuc");
            LoadAllData();
        }

        public void LoadAllData()
        {
            //var tinTuc = await iTinTucService.GetAllTinTuc();
            NgayKetThuc = TinTuc.NgayKetThuc.HasValue ? TinTuc.NgayKetThuc.Value.ToString("MM/dd/yyyy") : "Không";
            TextNoiBat = TinTuc.IsNoiBat ? "Có" : "Không";
            HasThanTinTuc = !string.IsNullOrEmpty(TinTuc.TieuDeThan) && !string.IsNullOrEmpty(TinTuc.NoiDungThan);
            HasAnhTinTuc = !string.IsNullOrEmpty(TinTuc.TieuDeKet) && !string.IsNullOrEmpty(TinTuc.NoiDungKet);
        }

        public void DongTinTucDetailPage()
        {
            if (FromQuanLyTinTuc)
                GotoPage("TinTucPage");
            else
                GotoPage(nameof(CommonTabbedPage));
        }

        public async void GotoSuaTinTucDetailPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new TinTucEntity();
            navigationParamters.Add("obj", obj);
            navigationParamters.Add("fromquanlytintuc", FromQuanLyTinTuc);
            await NavigationService.NavigateAsync("TinTucSuaDetailPage", navigationParamters);
        }

        public async void XoaTinTucDetail()
        {
            bool choice = await App.Current.MainPage.DisplayAlert("Alert", "Xác nhận xóa tin tức?", "OK", "Hủy");
            if (choice)
            {
                var result = await iTinTucService.DeleteTinTuc(TinTuc.TinTucId);
                if (result)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Xóa tin tức thành công!", "OK");
                    UserDialogs.Instance.Toast("Xóa thành công!");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Xóa tin tức thất bại!", "OK");
                    UserDialogs.Instance.Toast("Xóa thất bại!");
                }
            }
            else
            {
                return;
            }
        }
    }
}
