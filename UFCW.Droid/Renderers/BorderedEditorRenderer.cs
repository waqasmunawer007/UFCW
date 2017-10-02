using System;
using UFCW.Droid;
using UFCW.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorederedEditor), typeof(EditorRenderer))]
namespace UFCW.Droid.Renderers
{
    public class BorderedEditorRenderer: EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Background = Resources.GetDrawable(Resource.Drawable.EditTextProperties);

			}
		}
    }
}
