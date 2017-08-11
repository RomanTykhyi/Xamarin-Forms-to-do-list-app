using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoListApp.CustomControls
{
    public class ExtendableEditor : Editor
    {
        public ExtendableEditor()
        {
            TextChanged += (sender, e) =>
            {
                // editor will extend automaticly 
                InvalidateMeasure();
            };
        }
    }
}
