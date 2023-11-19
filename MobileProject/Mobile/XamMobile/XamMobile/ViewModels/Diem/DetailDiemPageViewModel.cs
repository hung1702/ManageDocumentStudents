using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamMobile.DependencyServices;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.Diem
{
    public class DetailDiemPageViewModel : ViewModelBase
    {

        IUserService iUserService;
        IDiemService iDiemService;

        private DiemEntity _diemDetail;
        public DiemEntity DiemDetail
        {
            get { return _diemDetail; }
            set { SetProperty(ref _diemDetail, value); }
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

        private string _heSoDiemCC;
        public string HeSoDiemCC
        {
            get { return _heSoDiemCC; }
            set
            {
                if (_heSoDiemCC != value)
                {
                    _heSoDiemCC = value;
                    OnPropertyChanged(nameof(HeSoDiemCC));
                }
            }
        }

        private string _heSoDiemKT;
        public string HeSoDiemKT
        {
            get { return _heSoDiemKT; }
            set
            {
                if (_heSoDiemKT != value)
                {
                    _heSoDiemKT = value;
                    OnPropertyChanged(nameof(HeSoDiemKT));
                }
            }
        }

        private string _heSoDiemTH;
        public string HeSoDiemTH
        {
            get { return _heSoDiemTH; }
            set
            {
                if (_heSoDiemTH != value)
                {
                    _heSoDiemTH = value;
                    OnPropertyChanged(nameof(HeSoDiemTH));
                }
            }
        }

        private string _heSoDiemThi;
        public string HeSoDiemThi
        {
            get { return _heSoDiemThi; }
            set
            {
                if (_heSoDiemThi != value)
                {
                    _heSoDiemThi = value;
                    OnPropertyChanged(nameof(HeSoDiemThi));
                }
            }
        }

        public DetailDiemPageViewModel(INavigationService navigationService, IUserService iUserService, IDiemService iDiemService) 
            : base(navigationService)
        {
            this.iUserService = iUserService;
            this.iDiemService = iDiemService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            DiemDetail = parameters.GetValue<DiemEntity>("obj");
            DiemTotal = parameters.GetValue<double>("diemtotal");
            DiemTotalHe4 = parameters.GetValue<double>("diemtotalhe4");
            TinChiTotal = parameters.GetValue<double>("tinchitotal");

            LoadDataPage();
            base.OnNavigatedTo(parameters);
        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            await NavigationService.NavigateAsync(page);
        }

        public void LoadDataPage()
        {
            HeSoDiemCC = DiemDetail.HeSo[0].ToString() + "%";
            HeSoDiemKT = DiemDetail.HeSo[1].ToString() + "%";
            HeSoDiemTH = DiemDetail.HeSo[2].ToString() + "%";
            HeSoDiemThi = DiemDetail.HeSo[3].ToString() + "%";
        }
    }
}
