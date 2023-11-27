using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.DichVu
{
    public class QuyTrinhBieuMauPopUpViewModel : ViewModelBase
    {
        IUserService iUserService;

        private LoaiBieuMauEntity _loaiBieuMau;
        public LoaiBieuMauEntity LoaiBieuMau
        {
            get { return _loaiBieuMau; }
            set
            {
                _loaiBieuMau = value;
                OnPropertyChanged(nameof(LoaiBieuMau));
            }
        }

        public DelegateCommand GoToBieuMauPageCommand { get; private set; }

        public QuyTrinhBieuMauPopUpViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            GoToBieuMauPageCommand = new DelegateCommand(() => { GotoBieuMauPage(LoaiBieuMau); });
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
            LoaiBieuMau = parameters.GetValue<LoaiBieuMauEntity>("obj");
        }

        public async void GotoBieuMauPage(object obj = null)
        {
            var navigationParamters = new NavigationParameters();
            if (obj == null)
                obj = new LoaiBieuMauEntity();
            navigationParamters.Add("obj", obj);
            await NavigationService.NavigateAsync("BieuMauPage", navigationParamters);
        }
    }
}
