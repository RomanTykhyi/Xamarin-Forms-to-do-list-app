using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoListApp.Views
{
    public partial class ToDoItemListPage : ContentPage
    {
        public ToDoItemListPage()
        {
            InitializeComponent();
            listView.IsPullToRefreshEnabled = true; 
        }

        private ViewCell viewCell;

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            viewCell = ((ViewCell)sender);
            viewCell.View.BackgroundColor = Color.FromHex("#eafeea");                
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            if(viewCell != null)
                viewCell.View.BackgroundColor = Color.Default;
        }        
    }
}
