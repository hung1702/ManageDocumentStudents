using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.DichVu
{
   public class LoaiBieuMauPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        IBieuMauService iBieuMauService;

        private List<LoaiBieuMauEntity> _ListLoaiBieuMau;
        public List<LoaiBieuMauEntity> ListLoaiBieuMau
        {
            get { return _ListLoaiBieuMau; }
            set
            {
                _ListLoaiBieuMau = value;
                OnPropertyChanged(nameof(ListLoaiBieuMau));
            }
        }

        private List<LoaiBieuMauEntity> _DataLoaiBieuMauList;
        public List<LoaiBieuMauEntity> DataLoaiBieuMauList
        {
            get { return _DataLoaiBieuMauList; }
            set
            {
                _DataLoaiBieuMauList = value;
                OnPropertyChanged(nameof(DataLoaiBieuMauList));
                OnPropertyChanged(nameof(HasDataAll));
                OnPropertyChanged(nameof(IsNoDataAll));
            }
        }

        public bool HasDataAll => DataLoaiBieuMauList != null && DataLoaiBieuMauList.Count > 0;
        public bool IsNoDataAll => !HasDataAll;


        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
        }

        private string _messageResult = "Không có dữ liệu loại biểu mẫu";
        public string MessageResult
        {
            get { return _messageResult; }
            set { SetProperty(ref _messageResult, value); }
        }
        private int _totalLoaiBieuMau;
        public int TotalLoaiBieuMau
        {
            get { return _totalLoaiBieuMau; }
            set { SetProperty(ref _totalLoaiBieuMau, value); }
        }

        private string _textSearch = "";
        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                if (_textSearch != value)
                {
                    _textSearch = value;
                    OnPropertyChanged(nameof(TextSearch));
                }
            }
        }

        public DelegateCommand GoToBieuMauTaoMoiPageCommand { get; private set; }
        public DelegateCommand TimKiemLoaiBieuMauCommand { get; private set; }

        public LoaiBieuMauPageViewModel(INavigationService navigationService, IUserService iUserService, IBieuMauService iBieuMauService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iBieuMauService = iBieuMauService;
            SelectedSortBy = new List<string> { "Tên biểu mẫu", "Thời gian xử lý", "Ngày tạo" };

            GoToBieuMauTaoMoiPageCommand = new DelegateCommand(() => { GotoPage("BieuMauTaoMoiPage"); });
            TimKiemLoaiBieuMauCommand = new DelegateCommand(() => { SearchCommand(TextSearch); });
            TextSearch = "";

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
            LoadAllData();
        }

        public async void LoadAllData()
        {
            try
            {
                var loaiBieuMau = await iBieuMauService.GetAllLoaiBieuMau();
                DataLoaiBieuMauList = loaiBieuMau.Where(x => x.IsActive).ToList();
                ListLoaiBieuMau = DataLoaiBieuMauList.OrderBy(x => x.NgayTao).ToList();
                TotalLoaiBieuMau = DataLoaiBieuMauList.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SortByNgayTao()
        {
            ListLoaiBieuMau = DataLoaiBieuMauList.OrderBy(x => x.NgayTao).ToList();
        }

        public void SortByNgayXuLy()
        {
            ListLoaiBieuMau = DataLoaiBieuMauList.OrderBy(x => x.ThoiGianXuLy).ThenBy(x => x.Ten).ToList();
        }

        public void SortByTen()
        {
            ListLoaiBieuMau = DataLoaiBieuMauList.OrderBy(x => x.Ten).ToList();
        }
        public void SearchCommand(string text)
        {
            ListLoaiBieuMau = DataLoaiBieuMauList.Where(x => x.Ten.ToLower().Contains(text.ToLower())).OrderBy(x => x.Ten).ToList();
        }

        public async void GotoBieuMauPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new LoaiBieuMauEntity();
            navigationParamters.Add("obj", obj);
            //navigationParamters.Add("fromquanlyBieuMau", true);
            await NavigationService.NavigateAsync("BieuMauPage", navigationParamters);
        }
    }
}
