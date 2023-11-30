using Acr.UserDialogs;
using Plugin.FilePicker;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Models;
using XamMobile.Services;
using XamMobile.Services.Interface;
using XamMobile.Views.MasterDetail;

namespace XamMobile.ViewModels.NhanVien
{
    public class NhanVienPageViewModel : ViewModelBase
    {
        private ObservableCollection<string> _actionDatasource;
        public ObservableCollection<string> ActionDatasource
        {
            get { return _actionDatasource; }
            set { SetProperty(ref _actionDatasource, value); }
        }
        public UserPage CurrentPage { get; set; }


        private List<NhanVienEntity> _listNhanVien;
        public List<NhanVienEntity> ListNhanVien
        {
            get { return _listNhanVien; }
            set { SetProperty(ref _listNhanVien, value); }
        }

        public List<string> SortByList { get; set; }

        private List<string> _selectedSortBy;
        public List<string> SelectedSortBy
        {
            get { return _selectedSortBy; }
            set { SetProperty(ref _selectedSortBy, value); }
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

        IUserService iUserService;
        public DelegateCommand UpdatePictureCommand { get; private set; }
        public DelegateCommand GotoAddNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoEditNhanVienPageCommand { get; private set; }
        public DelegateCommand GotoDetailNhanVienPageCommand { get; private set; }
        public DelegateCommand TimKiemNhanVienCommand { get; private set; }

        public NhanVienPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            SortByList = new List<string> { "NVID", "Name" };
            this.iUserService = iUserService;

            GotoAddNhanVienPageCommand = new DelegateCommand(() => { GotoPage("AddNhanVienPage"); });
            GotoEditNhanVienPageCommand = new DelegateCommand(() => { GotoPage("EditNhanVienPage"); });
            GotoDetailNhanVienPageCommand = new DelegateCommand(() => { GotoPage("DetailNhanVienPage"); });
            TimKiemNhanVienCommand = new DelegateCommand(() => { SearchCommand(TextSearch); });
            TextSearch = "";

            ListNhanVien = new List<NhanVienEntity>();
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
                    var nhanViens = await iUserService.GetNhanViens();
                    if (nhanViens == null || !nhanViens.Any())
                    {
                        UserDialogs.Instance.Alert("Có lỗi khi tải thông tin nhân viên");
                        return;
                    }
                    ListNhanVien = nhanViens;
                }
            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Có lỗi khi tải dữ liệu");
            }
        }

        public async void OpenPopUpAddNhanVien(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new NhanVienEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("DetailNhanVienPage", navigationParamters);
        }

        private async Task DeleteNhanVien(int id)
        {
            try
            {
                var nhanVien = ListNhanVien.FirstOrDefault(x => x.NhanVienID == id);
                var result = await iUserService.DeleteNhanVien(nhanVien);
                if (result)
                    UserDialogs.Instance.Toast("Xoa nhan vien thanh cong");
                else
                    UserDialogs.Instance.Toast("Xoa nhan vien khong thanh cong");
            }
            catch (Exception ex)
            {
                throw new Exception("Khong xoa duoc nhan vien");
            }

        }

        public void SortById()
        {
            ListNhanVien = ListNhanVien.OrderBy(nv => nv.NhanVienID).ToList();
        }

        public void SortByName()
        {
            ListNhanVien = ListNhanVien.OrderBy(nv => nv.TenNhanVien).ToList();
        }

        public void SearchCommand(string text)
        {
            ListNhanVien = ListNhanVien.Where(x => x.TenNhanVien.ToLower().Contains(text.ToLower())).OrderBy(x => x.TenNhanVien).ToList();
        }
    }
}
