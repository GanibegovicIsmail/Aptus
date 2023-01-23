using Aptus;
using System;

namespace Aptus
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            EmailLabel.Text = UserSession.Email;
            UsernameLabel.Text = UserSession.Username;
        }
    }
}
