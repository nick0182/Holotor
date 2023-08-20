using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Holotor.Core.Contracts.Services;

namespace Holotor.ViewModels;

public partial class HolotorViewModel : ObservableRecipient
{
    private static readonly TimeSpan _holotorDuration = new(0, 1, 21);

    private readonly ITemperatureService _temperatureService;

    public HolotorViewModel(ITemperatureService temperatureService)
    {
        _temperatureService = temperatureService;
    }

    public TimeSpan SeekPosition()
    {
        var temperature = _temperatureService.GetTemperature();
        Debug.WriteLine("{0}; Current CPU temperature: {1}", Thread.CurrentThread.ManagedThreadId, temperature);
        var position = 100 - temperature;
        return new(0, 0, position);
    }
}
