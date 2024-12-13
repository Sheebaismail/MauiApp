using MAUICrudApp.Models;
using MAUICrudApp.Services;
using System.Windows.Input;

namespace MAUICrudApp.ViewModel
{
    public class EditUserPageViewModel : BindableObject
    {
        private readonly UserApiService _userApiService;
        private User _user;
        private int _userId;

        public EditUserPageViewModel(int userId)
        {
            _userApiService = new UserApiService();
            _userId = userId;
            LoadUserAsync();
            SaveUserCommand = new Command(async () => await SaveUserAsync());
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

        public ICommand SaveUserCommand { get; }

        private async Task LoadUserAsync()
        {
            User = await _userApiService.GetUserByIdAsync(_userId) ?? new User();
        }

        private async Task SaveUserAsync()
        {
            await _userApiService.UpdateUserAsync(_userId, User);
            await Application.Current.MainPage.DisplayAlert("Success", "User updated successfully", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
