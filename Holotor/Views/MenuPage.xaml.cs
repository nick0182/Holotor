using Holotor.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Holotor.Views;

public sealed partial class MenuPage : Page
{
    public MenuViewModel ViewModel
    {
        get;
    }

    public MenuPage()
    {
        ViewModel = App.GetService<MenuViewModel>();
        InitializeComponent();
    }
}
