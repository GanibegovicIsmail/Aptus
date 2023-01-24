using Xamarin.Essentials;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Aptus.Data;
using Aptus.Models;

namespace Aptus
{
    public partial class ProfilePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public ProfilePage()
        {
            InitializeComponent();
            EmailLabel.Text = UserSession.Email;
            UsernameLabel.Text = UserSession.Username;
            _connection = new SQLiteAsyncConnection(Database.DatabasePath, Database.Flags);
            ChangePasswordButton.Clicked += ChangePasswordButton_Clicked;
        }
        private async void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {
            var oldPassword = OldPasswordEntry.Text;
            var newPassword = NewPasswordEntry.Text;
            var confirmPassword = ConfirmPasswordEntry.Text;

            var currentUser = await _connection.Table<User>().Where(u => u.Email == UserSession.Email).FirstOrDefaultAsync();
            if (currentUser != null)
            {
                // Compare old password with the one in the database
                if (currentUser.Password == oldPassword)
                {
                    // Compare new and confirm passwords
                    if (newPassword == confirmPassword)
                    {
                        // Update the password in the database
                        currentUser.Password = newPassword;
                        await _connection.UpdateAsync(currentUser);

                        // Show a message "Password changed successfully"
                        await DisplayAlert("Success", "Password changed successfully", "OK");
                    }
                    else
                    {
                        // Show an error message "New password and confirm password do not match"
                        await DisplayAlert("Error", "New password and confirm password do not match", "OK");
                    }
                }
                else
                {
                    // Show an error message "Incorrect old password"
                    await DisplayAlert("Error", "Incorrect old password", "OK");
                }
            }
        }

    }
}
