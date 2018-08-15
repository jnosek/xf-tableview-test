
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TableView.SelectionTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var textCell = (TextCell)sender;

            textCell.Text = "I was CLICKED";
        }

        void Reset_Tapped(object sender, System.EventArgs e)
        {
            var textCell = (TextCell)sender;
            var table = (Xamarin.Forms.TableView)textCell.Parent;

            foreach (var section in table.Root)
            {
                foreach (var cell in section)
                {
                    var tc = cell as TextCell;

                    if (tc != null && 
                        tc != textCell && 
                        tc.Text != "Click Me")
                    {
                        tc.Text = "Click Me";
                    }
                }
            }
        }
    }
}
