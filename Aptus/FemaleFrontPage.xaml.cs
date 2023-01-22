using Aptus.ViewModels;

namespace Aptus;

public partial class FemaleFrontPage : ContentPage
{
    public FemaleFrontPage()
    {
        InitializeComponent();
        this.BindingContext = new IntroScreenViewModel2();
    }
}