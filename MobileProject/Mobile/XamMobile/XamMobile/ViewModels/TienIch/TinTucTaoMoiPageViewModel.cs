using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.EntityModels;
using XamMobile.Services;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class TinTucTaoMoiPageViewModel : ViewModelBase
    {
        private TinTucEntity _tinTucCurrent;
        public TinTucEntity TinTucCurrent
        {
            get { return _tinTucCurrent; }
            set { SetProperty(ref _tinTucCurrent, value); }
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

        public DelegateCommand SaveTinTucCommand { get; private set; }

        IUserService iUserService;
        ITinTucService iTinTucService;

        public TinTucTaoMoiPageViewModel(INavigationService navigationService, IUserService iUserService, ITinTucService iTinTucService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iTinTucService = iTinTucService;
            TinTucCurrent = new TinTucEntity();
            SaveTinTucCommand = new DelegateCommand(async () => { await SaveTinTucAsync(); });
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
        }

        public async Task SaveTinTucAsync()
        {
            try
            {
                if (TinTucCurrent == null || TinTucCurrent == default)
                    throw new Exception("Co loi khi tai du lieu!");
                if(string.IsNullOrEmpty(TinTucCurrent.Ten) 
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
                if(res != null)
                {
                    //MessagingCenter.Send((App)Application.Current, "UpdateNhanVien", res);
                    await App.Current.MainPage.DisplayAlert("Alert", "Tạo tin tức thành công!", "OK");
                    UserDialogs.Instance.Toast("Lưu thành công");
                    GotoTinTucDetailPage(res);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Tạo tin tức thất bại!", "OK");
                    UserDialogs.Instance.Toast("Lưu thất bại!");
                }
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
            navigationParamters.Add("obj", obj);
            //navigationParamters.Add("totaltintuc", TotalTinTuc);
            await NavigationService.NavigateAsync("TinTucDetailPage", navigationParamters);
        }
    }
}
