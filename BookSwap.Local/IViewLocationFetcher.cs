using System;
namespace BookSwap.Local
{
    public interface IViewLocationFetcher
    {
        System.Drawing.PointF GetCoordinates(global::Xamarin.Forms.VisualElement view);
    }
}
