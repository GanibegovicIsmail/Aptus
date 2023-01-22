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
                     
                        await Navigation.PushAsync(new BMIHeightPage());
                    }
                    else
                    {
                    
                        await DisplayAlert("Error", "Incorrect password", "Ok");
                    }
                }
                else
                {
                
                    await DisplayAlert("Error", "User with this email does not exist!", "Ok");
                }
            }
            catch (Exception ex)
            {
              
                await DisplayAlert("Error", ex.Message, "OK");
            }



        }
        private void OnBackButton5Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        void TapGestureRecognizer_Tapped_For_SignUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}