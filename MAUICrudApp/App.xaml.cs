using MAUICrudApp.Pages;

namespace MAUICrudApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set AppShell as the main page
            MainPage = new AppShell();
        }
    }
}
