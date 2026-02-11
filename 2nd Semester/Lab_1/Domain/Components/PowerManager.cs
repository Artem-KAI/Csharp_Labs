using DeviceSimulation.Domain.Events;

namespace DeviceSimulation.Domain.Components;

public class PowerManager
{
    public event EventHandler<PowerStateChangedEventArgs>? PowerStateChanged;

    public bool HasElectricity { get; private set; }
    private readonly Battery? _battery;

    public PowerManager(bool hasElectricity, Battery? battery)
    {
        HasElectricity = hasElectricity;
        _battery = battery;
    }

    public void SetElectricity(bool state)
    {
        HasElectricity = state;
        PowerStateChanged?.Invoke(this,
            new PowerStateChangedEventArgs(state));
    }

    public bool CanOperate(bool intensive)
    {
        if (HasElectricity)
            return true;

        if (_battery == null)
            return false;

        return _battery.Consume(intensive);
    }
}
