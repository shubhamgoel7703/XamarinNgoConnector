using System;
using Android.Content;
using Xamarin.Forms;

namespace iConnect.Droid.Helpers
{
    public class NativeClass : Interfaces.INativeClass
    {
        public NativeClass()
        {
        }

        public void OpenMaps()
        {
			var geoUri = Android.Net.Uri.Parse("geo:13.374260,77.120824");
			var mapIntent = new Intent(Intent.ActionView, geoUri);
            Forms.Context.StartActivity(mapIntent);
        }

		/*public bool Email(string emailAddress)
		{
			var intent = new Intent(Intent.ActionSend);
			intent.SetType("message/rfc822");
			intent.PutExtra(Intent.ExtraEmail, new[] { emailAddress });
			Forms.Context.StartActivity(Intent.CreateChooser(intent, "Send email"));
			// ^^ Forms.Context can be used (requires 'using Xamarin.Forms;') 
			return true;
		}*/
    }
}
