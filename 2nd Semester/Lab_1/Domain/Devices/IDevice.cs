using DeviceSimulation.Domain.Operations;

namespace DeviceSimulation.Domain.Devices;

public interface IDevice
{
    string Name { get; }
    bool Execute(DeviceActionType action);
}
