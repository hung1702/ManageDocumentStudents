﻿using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.TabbedPage;
using XamMobile.ViewModels.TienIch;

namespace XamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMenuPage : ContentPage
    {
        private HomeMenuPageViewModel viewModel { get; set; }
        public HomeMenuPage()
        {
            InitializeComponent();

            //var tabbedPage = new TabbedPage();
            //tabbedPage.Children.Add(new TrangChuTabbedPage());
            //tabbedPage.Children.Add(new HocTapTabbedPage());
            //tabbedPage.Children.Add(new TienIchTabbedPage());
            //tabbedPage.Children.Add(new CaNhanTabbedPage());
            //MainPage = new TabbedPage();

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (HomeMenuPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.OpenUserPopUp(e.SelectedItem);
            listView.SelectedItem = null;
        }

        private void ListView_TinTucItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel = (HomeMenuPageViewModel)BindingContext;
            var listView = ((ListView)sender);
            if (listView.SelectedItem == null)
                return;

            this.viewModel.GotoTinTucDetailPage(e.SelectedItem);
            listView.SelectedItem = null;
        }

        protected override bool OnBackButtonPressed() => true;
    }
}