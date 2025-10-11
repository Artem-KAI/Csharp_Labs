using System;


namespace RectangleAplication.Models
{
    public class Rectangle : IComparable<Rectangle> // щоб об’єкти можна було порівнювати між собою
    {
        public string FillColor { get; set; }
        public string BorderColor { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string fillColor, string borderColor, double width, double height)
        {
            FillColor = fillColor;
            BorderColor = borderColor;
            Width = width;
            Height = height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public double GetArea()
        {
            return Width * Height;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Rectangle: Fill Color = {FillColor}, Border Color = {BorderColor}, " +
                              $"Width = {Width}, Height = {Height}, Perimeter = {GetPerimeter()}, Area = {GetArea()}");
        }


        public override string ToString()
        {
            return $"Rectangle: Fill Color = {FillColor}, Border Color = {BorderColor}, " +
                   $"Width = {Width}, Height = {Height}, Perimeter = {GetPerimeter()}, Area = {GetArea()}";
        }

        //порівняння за площею -1 менша 1 більша 0 однакова
        public int CompareTo(Rectangle other)
        {
            if (other == null)
                return 1;

            return this.GetArea().CompareTo(other.GetArea());
        }
    }

}