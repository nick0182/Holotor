using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Holotor.Contracts.Services;

namespace Holotor.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    private readonly INavigationService _navigationService;

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private void OnButtonClicked()
    {
        Debug.WriteLine("On button clicked");
        _navigationService.NavigateTo(typeof(HolotorViewModel).FullName!);
    }
}
