using FastExpressionCompiler.LightExpression;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels
{
    public class CommonPopUpViewModel : ViewModelBase
    {
        IUserService iUserService;
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }

        private string _ImageSource;
        public string ImageSource
        {
            get { return _ImageSource; }
            set { SetProperty(ref _ImageSource, value); }
        }

        private string _ButtonName;
        public string ButtonName
        {
            get { return _ButtonName; }
            set { SetProperty(ref _ButtonName, value); }
        }



        public CommonPopUpViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
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
            Title = parameters.GetValue<string>("title");
            Message = parameters.GetValue<string>("message");
            ImageSource = parameters.GetValue<string>("imagesource");
            ButtonName = parameters.GetValue<string>("buttonname");
            //LoadAllData();
        }
    }
}
