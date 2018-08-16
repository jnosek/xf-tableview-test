using System;
using Foundation;
using UIKit;
using XF = Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TableView.SelectionTest.iOS
{
    public class CustomTableViewModelRenderer : TableViewModelRenderer
    {
        public CustomTableViewModelRenderer(XF.TableView model)
            : base(model)
        {
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            View.Model.RowSelected(indexPath.Section, indexPath.Row);
            if (AutomaticallyDeselect)
                tableView.DeselectRow(indexPath, true);

            tableView.EndEditing(true);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            BindGestures(tableView);
            return View.Model.GetSectionCount();
        }

        void BindGestures(UITableView tableview)
        {
            if (HasBoundGestures)
                return;

            HasBoundGestures = true;

            var gesture = new UILongPressGestureRecognizer(LongPress);
            gesture.MinimumPressDuration = 2;
            tableview.AddGestureRecognizer(gesture);

            var dismissGesture = new UITapGestureRecognizer(Tap);
            dismissGesture.CancelsTouchesInView = false;
            tableview.AddGestureRecognizer(dismissGesture);

            Table = tableview;
        }

        void Tap(UITapGestureRecognizer gesture)
        {
            // if the gesture point is in the view and maps to a table index, do not end editing
            // this forces the keyboard to close, adjusting the screen and changing the index on RowSelected
            // the keyboard should close after RowSelected is complete

            var point = gesture.LocationInView(Table);
            var indexPath = Table.IndexPathForRowAtPoint(point);
            if (indexPath != null)
                return;

            gesture.View.EndEditing(true);
        }
    }
}
