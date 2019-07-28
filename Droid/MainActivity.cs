using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using iConnect;
using Android.Content.Res;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Android.Locations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace iConnect.Droid
{
    [Activity(Label = "iConnect.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static IAmazonDynamoDB client;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //LoadNgoDescription();    
            //LoadNgoNamesList();
             AWSClass aws = new AWSClass();
           
			global::Xamarin.Forms.Forms.Init(this, bundle); 

            LoadApplication(new App());
        }






        public void LoadNgoNamesList()
        {
            TotalLists.ngoNamesList = (List<NGOObject>)DeSerializeFunction<NGOObject>("NgoObjects.json");

        }

        public void LoadNgoDescription()
        {
            TotalLists.ngoDescriptionList = (List<NGODescription>)DeSerializeFunction<NGODescription>("NgosData459.json");
        }


        IList<T> DeSerializeFunction<T>(String path)
        {
			string content;
			AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open(path)))
			{
				content = sr.ReadToEnd();
			}
            return JsonConvert.DeserializeObject<List<T>>(content); ;
			
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}
