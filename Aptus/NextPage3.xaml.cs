namespace Aptus;

public partial class NextPage3 : ContentPage
{
    public NextPage3()
    {
        InitializeComponent();
    }
    private void OnNextButton3Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NextPage4());
    }
    private void OnBackButton3Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        resultSlider.Text = Slider1.Value.ToString();
        double roundedValue = Math.Round(e.NewValue, 2);
        Slider1.Value = roundedValue;
    }
}