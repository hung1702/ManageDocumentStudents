using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Views;

namespace XamMobile.ViewModels.TienIch
{
    public class TinTucPageViewModel : ViewModelBase
    {
        private List<TinTucEntity> _listTinTuc;
        public List<TinTucEntity> ListTinTuc
        {
            get { return _listTinTuc; }
            set
            {
                _listTinTuc = value;
                OnPropertyChanged(nameof(ListTinTuc));
            }
        }

        private List<TinTucEntity> _dataTinTucList;
        public List<TinTucEntity> DataTinTucList
        {
            get { return _dataTinTucList; }
            set
            {
                _dataTinTucList = value;
                OnPropertyChanged(nameof(DataTinTucList));
                OnPropertyChanged(nameof(HasDataAll));
                OnPropertyChanged(nameof(IsNoDataAll));
            }
        }

        public bool HasDataAll => DataTinTucList != null && DataTinTucList.Count > 0;
        public bool IsNoDataAll => !HasDataAll;


        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
        }

        private string _messageResult = "Không có dữ liệu tin tức";
        public string MessageResult
        {
            get { return _messageResult; }
            set { SetProperty(ref _messageResult, value); }
        }
        private int _totalTinTuc;
        public int TotalTinTuc
        {
            get { return _totalTinTuc; }
            set { SetProperty(ref _totalTinTuc, value); }
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

        public DelegateCommand GoToTinTucTaoMoiPageCommand { get; private set; }
        public DelegateCommand GotoCommonPopUpCommand { get; private set; }
        public DelegateCommand TimKiemTinTucCommand { get; private set; }

        IUserService iUserService;
        ITinTucService iTinTucService;

        public TinTucPageViewModel(INavigationService navigationService, IUserService iUserService, ITinTucService iTinTucService) : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iTinTucService = iTinTucService;
            SelectedSortBy = new List<string> { "Ngày tạo mới nhất", "Ngày tạo cũ nhất", "Tiêu đề", "Tin nổi bật"};

            GoToTinTucTaoMoiPageCommand = new DelegateCommand(() => { GotoPage("TinTucTaoMoiPage"); });
            GotoCommonPopUpCommand = new DelegateCommand(() => { GotoPage(nameof(CommonTabbedPage)); });
            TimKiemTinTucCommand = new DelegateCommand(() => { SearchCommand(TextSearch) ; });
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
                var tinTuc = await iTinTucService.GetAllTinTuc();
                DataTinTucList = tinTuc.Where(x => x.IsActive).ToList();
                ListTinTuc = DataTinTucList.OrderBy(x => x.NgayTao).ToList();
                TotalTinTuc = DataTinTucList.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SortByNgayTaoMoi()
        {
            ListTinTuc = DataTinTucList.OrderBy(x => x.NgayTao).ToList();
        }

        public void SortByNgayTaoCu()
        {
            ListTinTuc = DataTinTucList.OrderByDescending(x => x.NgayTao).ToList();
        }

        public void SortByTinNoiBat()
        {
            ListTinTuc = DataTinTucList.OrderByDescending(x => x.IsNoiBat).ThenBy(x => x.NgayTao).ToList();
        }

        public void SortByTieuDe()
        {
            ListTinTuc = DataTinTucList.OrderBy(x => x.Ten).ToList();
        }

        public void SearchCommand(string text)
        {
            ListTinTuc = DataTinTucList.Where(x => x.Ten.ToLower().Contains(text.ToLower())).OrderBy(x => x.Ten).ToList();
        }

        public async void GotoTinTucDetailPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new TinTucEntity();
            navigationParamters.Add("obj", obj);
            navigationParamters.Add("fromquanlytintuc", true);
            await NavigationService.NavigateAsync("TinTucDetailPage", navigationParamters);
        }
    }
}
