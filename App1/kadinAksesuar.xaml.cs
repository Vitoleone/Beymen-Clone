using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class kadinAksesuar : ContentPage
    {
        public ObservableCollection<KadinUrun> urunler;

        private readonly KadinUrun[] urunlerSourceSol =
        {
            new KadinUrun{Name="Kadın Atkı Ve Bere",Image ="kadinAksesuar1",Discount = "-%50",Price="1.799,00 TL", DiscountedPrice = "899,00 TL"},
            new KadinUrun{Name="Kahverengi Logo Nakışlı Kadın Şapka",Image ="kadinAksesuar2",Discount = "-%30",Price="2.199,00 TL", DiscountedPrice = "1.549,00 TL"},
            new KadinUrun{Name="Antrasit Kuş Logolu Kadın Yün Eldiven",Image ="kadinAksesuar3",Discount = "-%42",Price="1.799,00 TL", DiscountedPrice = "1.049,00 TL"},
            new KadinUrun{Name="Köstek Göz Kalp Madalyonlu Kadın Zincir Kolye",Image ="kadinAksesuar4",Discount = "-%48",Price="1.799,00 TL", DiscountedPrice = "929,00 TL"},
            new KadinUrun{Name="Güneş Gözlüğü",Image ="kadinAksesuar5",Discount = "-%50",Price="10.750,00 TL", DiscountedPrice = "5.350,00 TL"},

        };
        public kadinAksesuar()
        {
            InitializeComponent();

            urunler = new ObservableCollection<KadinUrun>(urunlerSourceSol);

            myCollectionView.ItemsSource = urunler;


            BindingContext = this;
        }
        private void myCollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var ayakkabiUrun = e.CurrentSelection.FirstOrDefault() as KadinUrun;
            Navigation.PushAsync(new KadinUrunSayfasi(ayakkabiUrun.Name, ayakkabiUrun.Image, ayakkabiUrun.Discount, ayakkabiUrun.Price, ayakkabiUrun.DiscountedPrice));
        }
    }
}