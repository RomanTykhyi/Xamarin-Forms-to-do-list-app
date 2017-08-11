using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoListApp.Views
{
    public partial class ToDoItemPage : ContentPage
    {
        public ToDoItemPage()
        {
            InitializeComponent();            
        }

        private async void AnnounceButtonTapped(object sender, System.EventArgs e)
        {
            var defaultColor = announceButton.BackgroundColor;

            announceButton.FillColor = Color.LightGray;
            
            await Task.Delay(150);

            announceButton.FillColor = defaultColor;
        }
    }
}
