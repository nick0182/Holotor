using Holotor.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Holotor.Views;

public sealed partial class HolotorPage : Page
{
    public HolotorViewModel ViewModel
    {
        get;
    }

    public HolotorPage()
    {
        ViewModel = App.GetService<HolotorViewModel>();
        InitializeComponent();
    }
}
