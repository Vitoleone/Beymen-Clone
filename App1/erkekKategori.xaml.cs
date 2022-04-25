using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class erkekKategori : ContentPage
    {
        public erkekKategori()
        {

            InitializeComponent();

            NavigationPage.SetIconColor(this, Color.FromHex("#FFFFFF"));

            var navigationPage = Application.Current.MainPage as NavigationPage; // navbar rengi değiştirme
            navigationPage.BarBackgroundColor = Color.FromHex("#191919");
            BindingContext = this;
        }


        private void ErkekSaat(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekSaat());

        }

        private void ErkekGiyim(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekGiyim());
        }
        private void ErkekAyakkabi(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekAyakkabi());
        }
      
    }
}