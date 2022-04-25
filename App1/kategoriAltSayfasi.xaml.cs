using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class kategoriAltSayfasi : ContentPage
    {
        public kategoriAltSayfasi()
        {
           
            InitializeComponent();
            
            NavigationPage.SetIconColor(this, Color.FromHex("#FFFFFF"));

            var navigationPage = Application.Current.MainPage as NavigationPage; // navbar rengi değiştirme
            navigationPage.BarBackgroundColor = Color.FromHex("#191919");
            BindingContext = this;

            
            
            
            
            
       
        }
      

        private void KadinAksesuar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new kadinAksesuar());

        }
   
        private void KadinGiyim(object sender, EventArgs e)
        {
            Navigation.PushAsync(new kadinGiyim());
        }
        private void KadinAyakkabi(object sender, EventArgs e)
        {
            Navigation.PushAsync(new kadinAyakkabi());
        }
        private void KadinCanta(object sender, EventArgs e)
        {
            Navigation.PushAsync(new kadinCanta());
        }


    }
}