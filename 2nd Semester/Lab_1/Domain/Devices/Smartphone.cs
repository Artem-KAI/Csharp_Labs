using DeviceSimulation.Domain.Components;
using DeviceSimulation.Domain.Services;

namespace DeviceSimulation.Domain.Devices;

public class Smartphone : ComputerDevice
{
    public Smartphone(
        string name,
        PowerManager power,
        SoftwareManager software,
        NetworkManager network,
        PeripheralManager peripherals)
        : base(name, power, software, network, peripherals)
    {
    }
}
