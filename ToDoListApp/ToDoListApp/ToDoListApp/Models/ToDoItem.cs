using Prism.Mvvm;
using SQLite;

namespace ToDoListApp.Models
{
    public class ToDoItem : BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        public bool Done
        {
            get { return _done; }
            set { SetProperty(ref _done, value); }
        }

        public ToDoItem()
        {

        }

        private bool _done;
        private string _title;
        private string _notes;
    }
}
