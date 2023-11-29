using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamMobile.ViewModels.TabbedPage
{
    public partial class HomeMenuPageViewModel
    {
        // Dich Vu Tabbed
        public ICommand ToggleDichVuMotCuaCommand => new Command(OpenToggleDichVuMotCua);
        private bool _IsOpenToggleDichVuMotCua = false;
        public bool IsOpenToggleDichVuMotCua
        {
            get { return _IsOpenToggleDichVuMotCua; }
            set
            {
                if (_IsOpenToggleDichVuMotCua != value)
                {
                    _IsOpenToggleDichVuMotCua = value;
                    OnPropertyChanged(nameof(IsOpenToggleDichVuMotCua));
                }
            }
        }
        public void OpenToggleDichVuMotCua()
        {
            IsOpenToggleDichVuMotCua = !IsOpenToggleDichVuMotCua;
        }

        public ICommand ToggleCongNoCommand => new Command(OpenToggleCongNo);
        private bool _IsOpenToggleCongNo = false;
        public bool IsOpenToggleCongNo
        {
            get { return _IsOpenToggleCongNo; }
            set
            {
                if (_IsOpenToggleCongNo != value)
                {
                    _IsOpenToggleCongNo = value;
                    OnPropertyChanged(nameof(IsOpenToggleCongNo));
                }
            }
        }
        public void OpenToggleCongNo()
        {
            IsOpenToggleCongNo = !IsOpenToggleCongNo;
        }

        public ICommand ToggleThuVienCommand => new Command(OpenToggleThuVien);
        private bool _IsOpenToggleThuVien = false;
        public bool IsOpenToggleThuVien
        {
            get { return _IsOpenToggleThuVien; }
            set
            {
                if (_IsOpenToggleThuVien != value)
                {
                    _IsOpenToggleThuVien = value;
                    OnPropertyChanged(nameof(IsOpenToggleThuVien));
                }
            }
        }
        public void OpenToggleThuVien()
        {
            IsOpenToggleThuVien = !IsOpenToggleThuVien;
        }
    }
}
