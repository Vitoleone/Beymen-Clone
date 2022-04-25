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
    public partial class KadinUrunSayfasi : ContentPage
    {
        public KadinUrun urunler;
        int ürünSayisi = 0;
        public KadinUrunSayfasi(string Name, string Image,string Discount,string Price, string DiscountedPrice)
        {
        InitializeComponent();
        BindingContext = this;
        urunler = new KadinUrun() { Name = Name,Image = Image,Discount = Discount, Price = Price, DiscountedPrice = DiscountedPrice};
            urunIndirimlbl.Text = Discount;
            urunIndirimlilbl.Text = DiscountedPrice;
            urunIsimlbl.Text = Name;
            urunResmi.Source = Image;
            urunIndirimsizlbl.Text = Price;

        }


        void SepeteEkle(object sender, EventArgs e)
        {
            if(renkPicker.SelectedItem != null && bedenPicker.SelectedItem != null)
            {
                string renk = renkPicker.SelectedItem.ToString();
                string beden = bedenPicker.SelectedItem.ToString();
                
                DisplayAlert("", "Ürün sepetinize eklendi!", "Tamam");
                ürünSayisi++;
                SepetSingleton.Instance.SepeteEkle(urunler.Name, urunler.Image, urunler.DiscountedPrice, urunler.Price, urunler.Discount, beden, renk);
                
            }
            else
            {
                DisplayAlert("", "Lütfen renk ve beden seçiniz!", "Tamam");
                
            }
            
        }
    }
}