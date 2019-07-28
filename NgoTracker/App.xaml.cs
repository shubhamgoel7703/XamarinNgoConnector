using System.Collections.Generic;
using Android.Content.Res;
using Xamarin.Forms;

namespace iConnect
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

      
    }
}
