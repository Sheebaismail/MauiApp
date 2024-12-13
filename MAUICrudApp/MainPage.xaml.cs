using System;
using Microsoft.Maui.Controls;

namespace MAUICrudApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToUserListClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("UserListPage"); // Ensure route is registered in AppShell
        }

        private async void OnNavigateToEditUserClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("EditUser"); // Ensure route is registered in AppShell
        }
    }
}
