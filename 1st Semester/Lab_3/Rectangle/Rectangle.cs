using System;


namespace namespace_rectangle
{
    [Serializable]
    public class Rectangle
    {
        public string FillColor { get; set; }
        public string BorderColor { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Rectangle: Fill color={FillColor}, Border color={BorderColor}, " +
                $"Widht={Width}, Height={Height}, Area={GetArea()}, Periment={GetPerimeter()}");
        }
    }
}
