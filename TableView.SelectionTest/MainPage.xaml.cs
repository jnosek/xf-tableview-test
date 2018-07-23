
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
    }
}
