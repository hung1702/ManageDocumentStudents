﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.ThuVien
{
    public class MenuThuVienPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        public DelegateCommand GotoTimKiemSachPageCommand { get; private set; }
        public DelegateCommand GotoLichSuMuonPageCommand { get; private set; }

        
        public MenuThuVienPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoTimKiemSachPageCommand = new DelegateCommand(() => { GotoPage("TimKiemThuVienPage"); });
            GotoLichSuMuonPageCommand = new DelegateCommand(() => { GotoPage("LichSuThuVienPage"); });
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
    }
}
