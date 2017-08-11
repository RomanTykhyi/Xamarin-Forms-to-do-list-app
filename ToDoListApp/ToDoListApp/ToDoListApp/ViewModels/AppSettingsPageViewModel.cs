using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListApp.Abstractions;
using ToDoListApp.Enums;
using Xamarin.Forms;

namespace ToDoListApp.ViewModels
{
    public class AppSettingsPageViewModel : BindableBase, INavigationAware
    {
        #region Properties
        public List<string> Languages
        {
            get { return _languages; }
            set { SetProperty(ref _languages, value); }
        }

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                SetProperty(ref _selectedLanguage, value);

                OnSettingLanguage();
            }
        }

        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

        public string LanuageOfSpeechImageSource
        {
            get { return _lanuageOfSpeechImageSource; }
            set { SetProperty(ref _lanuageOfSpeechImageSource, value); }
        }
        #endregion

        #region Constructor 
        public AppSettingsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Languages = Enum.GetNames(typeof(Language)).ToList();            
        }
        #endregion

        #region Methods        
        private void OnSettingLanguage()
        {
            if (SelectedLanguage == Language.English.ToString())
            {
                LanuageOfSpeechImageSource = "EnglishCircle";
                AppSettings.VoiceLanguage = Language.English;

                var speaker = DependencyService.Get<ITextToSpeech>();
                speaker.Language = Enums.Language.English;
            }
            else if (SelectedLanguage == Language.Ukrainian.ToString())
            {
                LanuageOfSpeechImageSource = "UkrainianCircle";
                AppSettings.VoiceLanguage = Language.Ukrainian;

                var speaker = DependencyService.Get<ITextToSpeech>();
                speaker.Language = Enums.Language.Ukrainian;
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("PageTitle"))
            {
                PageTitle = (string)parameters["PageTitle"];
            }

            SelectedLanguage = AppSettings.VoiceLanguage.ToString();

            OnSettingLanguage();
        }
        #endregion

        #region Fields        
        private readonly INavigationService _navigationService;
        private List<string> _languages;
        private string _lanuageOfSpeechImageSource;
        private string _pageTitle;
        private string _selectedLanguage;
        #endregion
    }
}