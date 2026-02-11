using DeviceSimulation.Domain.Components;
using DeviceSimulation.Domain.Services;

namespace DeviceSimulation.Domain.Devices;

public class Laptop : ComputerDevice
{
    public Laptop(
        string name,
        PowerManager power,
        SoftwareManager software,
        NetworkManager network,
        PeripheralManager peripherals)
        : base(name, power, software, network, peripherals)
    {
    }
}
