using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TabbedPage
{
    public partial class HomeMenuPageViewModel
    {
        public ICommand ToggleHuongDanCommand => new Command(OpenToggleHuongDan);
        private bool _IsOpenToggleHuongDan = false;
        public bool IsOpenToggleHuongDan
        {
            get { return _IsOpenToggleHuongDan; }
            set
            {
                if (_IsOpenToggleHuongDan != value)
                {
                    _IsOpenToggleHuongDan = value;
                    OnPropertyChanged(nameof(IsOpenToggleHuongDan));
                }
            }
        }
        public void OpenToggleHuongDan()
        {
            IsOpenToggleHuongDan = !IsOpenToggleHuongDan;
        }
    }
}
