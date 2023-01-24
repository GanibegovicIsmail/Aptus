using Xamarin.Essentials;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Aptus.Data;
using Aptus.Models;
using Microsoft.Maui;


namespace Aptus
{
    public partial class ProfilePage : ContentPage
    {
        private double height = 0;
        private double weight = 0;
        private double _bmi;
        private string _classification;

        private SQLiteAsyncConnection _connection;
        private Database _database;
        public ProfilePage()
        {
            InitializeComponent();
            EmailLabel.Text = UserSession.Email;
            UsernameLabel.Text = UserSession.Username;
            _connection = new SQLiteAsyncConnection(Database.DatabasePath, Database.Flags);
            _database = new Database();
            ChangePasswordButton.Clicked += ChangePasswordButton_Clicked;
            SaveBioButton.Clicked += SaveBioButton_Clicked;
            OnAppearing();
        }

        private async void SaveBioButton_Clicked(object sender, EventArgs e)
        {
            string bio = BioEntry.Text;

            // Save the bio to the database
            _database.SaveBioAsync(bio);

            // Display a message to the user to indicate that the bio has been saved
            await DisplayAlert("Success", "Your bio has been saved!", "OK");
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


        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            height = e.NewValue;
            HeightLabel.Text = string.Format("{0:F0} cm", height);
            UpdateBmi();
        }

        private void OnValue2Changed(object sender, ValueChangedEventArgs e)
        {
            weight = e.NewValue;
            WeightLabel.Text = string.Format("{0:F0} kg", weight);
            UpdateBmi();
        }
        private void OnAppearing()
        {
            BmiValueLabel.Text = BMIResultPage.BmiValue.ToString();
        }


        private void UpdateBmi()
        {
            _bmi = Math.Round(weight / (height / 100 * height / 100), 2);
            BmiValueLabel.Text = _bmi.ToString();
            if (_bmi < 18.5)
            {
                _classification = "Underweight";
            }
            else if (_bmi >= 18.5 && _bmi <= 24.9)
            {
                _classification = "Normal weight";
            }
            else if (_bmi >= 25 && _bmi <= 29.9)
            {
                _classification = "Overweight";
            }
            else
            {
                _classification = "Obesity";
            }
            ClassificationLabel.Text = _classification;
        }
    }
}
