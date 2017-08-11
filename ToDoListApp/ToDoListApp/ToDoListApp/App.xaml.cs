using Microsoft.Practices.Unity;
using Prism.Unity;
using ToDoListApp.Abstractions;
using ToDoListApp.Data;
using ToDoListApp.Models;
using ToDoListApp.Services;
using ToDoListApp.Views;
using Xamarin.Forms;

namespace ToDoListApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        
        protected override void OnInitialized()
        {
            InitializeComponent();

            AppSettings.VoiceLanguage = Enums.Language.English;
            var speaker = DependencyService.Get<ITextToSpeech>();
            speaker.Language = Enums.Language.English;

            NavigationService.NavigateAsync("MainNavigationPage/ToDoItemListPage");
            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        private void RegisterTypesForNavigation()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<ToDoItemListPage>();
            Container.RegisterTypeForNavigation<ToDoItemPage>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<AppSettingsPage>();
        }

        private void RegisterInterfaces()
        {
            Container.RegisterType<IToDoItemRepository, ToDoItemsRepository>();
            Container.RegisterType<IItemAnnouncementService, ItemAnnouncementService>();
            Container.RegisterType<IVoiceRecognitionService, VoiceRecognitionService>();
        }

        protected override void RegisterTypes()
        {
            RegisterTypesForNavigation();
            RegisterInterfaces();
        }
    }
}
