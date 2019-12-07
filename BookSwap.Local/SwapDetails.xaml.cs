using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace BookSwap.Local
{
    public partial class SwapDetails : ContentPage
    {
        SKPaint _accentToPaint;
        SKPaint _accentFromPaint;
        private double _colorAngleAnim;

        public SwapDetails()
        {
            InitializeComponent();
            this.BindingContext = App.MainViewModel;

            _accentFromPaint = new SKPaint()
            {
                Color = App.MainViewModel.SwapFromBook.Colors.Accent.ToSKColor()
            };

            _accentToPaint = new SKPaint()
            {
                Color = App.MainViewModel.SelectedBook.Colors.Accent.ToSKColor()
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            var parentAnim = new Animation();

            // animate the background angle
            parentAnim.Add(0, .3, new Animation(t =>
            {
                _colorAngleAnim = t;
                pageBackground.InvalidateSurface();
            }, 0, 200, Easing.SinInOut));

            parentAnim.Commit(this, "PageAnimations", 16, 3000);
        }

        private void PageBackground_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // fill the background
            canvas.DrawRect(info.Rect, _accentToPaint);

            // draw the top half
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width, 0);
                path.LineTo(info.Width, (info.Height / 2) - (float)_colorAngleAnim);
                path.LineTo(0, (info.Height / 2) + (float)_colorAngleAnim);
                path.Close();

                canvas.DrawPath(path, _accentFromPaint);

            }
        }
    }
}
