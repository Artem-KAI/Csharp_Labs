using System;

using RectangleAplication.Models;


namespace RectangleAplication.Tree
{
    public class RectangleAreaComparer : IComparer<Rectangle>
    {
        public int Compare(Rectangle x, Rectangle y)
        {
            if (x == null || y == null)
                return 0;

            return x.GetArea().CompareTo(y.GetArea());
        }
    }
}
