using MAUICrudApp.Models;
using MAUICrudApp.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MAUICrudApp.ViewModel
{
    public class AddUserPageViewModel : BindableObject
    {
        private readonly UserApiService _userApiService;
        private User _user;

        private readonly UserListPageViewModel _userListPageViewModel;

        public AddUserPageViewModel(UserListPageViewModel userListPageViewModel)
        {
            _userApiService = new UserApiService();
            _user = new User();
            _userListPageViewModel = userListPageViewModel; 
            AddUserCommand = new Command(async () => await AddUserAsync());
        }


        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }

        private async Task AddUserAsync()
        {
            await _userApiService.AddUserAsync(User);
            await Application.Current.MainPage.DisplayAlert("Success", "User added successfully", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
            await _userListPageViewModel.LoadUsersAsync();
        }
    }
}
