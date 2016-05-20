using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomDraw;
using CustomDraw.Droid;

[assembly: ExportRenderer (typeof(ImageWithTouch), typeof(ImageWithTouchRenderer))]
namespace CustomDraw.Droid
{
	public class ImageWithTouchRenderer : ViewRenderer<ImageWithTouch, DrawSign>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ImageWithTouch> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				SetNativeControl (new DrawSign (Context));
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == ImageWithTouch.CurrentLineColorProperty.PropertyName) {
				UpdateControl ();
			}
		}

		private void UpdateControl ()
		{			
			Control.CurrentLineColor = Element.CurrentLineColor.ToAndroid ();
		}
	}
}

