using DeviceSimulation.Domain.Components;
using DeviceSimulation.Domain.Devices;
using DeviceSimulation.Domain.Operations;
using DeviceSimulation.Domain.Services;

class Program
{
    static void Main()
    {
        var battery = new Battery(2500);
        var power = new PowerManager(false, battery);
        var software = new SoftwareManager();
        var network = new NetworkManager();
        var peripherals = new PeripheralManager();

        // no kiss solution

        //battery.BatteryLevelChanged += (_, e) =>
        //    Console.WriteLine($"Battery hours left: {e.RemainingHours}");

        //power.PowerStateChanged += (_, e) =>
        //    Console.WriteLine(e.HasElectricity
        //        ? "Switched to AC power"
        //        : "Switched to Battery mode");

        // new method 
        battery.BatteryLevelChanged += OnBatteryLevelChanged;
        power.PowerStateChanged += OnPowerStateChanged;

        software.Install(DeviceActionType.Work);
        software.Install(DeviceActionType.Chat);
        software.Install(DeviceActionType.ListenMusic);

        network.Connect();
        peripherals.ConnectAudio();

        IDevice laptop = new Laptop(
            "My Laptop",
            power,
            software,
            network,
            peripherals);

        Console.WriteLine(
            laptop.Execute(DeviceActionType.Chat)
                ? "Chat started"
                : "Chat failed");

        Console.WriteLine(
            laptop.Execute(DeviceActionType.PlayGames)
                ? "Game started"
                : "Game failed");
    }

    static void OnBatteryLevelChanged(object? sender,
    DeviceSimulation.Domain.Events.BatteryLevelChangedEventArgs e)
    {
        Console.WriteLine($"Battery hours left: {e.RemainingHours}");
    }

    static void OnPowerStateChanged(object? sender,
        DeviceSimulation.Domain.Events.PowerStateChangedEventArgs e)
    {
        if (e.HasElectricity)
            Console.WriteLine("Switched to AC power");
        else
            Console.WriteLine("Switched to Battery mode");
    }

}
