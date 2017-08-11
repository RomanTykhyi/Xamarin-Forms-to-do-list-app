using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ToDoListApp.Abstractions;
using ToDoListApp.Data;
using ToDoListApp.Models;
using Xamarin.Forms;

namespace ToDoListApp.ViewModels
{
    public class ToDoItemListPageViewModel : BindableBase, INavigationAware
    {
        #region Properties
        public ICommand AddToDoItemCommand { get; set; }
        public ICommand ChangeStateCommand { get; set; }
        public ICommand EditItemCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshListViewCommand { get; set; }
        public ICommand GoToAppSettingsCommand { get; set; }

        public ToDoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {                
                SetProperty(ref _selectedItem, value);

                if (_selectedItem == null)
                    return;

                OnEditItem();

                SelectedItem = null;
            }
        }

        public ObservableRangeCollection<ToDoItem> ToDoItems
        {
            get { return _toDoItems; }
            set { SetProperty(ref _toDoItems, value); }
        }

        public bool IsListViewRefreshing
        {
            get { return _isListViewRefreshing; }
            set { SetProperty(ref _isListViewRefreshing, value); }
        }
        #endregion

        #region Constructor        
        public ToDoItemListPageViewModel(INavigationService navigationService, IToDoItemRepository toDoItemsRepository)
        {
            _navigationService = navigationService;
            _toDoItemsRepository = toDoItemsRepository;

            AddToDoItemCommand = new DelegateCommand(OnAddItem);
            ChangeStateCommand = new DelegateCommand<ToDoItem>(OnChangeState);
            EditItemCommand = new DelegateCommand(OnEditItem);
            DeleteCommand = new DelegateCommand<ToDoItem>(OnDeleteItem);
            RefreshListViewCommand = new DelegateCommand(OnListViewRefreshing);
            GoToAppSettingsCommand = new DelegateCommand(OnGoinngToAppSettings);
        }
        #endregion

        #region Methods        
        private async void OnAddItem()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("PageTitle", "Create new item");

            await _navigationService.NavigateAsync("ToDoItemPage", navParameters);
        }

        private void OnChangeState(ToDoItem item)
        {
            if (item != null)
            {
                item.Done = !item.Done;
                _toDoItemsRepository.SaveItemAsync(item);
            }
        }

        private async void OnEditItem()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("ToDoItem", SelectedItem);
            navParameters.Add("PageTitle", "Edit item");

            await _navigationService.NavigateAsync("ToDoItemPage", navParameters);            
        }

        private async void OnDeleteItem(ToDoItem item)
        {
            if (item != null)
            {
                ToDoItems.Remove(item);
                await _toDoItemsRepository.DeleteItemAsync(item);
            }
        }

        private async void OnListViewRefreshing()
        {
            ToDoItems = new ObservableRangeCollection<ToDoItem>(await _toDoItemsRepository.GetAllAsync());
            IsListViewRefreshing = false;
        }

        private async void OnGoinngToAppSettings()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("PageTitle", "Settings");

            await _navigationService.NavigateAsync("AppSettingsPage", navParameters);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            ToDoItems = new ObservableRangeCollection<ToDoItem>(await _toDoItemsRepository.GetAllAsync());
        }
        #endregion

        #region Fields        
        private readonly IToDoItemRepository _toDoItemsRepository;
        private readonly INavigationService _navigationService;
        private ObservableRangeCollection<ToDoItem> _toDoItems;
        private bool _isListViewRefreshing;
        private ToDoItem _selectedItem;
        #endregion
    }
}
