using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListApp.Abstractions;
using ToDoListApp.Models;
using Xamarin.Forms;

namespace ToDoListApp.ViewModels
{
    public class ToDoItemPageViewModel : BindableBase, INavigationAware
    {
        #region Properties
        public ICommand SaveItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand SpeakCommand { get; set; }
        public ICommand SpeechToTitleCommand { get; set; }
        public ICommand SpeechToNotesCommand { get; set; }

        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

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
        #endregion

        #region Constructor        
        public ToDoItemPageViewModel(INavigationService navigationService, IItemAnnouncementService itemAnnouncementService, 
            IToDoItemRepository toDoItemsRepository, IVoiceRecognitionService voiceRecognitionService)
        {
            _navigationService = navigationService;
            _itemAnnouncementService = itemAnnouncementService;
            _voiceRecognitionService = voiceRecognitionService;

            _toDoItemsRepository = toDoItemsRepository;

            SaveItemCommand = new DelegateCommand(OnSaveItem);
            DeleteItemCommand = new DelegateCommand(OnDeleteItem);
            GoBackCommand = new DelegateCommand(OnGoBack);
            SpeakCommand = new DelegateCommand(OnSpeak);
            SpeechToTitleCommand = new DelegateCommand(OnSpeechToTitle);
            SpeechToNotesCommand = new DelegateCommand(OnSpeechToNotes);
        }
        #endregion

        #region Methods        
        private async void OnSaveItem()
        {
            var toDoItem = new ToDoItem()
            {
                ID = _itemId,
                Title = _title,
                Notes = _notes,
                Done = _done
            };

            if (AppSettings.VoiceLanguage == Enums.Language.English)
                _itemAnnouncementService.SayItemSavedInEnglish();

            else if (AppSettings.VoiceLanguage == Enums.Language.Ukrainian)
                _itemAnnouncementService.SayItemSavedInUkrainian();
                        
            await _toDoItemsRepository.SaveItemAsync(toDoItem);
            
            await _navigationService.GoBackAsync();
        }

        private async void OnDeleteItem()
        {
            var toDoItem = new ToDoItem()
            {
                ID = _itemId,
                Title = _title,
                Notes = _notes,
                Done = _done
            };

            if (AppSettings.VoiceLanguage == Enums.Language.English)
                _itemAnnouncementService.SayItemDeletedInEnglish();

            else if (AppSettings.VoiceLanguage == Enums.Language.Ukrainian)
                _itemAnnouncementService.SayItemDeletedInUkrainian();

            await _toDoItemsRepository.DeleteItemAsync(toDoItem);
            
            await _navigationService.GoBackAsync();
        }

        private async void OnGoBack()
        {
            await _navigationService.GoBackAsync();
        }

        private void OnSpeak()
        {
            if (AppSettings.VoiceLanguage == Enums.Language.English)           
                _itemAnnouncementService.AnnounceItemInEngish(Title, Notes, Done);
            
            else if(AppSettings.VoiceLanguage == Enums.Language.Ukrainian)            
                _itemAnnouncementService.AnnounceItemInUkrainian(Title, Notes, Done);            
        }

        private async void OnSpeechToTitle()
        {
            var speechToTextResult = await _voiceRecognitionService.WaitForSpeechToText();

            Title = speechToTextResult; 
        }

        private async void OnSpeechToNotes()
        {
            var speechToTextResult = await _voiceRecognitionService.WaitForSpeechToText();

            Notes = speechToTextResult;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ToDoItem"))
            {
                var item = (ToDoItem)parameters["ToDoItem"];

                _itemId = item.ID;
                Title = item.Title;
                Notes = item.Notes;
                Done = item.Done;
            }
            if (parameters.ContainsKey("PageTitle"))
            {
                PageTitle = (string)parameters["PageTitle"];
            }
        }       
        #endregion

        #region Fields        
        private readonly IToDoItemRepository _toDoItemsRepository;
        private readonly IItemAnnouncementService _itemAnnouncementService;
        private readonly INavigationService _navigationService;
        private readonly IVoiceRecognitionService _voiceRecognitionService;
        private string _pageTitle;
        private int _itemId = 0;
        private string _title;
        private string _notes;
        private bool _done;
        #endregion
    }
}