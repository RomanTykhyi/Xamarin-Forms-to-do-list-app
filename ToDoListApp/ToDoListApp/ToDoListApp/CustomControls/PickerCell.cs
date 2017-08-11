using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoListApp.CustomControls
{
    public class PickerCell : ViewCell
    {
        Label label;
        Picker picker;

        public PickerCell()
        {
            label = new Label { YAlign = TextAlignment.Center, BindingContext = this };
            label.SetBinding(Xamarin.Forms.Label.TextProperty, (PickerCell c) => c.label, BindingMode.OneWay);

            picker = new Picker { HorizontalOptions = LayoutOptions.EndAndExpand, BindingContext = this };
            picker.SetBinding(Picker.ItemsSourceProperty, (Picker c) => c.ItemsSource, BindingMode.OneWay);
            picker.SetBinding(Picker.SelectedItemProperty, (Picker c) => c.SelectedItem, BindingMode.TwoWay);

            View = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(15, 5),
                Children = { label, picker }
            };
        }
    }
}
