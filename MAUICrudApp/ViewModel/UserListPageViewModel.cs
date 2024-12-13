using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MAUICrudApp.Models;
using MAUICrudApp.Services;
using Microsoft.Maui.Controls;

namespace MAUICrudApp.ViewModel
{
    public class UserListPageViewModel : BindableObject
    {
        private readonly UserApiService _userApiService;
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToAddUserCommand { get; }
        public ICommand NavigateToEditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UserListPageViewModel()
        {
            _userApiService = new UserApiService();
            Users = new ObservableCollection<User>();

            NavigateToAddUserCommand = new Command(async () => await NavigateToAddUserAsync());
            NavigateToEditUserCommand = new Command<User>(async (user) => await NavigateToEditUserAsync(user));
            DeleteUserCommand = new Command<User>(async (user) => await DeleteUserAsync(user));

            LoadUsersAsync();
        }

        public async Task LoadUsersAsync()
        {
            var userList = await _userApiService.GetAllUsersAsync();
            Users.Clear();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }

        private async Task NavigateToAddUserAsync()
        {
            // Pass the current UserListPageViewModel instance to AddUserPage
            await Application.Current.MainPage.Navigation.PushAsync(new Pages.AddUserPage(this));
        }


        private async Task NavigateToEditUserAsync(User user)
        {
            if (user != null)
            {
                await Shell.Current.GoToAsync($"EditUserPage?userId={user.Id}");
            }
        }

        private async Task DeleteUserAsync(User user)
        {
            if (user == null) return;

            var confirm = await Application.Current.MainPage.DisplayAlert("Confirm", $"Are you sure you want to delete {user.FirstName}?", "Yes", "No");
            if (confirm)
            {
                await _userApiService.DeleteUserAsync(user.Id);
                Users.Remove(user);
            }
        }
    }
}
