using DeviceSimulation.Domain.Operations;

namespace DeviceSimulation.Domain.Services;

public class SoftwareManager
{
    private readonly HashSet<DeviceActionType> _installed = new();

    public void Install(DeviceActionType action)
        => _installed.Add(action);

    public bool IsInstalled(DeviceActionType action)
        => _installed.Contains(action);
}
