using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(iConnect.Droid.Helpers.NativeClass))]
namespace iConnect.Interfaces
{
    public interface INativeClass
    {
        void OpenMaps();
    }
}
