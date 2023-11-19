using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.Diem
{
    public class ListDiemPageViewModel : ViewModelBase
    {
        public readonly List<int> HocKyList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        private List<DiemEntity> _listDiem;
        public List<DiemEntity> ListDiem
        {
            get { return _listDiem; }
            set
            {
                _listDiem = value;
                OnPropertyChanged(nameof(ListDiem));
                OnPropertyChanged(nameof(HasDataFilter));
                OnPropertyChanged(nameof(IsNoDataFilter));
            }
        }

        public bool HasDataFilter => ListDiem != null && ListDiem.Count > 0;
        public bool IsNoDataFilter => !HasDataFilter;

        private List<DiemEntity> _dataDiemList;
        public List<DiemEntity> DataDiemList
        {
            get { return _dataDiemList; }
            set
            {
                _dataDiemList = value;
                OnPropertyChanged(nameof(DataDiemList));
                OnPropertyChanged(nameof(HasDataAll));
                OnPropertyChanged(nameof(IsNoDataAll));
            }
        }

        public bool HasDataAll => DataDiemList != null && DataDiemList.Count > 0;
        public bool IsNoDataAll => !HasDataAll;

        //public List<string> SortByList { get; set; }

        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
        }

        private string _messageResult = "Không có dữ liệu điểm";
        public string MessageResult
        {
            get { return _messageResult; }
            set { SetProperty(ref _messageResult, value); }
        }

        private string _messageResultAll = "Không có dữ liệu điểm";
        public string MessageResultAll
        {
            get { return _messageResultAll; }
            set { SetProperty(ref _messageResultAll, value); }
        }


        private int selectedHocky;
        public int SelectedHocky
        {
            get { return selectedHocky; }
            set
            {
                if (selectedHocky != value)
                {
                    selectedHocky = value;
                    OnPropertyChanged(nameof(SelectedHocky));
                }
            }
        }

        private List<string> tenHocKyList;
        public List<string> TenHocKyList
        {
            get { return tenHocKyList; }
            set
            {
                if (tenHocKyList != value)
                {
                    tenHocKyList = value;
                    OnPropertyChanged(nameof(TenHocKyList));
                }
            }
        }

        private bool isNoResult;
        public bool IsNoResult
        {
            get { return isNoResult; }
            set
            {
                if (isNoResult != value)
                {
                    isNoResult = value;
                    OnPropertyChanged(nameof(IsNoResult));
                }
            }
        }


        private double _diemTotal;
        public double DiemTotal
        {
            get { return _diemTotal; }
            set
            {
                if (_diemTotal != value)
                {
                    _diemTotal = value;
                    OnPropertyChanged(nameof(DiemTotal));
                }
            }
        }

        private double _diemTotalHe4;
        public double DiemTotalHe4
        {
            get { return _diemTotalHe4; }
            set
            {
                if (_diemTotalHe4 != value)
                {
                    _diemTotalHe4 = value;
                    OnPropertyChanged(nameof(DiemTotalHe4));
                }
            }
        }

        private double _tinChiTotal;
        public double TinChiTotal
        {
            get { return _tinChiTotal; }
            set
            {
                if (_tinChiTotal != value)
                {
                    _tinChiTotal = value;
                    OnPropertyChanged(nameof(TinChiTotal));
                }
            }
        }

        IUserService iUserService;
        IDiemService iDiemService;
        public DelegateCommand GotoDetailDiemPageCommand { get; private set; }

        public ListDiemPageViewModel(INavigationService navigationService, IUserService iUserService, IDiemService iDiemService) : base(navigationService)
        {
            SelectedSortBy = new List<string> { "Tên", "Điểm TB" };
            this.iUserService = iUserService;
            this.iDiemService = iDiemService;
            GotoDetailDiemPageCommand = new DelegateCommand(() => { GotoPage("DetailDiemPage"); });

            ListDiem = new List<DiemEntity>();
            TenHocKyList = HocKyList.Select(x => GetTenHocKy(x)).ToList();
            SelectedHocky = HocKyList.FirstOrDefault();
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

        private async void LoadAllData()
        {
            try
            {
                using (UserDialogs.Instance.Loading("Đang tải"))
                {
                    var detailDiems = await iDiemService.GetDSDiem();
                    if (detailDiems == null || detailDiems == default)
                    {
                        IsNoResult = true;
                        MessageResult = string.Format("Không có dữ liệu điểm");
                        UserDialogs.Instance.Alert("Có lỗi khi tải thông tin điểm của sinh viên");
                        return;
                    }

                    DiemTotal = Math.Round(GetDiemTotal(detailDiems), 2);
                    DiemTotalHe4 = Math.Round(GetDiemTotalHe4(DiemTotal), 2);
                    TinChiTotal = GetTinChiTotal(detailDiems);
                    DataDiemList = detailDiems;

                    ListDiem = detailDiems;
                    if (ListDiem == null || !ListDiem.Any())
                    {
                        IsNoResult = true;
                        MessageResult = string.Format("Không có dữ liệu điểm");
                        UserDialogs.Instance.Alert("Có lỗi khi tải thông tin điểm của sinh viên");
                        return;
                    }
                    else
                    {
                        IsNoResult = false;
                    }
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async void GotoDetailDiemPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new DiemEntity();
            navigationParamters.Add("obj", obj);
            navigationParamters.Add("diemtotal", DiemTotal);
            navigationParamters.Add("diemtotalhe4", DiemTotalHe4);
            navigationParamters.Add("tinchitotal", TinChiTotal);
            await NavigationService.NavigateAsync("DetailDiemPage", navigationParamters);
        }

        public void SortByDiemTB()
        {
            ListDiem = ListDiem.OrderBy(d => d.DiemTB).ToList();
        }

        public void SortByName()
        {
            ListDiem = ListDiem.OrderBy(d => d.TenMonHoc).ToList();
        }

        public void FilterByHocKy(int selectedIndex)
        {
            LoadAllData();
            if (DataDiemList == null || !DataDiemList.Any())
            {
                IsNoResult = true;
                MessageResult = string.Format("Không có dữ liệu điểm theo {0}", TenHocKyList[selectedIndex].ToString());
            }
            else
            {
                if (selectedIndex == 0)
                {
                    ListDiem = DataDiemList;
                }
                else
                {
                    ListDiem = DataDiemList.Where(x => x.MaHocKy == selectedIndex).ToList();
                    if (ListDiem == null || !ListDiem.Any())
                    {
                        IsNoResult = true;
                        MessageResult = string.Format("Không có dữ liệu điểm theo {0}", TenHocKyList[selectedIndex].ToString());
                        return;
                    }
                    else
                    {
                        isNoResult = false;
                    }
                }
            }
        }

        public double GetDiemTotal(List<DiemEntity> listDiem)
        {
            var tongDiem = 0.0;
            foreach (var diem in listDiem)
            {
                if (diem == null || diem == default)
                    continue;
                else
                {
                    if (diem.HeSoMonHoc == null || diem.HeSoMonHoc == null)
                        diem.HeSoMonHoc = "10102060";
                    if (diem.SoTinChi == null || diem.SoTinChi == default)
                        diem.SoTinChi = 3;

                    tongDiem = tongDiem + diem.DiemTB * diem.SoTinChi;
                }
            }
            var tongTinChi = GetTinChiTotal(listDiem);
            return tongDiem / tongTinChi;
        }


        public double GetTinChiTotal(List<DiemEntity> listDiem)
        {
            var listTinChi = listDiem.Select(x => x.SoTinChi);
            return listTinChi.Sum();
        }
        public double GetDiemTotalHe4(double diemTotal)
        {
            return diemTotal * 4 / 10;
        }

        public string GetTenHocKy(int maHocKy)
        {
            if (maHocKy == 0)
                return "Tất cả";
            else if (maHocKy == 1)
                return "HK 1 Năm 1";
            else if (maHocKy == 2)
                return "HK 2 Năm 1";
            else if (maHocKy == 3)
                return "HK 3 Năm 1";
            else if (maHocKy == 4)
                return "HK 1 Năm 2";
            else if (maHocKy == 5)
                return "HK 2 Năm 2";
            else if (maHocKy == 6)
                return "HK 3 Năm 2";
            else if (maHocKy == 7)
                return "HK 1 Năm 3";
            else if (maHocKy == 8)
                return "HK 2 Năm 3";
            else if (maHocKy == 9)
                return "HK 3 Năm 3";
            else if (maHocKy == 10)
                return "HK 1 Năm 4";
            else if (maHocKy == 11)
                return "HK 2 Năm 4";
            else if (maHocKy == 12)
                return "HK 3 Năm 4";
            else if (maHocKy == 13)
                return "HK 1 Năm 5";
            else if (maHocKy == 14)
                return "HK 2 Năm 5";
            else if (maHocKy == 15)
                return "HK 3 Năm 5";
            else
                return "HK Phụ";
        }
    }
}
