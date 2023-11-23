using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels.TienIch;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace XamMobile.Views.TienIch
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuetMaQRPage : ContentPage
	{
        public QuetMaQRPageViewModel viewModel { get; set; }
        public QuetMaQRPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            viewModel = (QuetMaQRPageViewModel)BindingContext;
            base.OnAppearing();
            scannerView = new ZXingScannerView();
            scannerView.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("QR Code Scanned", result.Text, "OK");
                    viewModel.IsScanning = false;
                });
            };
            BindingContext = viewModel;
            viewModel.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            viewModel = (QuetMaQRPageViewModel)BindingContext;
            base.OnDisappearing();
            viewModel.IsScanning = false;
        }

        private void OnScanResult(Result result)
        {
            viewModel = (QuetMaQRPageViewModel)BindingContext;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("QR Code Scanned", result.Text, "OK");
                viewModel.IsScanning = false;
            });
        }
    }
}