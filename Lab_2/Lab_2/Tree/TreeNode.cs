using System;


namespace RectangleAplication.Tree
{
    public class TreeNode<T> // generic клас
    {
        public T Data { get; set; } // данні вузла 
        public TreeNode<T> Left { get; set; } // посилання на вузли
        public TreeNode<T> Right { get; set; }

        public TreeNode(T data) // конструктор для створення нового вузла 
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
