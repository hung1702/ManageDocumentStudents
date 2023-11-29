﻿using Prism.Commands;
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

        //IUserService iUserService;

        //public DelegateCommand GotoListHuongDanPageCommand { get; private set; }
        //public DelegateCommand GotoGioiThieuPageCommand { get; private set; }
        //public DelegateCommand GotoTinTucPageCommand { get; private set; }
        //public DelegateCommand GotoQuetMaQRPageCommand { get; private set; }
        //public DelegateCommand GotoTruyCapMapPageCommand { get; private set; }

        //public CommonPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        //{
        //    this.iUserService = iUserService;
        //    GotoListHuongDanPageCommand = new DelegateCommand(() => { GotoPage("ListHuongDanPage"); });
        //    GotoGioiThieuPageCommand = new DelegateCommand(() => { GotoPage("GioiThieuPage"); });
        //    GotoTinTucPageCommand = new DelegateCommand(() => { GotoPage("TinTucPage"); });
        //    GotoQuetMaQRPageCommand = new DelegateCommand(() => { GotoPage("QuetMaQRPage"); });
        //    GotoTruyCapMapPageCommand = new DelegateCommand(() => { GotoPage("TruyCapMapPage"); });
        //}

        //public void GotoPage(string page)
        //{
        //    NavigatetoPage(page);
        //}

        //public async void NavigatetoPage(string page)
        //{
        //    await NavigationService.NavigateAsync(page);
        //}

        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    base.OnNavigatedTo(parameters);
        //}
    }
}
