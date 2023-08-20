using Holotor.Helpers;

using Windows.UI.ViewManagement;
using Holotor.Core.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Windows.Media.Core;

namespace Holotor;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();
        Content = null;
    }
}
