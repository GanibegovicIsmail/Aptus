using Aptus.ViewModels;

namespace Aptus;

public partial class IntroScreenView : ContentPage
{
    public IntroScreenView()
    {
        InitializeComponent();
        this.BindingContext = new IntroScreenViewModel();
    }
}