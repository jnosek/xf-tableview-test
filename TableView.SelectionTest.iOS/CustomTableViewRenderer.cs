using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF = Xamarin.Forms;

[assembly: ExportRenderer(typeof(XF.TableView), typeof(TableView.SelectionTest.iOS.CustomTableViewRenderer))]
namespace TableView.SelectionTest.iOS
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<XF.TableView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                SetSource();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XF.TableView.HasUnevenRowsProperty.PropertyName)
            {
                SetSource();
            }
        }

        void SetSource()
        {
            var modeledView = Element;
            Control.Source = modeledView.HasUnevenRows ?
                (UITableViewSource)new UnEvenTableViewModelRenderer(modeledView) :
                (UITableViewSource)new CustomTableViewModelRenderer(modeledView);
        }
    }
}
