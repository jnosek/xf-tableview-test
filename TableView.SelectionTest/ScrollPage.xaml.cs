using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TableView.SelectionTest
{
    public partial class ScrollPage : ContentPage
    {
        public ScrollPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;

            if(button != null)
                button.Text = "I was CLICKED";
        }

        void Handle_Reset(object sender, System.EventArgs e)
        {
            var list = ((Element)sender).Parent as StackLayout;

            foreach (var item in list.Children)
            {
                var button = item as Button;

                if (button != null &&
                   button != sender &&
                    button.Text != "Click Me")
                {
                    button.Text = "Click Me";
                }
            }
        }
    }
}
