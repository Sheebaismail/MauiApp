using MAUICrudApp.Pages;

namespace MAUICrudApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(EditUserPage), typeof(EditUserPage));
            Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage)); // AddUserPage route registration is fine
        }
    }
}
