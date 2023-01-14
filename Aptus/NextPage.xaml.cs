namespace Aptus
{
    public partial class NextPage : ContentPage
    {
        private bool _isMaleSelected = false;
        private bool _isFemaleSelected = false;

        public NextPage()
        {
            InitializeComponent();
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NextPage2());
        }

        private void OnImage3Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnMaleButtonClicked(object sender, EventArgs e)
        {
            MaleButton.Source = "maleclicked.png";
            FemaleButton.Source = "femalepng.png";
            NextButton.IsEnabled = true;
            _isMaleSelected = true;
            _isFemaleSelected = false;
        }

        private void OnFemaleButtonClicked(object sender, EventArgs e)
        {
            MaleButton.Source = "malepng.png";
            FemaleButton.Source = "femaleclicked.png";
            NextButton.IsEnabled = true;
            _isFemaleSelected = true;
            _isMaleSelected = false;
        }
    }
}
