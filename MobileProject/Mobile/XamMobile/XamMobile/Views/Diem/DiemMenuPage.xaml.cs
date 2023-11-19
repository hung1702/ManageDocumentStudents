using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;

namespace XamMobile.Views.Diem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiemMenuPage : ContentPage
	{
        private HomeMenuPageViewModel viewModel { get; set; }

        public DiemMenuPage ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed() => true;

    }
}