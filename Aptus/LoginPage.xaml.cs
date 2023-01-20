using Aptus.Models;
using SQLite;

namespace Aptus
{
    public partial class LoginPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public LoginPage()
        {
            InitializeComponent();
            _connection = new SQLiteAsyncConnection(Data.Database.DatabasePath, Data.Database.Flags);
            LoginButton.Clicked += LoginButton_Clicked;
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                var query = _connection.Table<User>().Where(u => u.Email == EmailEntry.Text);
                var user = await query.FirstOrDefaultAsync();

                if (user != null)
                {
                    if (user.Password == PasswordEntry.Text)
                    {
                        // User exists in the database and the password is correct
                        await Navigation.PushAsync(new BMIHeightPage());
                    }
                    else
                    {
                        // User exists in the database but the password is incorrect
                        await DisplayAlert("Error", "Incorrect password", "Ok");
                    }
                }
                else
                {
                    // User does not exist in the database
                    await DisplayAlert("Error", "User with this email does not exist!", "Ok");
                }
            }
            catch (Exception ex)
            {
                // Handle any exception that may have occurred
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
        private void OnBackButton5Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        void TapGestureRecognizer_Tapped_For_SignUp(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegisterPage());
        }
    }
}