using Holotor.Core.Contracts.Services;
using OpenHardwareMonitor.Hardware;
using System.Diagnostics;

namespace Holotor.Core.Services;
public class TemperatureService : ITemperatureService
{
    private readonly IHardware _cpu;
    private ISensor _temperatureSensor;

    public TemperatureService()
    {
        var computer = new Computer { CPUEnabled = true };
        computer.Open();
        var hardware = computer.Hardware;
        if (hardware.Length == 0)
        {
            throw new Exception("No CPU Hardware found");
        }
        _cpu = hardware[0];
        Debug.WriteLine($"CPU Hardware found: {_cpu.Name}");
    }

    public int GetTemperature()
    {
        _cpu.Update();
        if (_temperatureSensor is null)
        {
            foreach (var sensor in _cpu.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature)
                {
                    Debug.WriteLine($"Got CPU Temperature sensor: {sensor.Name}");
                    _temperatureSensor = sensor;
                    break;
                }
            }
        }
        return (int)_temperatureSensor.Value;
    }
}
