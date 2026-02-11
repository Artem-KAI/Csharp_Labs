namespace DeviceSimulation.Domain.Services;

public class PeripheralManager
{
    public bool HasAudioOutput { get; private set; }
    public bool HasPrinter { get; private set; }

    public void ConnectAudio() => HasAudioOutput = true;
    public void ConnectPrinter() => HasPrinter = true;
}
