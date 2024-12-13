using MAUICrudApp.ViewModel;

namespace MAUICrudApp.Pages
{
    public partial class AddUserPage : ContentPage
    {
        public AddUserPage(UserListPageViewModel userListPageViewModel)
        {
            InitializeComponent();
            BindingContext = new AddUserPageViewModel(userListPageViewModel);
        }
    }
}
