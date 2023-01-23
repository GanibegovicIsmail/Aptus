using Xamarin.Essentials;
using System.IO;
using System.Threading.Tasks;

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

        private async void AddPictureButton_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();
            if (file != null)
            {
                ProfilePicture.Source = ImageSource.FromStream(() => new MemoryStream(file.DataArray));
                UserSession.ProfilePicture = file.DataArray;
            }
        }
    }
}
