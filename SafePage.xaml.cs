using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App411
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SafePage : TabbedPage
    {
        public SafePage()
        {
            InitializeComponent();
        }

        async private void btn_OpenModalPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ModalPage());
        }
    }
}