using MAUICrudApp.ViewModel;

namespace MAUICrudApp.Pages
{
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = new UserListPageViewModel();
        }
    }
}
