using System;
using System.Collections.Generic;
using iConnect.Interfaces;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace iConnect
{
    public partial class MainPage : TabbedPage
    {
        void TrackButtonClicked(object sender, System.EventArgs e)
        {
            nativeClass.OpenMaps();
        }

        public async void FetchCurrentLocation()
        {
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10), null);
			Console.WriteLine("Position Status: {0}", position.Timestamp);
			Console.WriteLine("Position Latitude: {0}", position.Latitude);
			Console.WriteLine("Position Longitude: {0}", position.Longitude);
        }


        void SearchBoxEvent(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if ((((Entry)sender).Text)==null)
                return;
            List<NGOObject> SeachList = new List<NGOObject>();
            foreach (var item in TotalLists.ngoNamesList)
            {
                if(item.name.IndexOf((((Entry)sender).Text), StringComparison.OrdinalIgnoreCase) >= 0)
				SeachList.Add(item);
               
            }
            ngoList.ItemsSource = SeachList;
        }

        void PickerEvent(object sender, System.EventArgs e)
        {
            Picker p = (Picker)sender;
            string filterBy = p.SelectedItem.ToString();
            List<NGOObject> UpdatedFilteredList = new List<NGOObject>();

            foreach (var item in TotalLists.ngoNamesList)
            {
                if(item.type.Equals(((Picker)sender).SelectedItem.ToString()))
                {
                    UpdatedFilteredList.Add(item);
                }
            }
          //  TotalLists.ngoNamesList = UpdatedFilteredList;
            ngoList.ItemsSource = UpdatedFilteredList;
        }

        public List<String> ngoDescription;
       
        void TypeFilterList()
        {
            List<String> filteredList = new List<string>();

            foreach (var item in TotalLists.ngoDescriptionList)
            {
                if (item.Sections[1].Fields.ContainsKey("Type of NGODescription") && !filteredList.Contains(item.Sections[1].Fields["Type of NGODescription"]))
                {
                    filteredList.Add(item.Sections[1].Fields["Type of NGODescription"]);
                }
            }
            TotalLists.filteredList = filteredList;
        }

        INativeClass nativeClass;

        public MainPage()
        {
            InitializeComponent();

            ngoList.ItemsSource = TotalLists.ngoNamesList;//ngoNamesList;
            //TypeFilterList();
            picker.ItemsSource = TotalLists.filteredList;
            filterImage.Source = ImageSource.FromResource("iConnect.Images.filter.png");
            searchImage.Source = ImageSource.FromResource("iConnect.Images.search.png");
            nearbyImage.Source = ImageSource.FromResource("iConnect.Images.nearby.png");

			 nativeClass = DependencyService.Get<INativeClass>();

            List<iConnectTable> list = new List<iConnectTable>();
            iConnectTable obj = new iConnectTable();
            obj.Name = "Shubham";
            obj.EventName = "Event Name";
            obj.Message = "Jai Ma BhaderKali";
            obj.Date = new DateTime(1992, 9, 10);
            list.Add(obj);

            liveFeedList.ItemsSource = list;
		}

        
         void NgoListTappedEvent(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            TotalLists.SelectedNGO = TotalLists.ngoDescriptionList[((NGOObject)e.Item).index];

			//FetchCurrentLocation();

            Navigation.PushAsync(new DescriptionPage());

        }
    }

    public class NGOObject
    {
        public string name { get; set; }
        public string type { get; set; }
        public int index { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
		double longitude{ get; set;}
        double latitude { get; set;}
    }

    public class NGODescription
    {
        public List<Section> Sections { get; set; } = new List<Section>();
    }

    public class Section
    {
        public string Heading { get; set; }
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();
    }
}
