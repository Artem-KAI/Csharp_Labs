using System;

using System.Collections;
using System.Collections.Generic;


namespace RectangleAplication.Tree
{
    // Можемо створювати дерево для будь якого типу , та можна було порівнювати за допомогоою інтерфейсу
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> // універсальний клас дерева 
    {
        public TreeNode<T> Main { get; private set; }

        public void Insert(T data) // додає новий елемент у дерево починаючи з мейн
        {
            Main = InsertRec(Main, data); // рекурсивним способом 
        }

        private TreeNode<T> InsertRec(TreeNode<T> node, T data)
        {
            if (node == null)
                return new TreeNode<T>(data); // якшо нема то створюємо новий 

            if (data.CompareTo(node.Data) < 0) // якшо менше то вставляємо вліво 
                node.Left = InsertRec(node.Left, data);
            else
                node.Right = InsertRec(node.Right, data); // якшо більше то вправо

            return node;
        }

        public void PostOrderTraversal()
        {
            Console.WriteLine("Bypassing the tree (post-order):");
            PostOrderRec(Main);
            Console.WriteLine();
        }

        private void PostOrderRec(TreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderRec(node.Left);
                PostOrderRec(node.Right);
                Console.WriteLine(node.Data);
            }
        }

        public IEnumerator<T> GetEnumerator() // отримує ітерований списко значень для форіч
        {
            return PostOrder(Main).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() // потрібно щоб binary tree можна було перебирати як колецію 
        {
            return GetEnumerator();
        }

        private IEnumerable<T> PostOrder(TreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var val in PostOrder(node.Left))
                    yield return val;

                foreach (var val in PostOrder(node.Right))
                    yield return val;

                yield return node.Data;
            }
        }
    }
}
