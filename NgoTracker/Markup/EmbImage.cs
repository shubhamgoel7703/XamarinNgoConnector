using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace iConnect.Markup
{
	[ContentProperty("ResourceId")]
	public class EmbImage : IMarkupExtension
	{
		public string ResourceId { get; set; }
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (String.IsNullOrWhiteSpace(ResourceId))
				return null;

			var imageSource = ImageSource.FromResource(ResourceId);
			return imageSource;
		}

	}
}
