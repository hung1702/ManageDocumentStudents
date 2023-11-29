using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMobile.ViewModels;
using XamMobile.ViewModels.Diem;

namespace XamMobile.Views.Diem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiemMenuPage : ContentPage
	{
        private DiemMenuPageViewModel viewModel { get; set; }

        public DiemMenuPage ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed() => true;

    }
}