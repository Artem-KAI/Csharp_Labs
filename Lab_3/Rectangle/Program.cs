using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

using namespace_rectangle;


#pragma warning disable SYSLIB0011
namespace Program
{
    class Program
    {
        static void Main()
        {
            AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);


            Rectangle[] rectangles = new Rectangle[]
            {
                new Rectangle { FillColor="Red", BorderColor="Black", Width=5, Height=3 },
                new Rectangle { FillColor="Blue", BorderColor="Yellow", Width=4, Height=6 },
                new Rectangle { FillColor="Green", BorderColor="White", Width=7, Height=2 },
                new Rectangle { FillColor="Orange", BorderColor="Black", Width=3, Height=8 },
                new Rectangle { FillColor="Purple", BorderColor="Gray", Width=6, Height=6 }
            };

            // JSON 
            string json = JsonSerializer.Serialize(rectangles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("rectangles.json", json);
            Console.WriteLine("JSON serialization completed");

            // XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Rectangle[]));
            using (FileStream fs = new FileStream("rectangles.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, rectangles);
            }
            Console.WriteLine("XML serialization completed.");

            // Binary 
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("rectangles.dat", FileMode.Create))
            {
                bf.Serialize(fs, rectangles);
            }
            Console.WriteLine("Binary serialization completed.");
            IFormatter customFormatter = new BinaryFormatter();


            // JSON
            string jsonFromFile = File.ReadAllText("rectangles.json");
            Rectangle[] loadedJsonRectangles = JsonSerializer.Deserialize<Rectangle[]>(jsonFromFile);
            Console.WriteLine("\nRectangle with JSON:");
            foreach (var r in loadedJsonRectangles) r.PrintInfo();

            // XML
            using (FileStream fs = new FileStream("rectangles.xml", FileMode.Open))
            {
                Rectangle[] loadedXmlRectangles = (Rectangle[])xmlSerializer.Deserialize(fs);
                Console.WriteLine("\nRectandle with XML:");
                foreach (var r in loadedXmlRectangles) r.PrintInfo();
            }

            // Binary
            using (FileStream fs = new FileStream("rectangles.dat", FileMode.Open))
            {
                Rectangle[] loadedBinRectangles = (Rectangle[])bf.Deserialize(fs);
                Console.WriteLine("\nRectangle from binary file:");
                foreach (var r in loadedBinRectangles) r.PrintInfo();
            }
        }
    }
}
