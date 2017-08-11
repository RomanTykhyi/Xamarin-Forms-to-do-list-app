using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Abstractions;
using Xamarin.Forms;

namespace ToDoListApp.Services
{
    public class ItemAnnouncementService : IItemAnnouncementService
    {
        #region Constructor        
        public ItemAnnouncementService()
        {
            _speaker = DependencyService.Get<ITextToSpeech>();
        }
        #endregion

        #region Methods        
        public void AnnounceItemInEngish(string title, string notes, bool done)
        {
            if (String.IsNullOrEmpty(title))
                _title = "Title is empty";
            else
                _title = title;

            if (String.IsNullOrEmpty(notes))
                _notes = "There are not any notes";
            else
                _notes = notes;

            if (done)
                _done = "Completed";
            else
                _done = "Not done";

            _speaker.Speak(_title + "." + _notes + "." + _done);
        }

        public void AnnounceItemInUkrainian(string title, string notes, bool done)
        {           
            if (String.IsNullOrEmpty(title))
                _title = "Заголовок не вказаний";
            else
                _title = title;

            if (String.IsNullOrEmpty(notes))
                _notes = "Нотаток немає";
            else
                _notes = notes;

            if (done)
                _done = "Виконано";
            else
                _done = "Не виконано";

            _speaker.Speak(_title + "." + _notes + "." + _done);
        }

        public void SayItemSavedInEnglish()
        {
            _speaker.Speak("Item saved");
        }

        public void SayItemSavedInUkrainian()
        {
            _speaker.Speak("Збережено");
        }

        public void SayItemDeletedInEnglish()
        {
            _speaker.Speak("Item deleted");
        }

        public void SayItemDeletedInUkrainian()
        {
            _speaker.Speak("Видалено"); 
        }
        #endregion

        #region Fields        
        private readonly ITextToSpeech _speaker;
        private string _title;
        private string _notes;
        private string _done;
        #endregion
    }
}