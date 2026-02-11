namespace DeviceSimulation.Domain.Events;

public class PowerStateChangedEventArgs : EventArgs
{
    public bool HasElectricity { get; }

    public PowerStateChangedEventArgs(bool hasElectricity)
    {
        HasElectricity = hasElectricity;
    }
}
