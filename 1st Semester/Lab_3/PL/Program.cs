namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);

            Menu.MainMenu();
        }
    }
}
