using DeviceSimulation.Domain.Components;
using DeviceSimulation.Domain.Operations;
using DeviceSimulation.Domain.Services;

namespace DeviceSimulation.Domain.Devices;

public class ComputerDevice : IDevice
{
    public string Name { get; }

    private readonly PowerManager _power;
    private readonly SoftwareManager _software;
    private readonly NetworkManager _network;
    private readonly PeripheralManager _peripherals;

    public ComputerDevice(
        string name,
        PowerManager power,
        SoftwareManager software,
        NetworkManager network,
        PeripheralManager peripherals)
    {
        Name = name;
        _power = power;
        _software = software;
        _network = network;
        _peripherals = peripherals;
    }

    public bool Execute(DeviceActionType action)
    {
        bool intensive = action == DeviceActionType.PlayGames
                      || action == DeviceActionType.WatchVideo;

        if (!_power.CanOperate(intensive))
            return false;

        if (!_software.IsInstalled(action))
            return false;

        if (action == DeviceActionType.Chat && !_network.IsConnected)
            return false;

        if ((action == DeviceActionType.ListenMusic ||
             action == DeviceActionType.WatchVideo)
             && !_peripherals.HasAudioOutput)
            return false;

        if (action == DeviceActionType.Print &&
            !_peripherals.HasPrinter)
            return false;

        return true;
    }
}
