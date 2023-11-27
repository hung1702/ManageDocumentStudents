using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.EntityModels;
using XamMobile.Services;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.DichVu
{
    public class BieuMauPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        IBieuMauService iBieuMauService;

        private LoaiBieuMauEntity _loaiBieuMau;
        public LoaiBieuMauEntity LoaiBieuMau
        {
            get { return _loaiBieuMau; }
            set
            {
                _loaiBieuMau = value;
                OnPropertyChanged(nameof(LoaiBieuMau));
            }
        }

        private string _textNoiBat;
        public string TextNoiBat
        {
            get { return _textNoiBat; }
            set { SetProperty(ref _textNoiBat, value); }
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


        public DelegateCommand GoToBieuMauTaoMoiPageCommand { get; private set; }

        public BieuMauPageViewModel(INavigationService navigationService, IUserService iUserService, IBieuMauService iBieuMauService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iBieuMauService = iBieuMauService;
            GoToBieuMauTaoMoiPageCommand = new DelegateCommand(() => { GotoPage("BieuMauTaoMoiPage"); });
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
            LoaiBieuMau = parameters.GetValue<LoaiBieuMauEntity>("obj");
            LoadAllData();
        }

        public void LoadAllData()
        {
            try
            {
                //var loaiBieuMau = await iBieuMauService.GetAllLoaiBieuMau();
                //DataLoaiBieuMauList = loaiBieuMau.Where(x => x.IsActive).ToList();
                //ListLoaiBieuMau = DataLoaiBieuMauList.OrderBy(x => x.NgayTao).ToList();
                //TotalLoaiBieuMau = DataLoaiBieuMauList.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task GotoQuyTrinhBieuMauPopUp(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new LoaiBieuMauEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("QuyTrinhBieuMauPopUp", navigationParamters);
        }
    }
}
