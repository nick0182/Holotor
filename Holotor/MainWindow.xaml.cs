using Holotor.Helpers;

using Windows.UI.ViewManagement;
using Holotor.Core.Services;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Holotor;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();
        var temperatureService = new TemperatureService();
        // var cts = new CancellationTokenSource();
        Task.Run(async () =>
        {
            while (true)
            {
                Debug.WriteLine("{0}; Current CPU temperature: {1}", Environment.CurrentManagedThreadId, temperatureService.GetTemperature());
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        });
    }
}
