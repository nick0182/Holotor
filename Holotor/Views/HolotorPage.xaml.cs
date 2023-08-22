using System.Diagnostics;
using Holotor.Core.Contracts.Services;
using Holotor.Core.Services;
using Holotor.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Navigation;
using Windows.Media.Core;

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
        var holotorPathUri = new Uri(Path.Combine(AppContext.BaseDirectory, "Assets/countdown_test.mp4"));
        HolotorMedia.Source = MediaSource.CreateFromUri(holotorPathUri);

        // TODO: learn about MSAL.NET for Oauth2 flow (see bookmark)
        // TODO: learn about MVVM Toolkit (see bookmark)
        
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        var dispatcherTimer = new DispatcherTimer();
        var timesTicked = 4;
        var lastPosition = TimeSpan.Zero;
        dispatcherTimer.Tick += ((sender, e) =>
        {
            if (timesTicked % 4 == 0)
            {
                lastPosition = ViewModel.SeekPosition();
            }
            Debug.WriteLine("{0}; Seeking to position: {1}", Thread.CurrentThread.ManagedThreadId, lastPosition);
            HolotorMedia.MediaPlayer.Position = lastPosition;
            timesTicked++;
        });
        dispatcherTimer.Interval = new(0, 0, 1);
        dispatcherTimer.Start();
    }
}
