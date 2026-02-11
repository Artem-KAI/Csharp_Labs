using DeviceSimulation.Domain.Events;

namespace DeviceSimulation.Domain.Components;

public class Battery
{
    public event EventHandler<BatteryLevelChangedEventArgs>? BatteryLevelChanged;

    public int CapacityMah { get; }
    public double RemainingHours { get; private set; }

    public Battery(int capacityMah)
    {
        CapacityMah = capacityMah;
        RemainingHours = CalculateMaxHours(false);
    }

    private double CalculateMaxHours(bool intensive)
    {
        if (CapacityMah >= 2000 && CapacityMah <= 3000)
            return intensive ? 16 : 48;

        if (CapacityMah >= 5000 && CapacityMah <= 7000)
            return intensive ? 4 : 12;

        return 0;
    }

    public bool Consume(bool intensive)
    {
        if (RemainingHours <= 0)
            return false;

        RemainingHours -= 1;

        BatteryLevelChanged?.Invoke(this,
            new BatteryLevelChangedEventArgs(RemainingHours));

        return RemainingHours > 0;
    }
}
