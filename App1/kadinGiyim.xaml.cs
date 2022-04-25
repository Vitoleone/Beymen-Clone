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
    public partial class kadinGiyim : ContentPage
    {
        public ObservableCollection<KadinUrun> urunler;
        public ObservableCollection<KadinUrun> urunler2;
        private readonly KadinUrun[] urunlerSourceSol =
        {
            new KadinUrun{Name="Siyah Logolu Pilli Midi Etek",Image ="KadinGiyim1",Discount = "-%30",Price="1.499,00 TL", DiscountedPrice = "1.049,00 TL"},
            new KadinUrun{Name="Siyah Desenli Midi Gömlek Elbise",Image ="KadinGiyim2",Discount = "-%42",Price="1.799,00 TL", DiscountedPrice = "1.049,00 TL"},
            new KadinUrun{Name="Siyah Metal Düğmeli Ribli Triko Ceket",Image ="KadinGiyim3",Discount = "-%42",Price="1.799,00 TL", DiscountedPrice = "1.049,00 TL"},
            new KadinUrun{Name="Siyah Beyaz Bloklu Mini Elbise",Image ="KadinGiyim4",Discount = "-%30",Price="1.279,00 TL", DiscountedPrice = "899,00 TL"},
            new KadinUrun{Name="Camel Kapüşonlu Sweatshirt",Image ="KadinGiyim5",Discount = "-%30",Price="1099,00 TL", DiscountedPrice = "769,00 TL"},
            
        };
   

        public kadinGiyim()
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