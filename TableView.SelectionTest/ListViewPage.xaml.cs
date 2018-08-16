using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace TableView.SelectionTest
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            var data = new List<TestItem>();
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });
            data.Add(new TestItem { Name = "Click Me" });

            listView.ItemsSource = data;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as TestItem;
            item.Name = "I was clicked";
        }
    }

    public class TestItem : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set 
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
