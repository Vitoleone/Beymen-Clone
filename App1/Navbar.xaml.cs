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
    public partial class Navbar : Xamarin.Forms.TabbedPage
    {
        public ObservableCollection<KadinUrun> sepetUrunler;
        public KadinUrun yeniUrun;
      

        //Birinci Carousel için resimleri tutacak liste oluşturma
        public class ImageCarouselOne
        {
            public ImageSource ilkCarouselImage { get; set; }

        }
        private ObservableCollection<ImageCarouselOne> ilkCarouselView;
        public ObservableCollection<ImageCarouselOne> IlkCarouselView
        {
            get { return ilkCarouselView; }
            set
            {
                ilkCarouselView = value;
                OnPropertyChanged();
            }
        }

        //İkinci Carousel için resimleri tutacak liste oluşturma
        public class ImageCarouselTwo
        {
            public ImageSource ikinciCarouselImage { get; set; }

        }
        private ObservableCollection<ImageCarouselTwo> ikinciCarouselView;
        public ObservableCollection<ImageCarouselTwo> IkinciCarouselView
        {
            get { return ikinciCarouselView; }
            set
            {
                ikinciCarouselView = value;
                OnPropertyChanged();
            }
        }
        //Üçüncü Carousel için resimleri tutacak liste
        public class ImageCarouselThird
        {
            public ImageSource ucuncuCarouselImage { get; set; }

        }
        private ObservableCollection<ImageCarouselThird> ucuncuCarouselView;
        public ObservableCollection<ImageCarouselThird> UcuncuCarouselView
        {
            get { return ucuncuCarouselView; }
            set
            {
                ucuncuCarouselView = value;
                OnPropertyChanged();
            }
        }
        //Carousel bitiş

        //searchBar Başlangıç
        public ObservableCollection<ProductModel> products;
        public ObservableCollection<KadinUrun> urunler;

        ObservableCollection<ProductModel> removedItems = new ObservableCollection<ProductModel>();
        private readonly ProductModel[] sourceItems =
            {
                new ProductModel{Name ="KADIN", Image="Kadin",
                },
                new ProductModel{Name ="ERKEK", Image="erkek_cleanup",
                }
            };
       

        //searchbar Bitiş
      
        public Navbar()
        {

            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom); //navbar'ı aşağıya atar
           
            BindingContext = this;
            
           
            //Searchbar Başlangıç

            products = new ObservableCollection<ProductModel>(sourceItems);
            ;
            urunler = new ObservableCollection<KadinUrun>(SepetSingleton.Instance.sepetUrunler);
            sepetimUrunler.ItemsSource = SepetSingleton.Instance.sepetUrunler;
            myCollectionView.ItemsSource = products;
   
            //SearchBar Bitiş

            IlkCarouselView = new ObservableCollection<ImageCarouselOne>
            {
                new ImageCarouselOne{ilkCarouselImage = "https://cdn.beymen.com/bannerimages/BEYMEN_12G_Mobil_2022013115432842704.png"},
                new ImageCarouselOne{ilkCarouselImage = "https://cdn.beymen.com/bannerimages/12gmobil_2022022517311138166.png"},
                new ImageCarouselOne{ilkCarouselImage = "https://cdn.beymen.com/bannerimages/12gmobil_2022021421375512038.jpg"},
                new ImageCarouselOne{ilkCarouselImage = "https://cdn.beymen.com/bannerimages/12gmobil_2022022411344023272.png"},
                new ImageCarouselOne{ilkCarouselImage = "https://cdn.beymen.com/bannerimages/12gmobil_2022022411272308076.png"},

            };
            IkinciCarouselView = new ObservableCollection<ImageCarouselTwo>
            {
                new ImageCarouselTwo{ikinciCarouselImage ="https://cdn.beymen.com/bannerimages/BEYMEN_9G_Mobil_2022022418281949327.png"},
                new ImageCarouselTwo{ikinciCarouselImage ="https://cdn.beymen.com/bannerimages/9G_MOBIL_2022022420054818657.jpg"},
                new ImageCarouselTwo{ikinciCarouselImage ="https://cdn.beymen.com/bannerimages/BEYMEN_9G_Mobil_2022022114412501715.png"},
                new ImageCarouselTwo{ikinciCarouselImage ="https://cdn.beymen.com/bannerimages/BEYMEN_9G_Mobil_2021112408292311361.png"},

            };
            UcuncuCarouselView = new ObservableCollection<ImageCarouselThird>
            {
                new ImageCarouselThird{ucuncuCarouselImage ="https://cdn.beymen.com/bannerimages/9GMobile_2022010708234869014.jpg"},
                new ImageCarouselThird{ucuncuCarouselImage ="https://cdn.beymen.com/bannerimages/9GMobile_2022010708242629555.jpg"},
                new ImageCarouselThird{ucuncuCarouselImage ="https://cdn.beymen.com/bannerimages/9GMobile_2022010708252739998.jpg"},
                new ImageCarouselThird{ucuncuCarouselImage ="https://cdn.beymen.com/bannerimages/9GMobile_2022020408455443613.jpg"},

            };



        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue.ToUpper();


            foreach (ProductModel sourceItem in sourceItems)
            {
                if (!sourceItem.Name.StartsWith(searchTerm) && !removedItems.Contains(sourceItem))
                {

                    removedItems.Add(sourceItem);

                    products.Remove(sourceItem);
                }

            }
            if (removedItems.Count > 0)
            {
                foreach (ProductModel removedItem in removedItems.ToList())
                {
                    if (removedItem.Name.StartsWith(searchTerm) || string.IsNullOrWhiteSpace(searchTerm))
                    {
                        products.Add(removedItem);
                        removedItems.Remove(removedItem);
                        if (removedItems.Count == 0)
                        {
                            break;
                        }
                    }

                }
            }


        }

        private void Kadin(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {

            var b = e.CurrentSelection.FirstOrDefault() as ProductModel;


            if (b.Name == "KADIN")
            {
                Navigation.PushAsync(new kategoriAltSayfasi());

            }
            else if (b.Name == "ERKEK")
            {
                Navigation.PushAsync(new erkekKategori());

            }
            

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new kategoriAltSayfasi());
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            if (SepetSingleton.Instance.sepetUrunler.Count == 0)
            {
                SepetSatinalButon.IsVisible = false;
            }
            else
            {
                SepetSatinalButon.IsVisible = true;
            }
            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {   
            var button = sender as Xamarin.Forms.Button;
            var vm = button.BindingContext as KadinUrun;
            SepetSingleton.Instance.sil(vm);

        }


    }
}