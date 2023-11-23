using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamMobile.Views.TienIch
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HuongDanPage : ContentPage
	{
		public HuongDanPage ()
		{
			InitializeComponent ();
		}

        [Obsolete]
        private void OnLinkClicked(object sender, EventArgs e)
        {
            // Open the URL when the link is clicked
            Device.OpenUri(new Uri("https://portal.ptit.edu.vn/wp-content/uploads/2021/01/HDSD-HSSV-Ptit.pdf"));
        }
    }
}