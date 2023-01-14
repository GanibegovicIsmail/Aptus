namespace Aptus;

public partial class NextPage2 : ContentPage
{
	public NextPage2()
	{
		InitializeComponent();
	}
    private void OnNextButton2Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NextPage3());
    }
    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        resultSlider.Text = Slider1.Value.ToString();
        double roundedValue = Math.Round(e.NewValue, 2);
        Slider1.Value = roundedValue;
    }
}

