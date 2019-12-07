using System;
using System.Drawing;
using BookSwap.Local.iOS;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(ViewLocationFetcher))]
namespace BookSwap.Local.iOS
{
    public class ViewLocationFetcher : IViewLocationFetcher
    {
        public PointF GetCoordinates(VisualElement view)
        {
            var renderer = Xamarin.Forms.Platform.iOS.Platform.GetRenderer(view);
            var nativeView = renderer.NativeView;

            var rect = nativeView.Superview.ConvertPointToView(nativeView.Frame.Location, null);
            return rect.ToSystemPointF();
        }
    }
}
