﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.DichVu
{
    public class DichVuMenuPageViewModel : ViewModelBase
    {
        IUserService iUserService;
        public DelegateCommand GotoLoaiBieuMauPageCommand { get; private set; }
        public DelegateCommand GotoLichSuDichVuPageCommand { get; private set; }
        public DichVuMenuPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GotoLoaiBieuMauPageCommand = new DelegateCommand(() => { GotoPage("LoaiBieuMauPage"); });
            GotoLichSuDichVuPageCommand = new DelegateCommand(() => { GotoPage("LichSuDichVuPage"); });
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
