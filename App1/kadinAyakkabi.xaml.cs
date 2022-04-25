using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.CommunityToolkit;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class kadinAyakkabi : ContentPage
    {
        public ObservableCollection<KadinUrun> urunler;
        
        private readonly KadinUrun[] urunlerSourceSol =
        {
            new KadinUrun{Name="Siyah Kadın Deri Bot",Image ="kadinAyakkabi1",Discount = "-%50",Price="1.799,00 TL", DiscountedPrice = "899,00 TL"},
            new KadinUrun{Name="Beyaz Kontrast Dikişli Deri Bot",Image ="kadinAyakkabi2",Discount = "-%30",Price="2.199,00 TL", DiscountedPrice = "1.549,00 TL"},
            new KadinUrun{Name="Kadın Beyaz Spor Ayakkabı",Image ="kadinAyakkabi3",Discount = "-%42",Price="1.799,00 TL", DiscountedPrice = "1.049,00 TL"},
            new KadinUrun{Name="Haki Kalın Tabanlı Kadın Deri Bot",Image ="kadinAyakkabi4",Discount = "-%48",Price="1.799,00 TL", DiscountedPrice = "929,00 TL"},
            new KadinUrun{Name="Kadın Deri Sneaker",Image ="kadinAyakkabi5",Discount = "-%50",Price="10.750,00 TL", DiscountedPrice = "5.350,00 TL"},

        };
        public kadinAyakkabi()
        {
            InitializeComponent();

            urunler = new ObservableCollection<KadinUrun>(urunlerSourceSol);

            myCollectionView.ItemsSource = urunler;


            BindingContext = this;
        }

        private void myCollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
           var ayakkabiUrun = e.CurrentSelection.FirstOrDefault() as KadinUrun;
           Navigation.PushAsync(new KadinUrunSayfasi(ayakkabiUrun.Name,ayakkabiUrun.Image,ayakkabiUrun.Discount,ayakkabiUrun.Price,ayakkabiUrun.DiscountedPrice));
        }
    }
 
}