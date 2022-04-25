using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class SepetSingleton
    {
        public static readonly SepetSingleton instance = new SepetSingleton();


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        int index = -1;
        public KadinUrun yeniUrun = new KadinUrun();
        public ObservableCollection<KadinUrun> sepetUrunler = new ObservableCollection<KadinUrun>();
        static SepetSingleton()
        {
            
        }

        

        public static SepetSingleton Instance
        {
            get
            {
                return instance;
            }
        }
        
        public void SepeteEkle(string Name, string Image, string Discount, string Price, string DiscountedPrice, string BedenPicker, string RenkPicker)
        {



            yeniUrun.Name = Name;
            yeniUrun.Image = Image;
            yeniUrun.Discount = Discount;
            yeniUrun.Price = Price;
            yeniUrun.DiscountedPrice = DiscountedPrice;
            yeniUrun.BedenPicker = BedenPicker;
            yeniUrun.RenkPicker = RenkPicker;

            index++;
         sepetUrunler.Add(yeniUrun);
                

            
            


        }
       public void sil(KadinUrun urun)
        {
            sepetUrunler.Remove(urun);
        }
        
        

    }
}
    

