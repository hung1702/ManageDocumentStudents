using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class TinTucSuaDetailPageViewModel : ViewModelBase
    {
        private TinTucEntity _tinTucCurrent;
        public TinTucEntity TinTucCurrent
        {
            get { return _tinTucCurrent; }
            set { SetProperty(ref _tinTucCurrent, value); }
        }

        private TinTucEntity _tinTucData;
        public TinTucEntity TinTucData
        {
            get { return _tinTucData; }
            set { SetProperty(ref _tinTucData, value); }
        }

        private bool _isValidate;
        public bool IsValidate
        {
            get { return _isValidate; }
            set { SetProperty(ref _isValidate, value); }
        }

        private bool? _selectedNoiBat;
        public bool? SelectedNoiBat
        {
            get { return _selectedNoiBat; }
            set { SetProperty(ref _selectedNoiBat, value); }
        }

        private DateTime _currentDate;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
        }

        private bool _fromQuanLyTinTuc;
        public bool FromQuanLyTinTuc
        {
            get { return _fromQuanLyTinTuc; }
            set { SetProperty(ref _fromQuanLyTinTuc, value); }
        }

        public DelegateCommand SaveTinTucCommand { get; private set; }
        public DelegateCommand HuyTinTucCommand { get; private set; }

        IUserService iUserService;
        ITinTucService iTinTucService;

        public TinTucSuaDetailPageViewModel(INavigationService navigationService, IUserService iUserService, ITinTucService iTinTucService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iTinTucService = iTinTucService;
            TinTucCurrent = new TinTucEntity();
            SaveTinTucCommand = new DelegateCommand(async () => { await SaveTinTucAsync(); });
            HuyTinTucCommand = new DelegateCommand(async () => {await GotoTinTucDetailPage(TinTucData); });
            CurrentDate = DateTime.Now.AddDays(1);
            SelectedSortBy = new List<string> { "Có", "Không" };
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
            TinTucData = parameters.GetValue<TinTucEntity>("obj");
            TinTucCurrent = TinTucData;
            FromQuanLyTinTuc = parameters.GetValue<bool>("fromquanlytintuc");
        }

        public async Task SaveTinTucAsync()
        {
            try
            {
                if (TinTucCurrent == null || TinTucCurrent == default)
                    throw new Exception("Co loi khi tai du lieu!");
                if (string.IsNullOrEmpty(TinTucCurrent.Ten)
                    || string.IsNullOrEmpty(TinTucCurrent.TieuDeMo)
                    || string.IsNullOrEmpty(TinTucCurrent.NoiDungMo)
                    || SelectedNoiBat == null)
                {
                    IsValidate = true;
                    return;
                }
                var entity = TinTucCurrent;
                entity.NgayTao = DateTime.Now;
                entity.IsActive = true;

                var res = await iTinTucService.InsertOrUpdateTinTuc(entity);
                if (res != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Sửa tin tức thành công!", "OK");
                    UserDialogs.Instance.Toast("Lưu thành công");
                    await GotoTinTucDetailPage(res);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Sửa tin tức thất bại!", "OK");
                    UserDialogs.Instance.Toast("Lưu thất bại!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task GotoTinTucDetailPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new TinTucEntity();
            navigationParamters.Add("obj", obj);
            navigationParamters.Add("fromquanlytintuc", FromQuanLyTinTuc);
            await NavigationService.NavigateAsync("TinTucDetailPage", navigationParamters);
        }
    }
}
