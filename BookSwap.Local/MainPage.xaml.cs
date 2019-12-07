using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSwap.Local.Model;
using BookSwap.Local.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace BookSwap.Local
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKPaint _backgroundPaint;
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = App.MainViewModel;
            
            Color color = Color.FromHex("#FFF571");
            _accentColor = color.ToSKColor();
            _accentDarkColor = color.WithLuminosity(color.Luminosity - .2).ToSKColor();
            _accentExtraDarkColor = color.WithLuminosity(color.Luminosity - .25).ToSKColor();
            _backgroundPaint = new SKPaint() { Color = Color.FromHex("#FFF571").ToSKColor() };

            _accentPaint = new SKPaint() { Color = _accentColor };
            _accentDarkPaint = new SKPaint() { Color = _accentDarkColor };
            _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor };

            var eff = new XFUtils.Effects.ScrollReporterEffect();
            eff.ScrollChanged += Eff_ScrollChanged;
            BooksListView.Effects.Add(eff);
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#fff571");
        }

        private void Eff_ScrollChanged(object arg1, XFUtils.Effects.ScrollEventArgs args)
        {
            MessagingCenter.Send<ScrollMessage,double>(new ScrollMessage(), ScrollMessage.ScrollChanged,args.Y);
        }

        private void SkCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawRect(info.Rect, _backgroundPaint);

            using(SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * .7f, 0);
                path.LineTo(info.Width * .2f, info.Height);
                path.LineTo(0, info.Height);
                path.Close();

                canvas.DrawPath(path, _accentDarkPaint);
            }


            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * .33f, 0);
                path.LineTo(0, info.Height *.6f);
                path.Close();

                canvas.DrawPath(path, _accentExtraDarkPaint);
            }
        }

        private async void BookListView_ItemTapped(object sender,ItemTappedEventArgs e)
        {
            ((BooksViewModel)BindingContext).SelectedBook = e.Item as Book;
            await Navigation.PushAsync(new SwapDetails());
        }
    }
}