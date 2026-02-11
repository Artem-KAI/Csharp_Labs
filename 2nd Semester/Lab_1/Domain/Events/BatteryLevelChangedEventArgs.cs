namespace DeviceSimulation.Domain.Events;

public class BatteryLevelChangedEventArgs : EventArgs
{
    public double RemainingHours { get; }

    public BatteryLevelChangedEventArgs(double remainingHours)
    {
        RemainingHours = remainingHours;
    }
}
