using Aptus.ViewModels;

namespace Aptus;

public partial class MaleFrontPage : ContentPage
{
    public MaleFrontPage()
    {
        InitializeComponent();
        this.BindingContext = new IntroScreenViewModel();
    }
}