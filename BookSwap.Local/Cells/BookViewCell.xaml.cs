using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSwap.Local.Model;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSwap.Local.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookViewCell : ViewCell
    {
        SKPaint _backgroundPaint;
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;

        double scrollValue;
        IViewLocationFetcher viewLocationFetcher;

        public BookViewCell()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ScrollMessage, double>(this, ScrollMessage.ScrollChanged, (sender, scrollInfo) => {

                scrollValue = scrollInfo;
                if(CellBackgoundCanvas != null)
                {
                    CellBackgoundCanvas.InvalidateSurface();
                }
            });

            viewLocationFetcher = DependencyService.Get<IViewLocationFetcher>();
        }

        private void CellBackgoundCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            //work out where cell is actually on the page
            var thisCellPosition = viewLocationFetcher.GetCoordinates(this.View);

            canvas.DrawRect(info.Rect, _accentPaint);

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo((info.Width) - thisCellPosition.Y, 0);
                //path.LineTo(info.Width * .2f, info.Height);
                path.LineTo(0, info.Height * .8f);
                path.Close();

                canvas.DrawPath(path, _accentDarkPaint);
            }



            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - (thisCellPosition.Y*2), 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();

                canvas.DrawPath(path, _accentExtraDarkPaint);
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if(BindingContext != null)
            {
                Color color = Color.FromHex(((Book)BindingContext).AccentColor);
                
                _accentColor = color.ToSKColor();
                _accentDarkColor = color.WithLuminosity(color.Luminosity - .07).ToSKColor();
                _accentExtraDarkColor = color.WithLuminosity(color.Luminosity - .15).ToSKColor();
                _backgroundPaint = new SKPaint() { Color = Color.FromHex("#FFF571").ToSKColor() };

                _accentPaint = new SKPaint() { Color = _accentColor };
                _accentDarkPaint = new SKPaint() { Color = _accentDarkColor };
                _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor };
            }
        }
    }
}
