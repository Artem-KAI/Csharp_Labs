using System.Collections;
using RectangleAplication.Models;
using RectangleAplication.Tree;

using System;


namespace RectangleAplication
{
    class Program
    {
        static void Main()
        {
            //Масив
            Rectangle[] array = new Rectangle[]
            {
                new Rectangle("Red", "Black", 3, 4),
                new Rectangle("Blue", "Gray", 5, 6)
            };

            //Список (Generic)
            List<Rectangle> list = new List<Rectangle>
            {
                new Rectangle("Yellow", "Black", 2, 3),
                new Rectangle("Green", "Red", 4, 5)
            };

            //ArrayList (Non-generic)
            ArrayList arrayList = new ArrayList
            {
                new Rectangle("Pink", "Black", 7, 8)
            };

            //Додавання
            list.Add(new Rectangle("Orange", "Gray", 10, 5));

            // Видалення
            list.RemoveAt(1); // Видаляє "Green"

            // Оновлення
            list[0] = new Rectangle("Purple", "White", 3, 7);

            // Пошук
            var found = list.Find(r => r.FillColor == "Orange");

            // Виведення масиву
            Console.WriteLine("Array:");
            foreach (var r in array) r.PrintInfo();

            Console.WriteLine("\nList:");
            foreach (var r in list) r.PrintInfo();

            Console.WriteLine("\nArrayList:");
            foreach (Rectangle r in arrayList) r.PrintInfo();

            Console.WriteLine($"\nFinded: {(found != null ? found.FillColor : "немає")}\n");

            // Створення бінарного дерева
            var binar_tree = new BinaryTree<Rectangle>();
            binar_tree.Insert(new Rectangle("Cyan", "Blue", 5, 5));     // 25
            binar_tree.Insert(new Rectangle("Lime", "Green", 2, 8));    // 16
            binar_tree.Insert(new Rectangle("Pink", "Red", 3, 9));      // 27
            binar_tree.Insert(new Rectangle("Gray", "Black", 1, 6));    // 6
            binar_tree.Insert(new Rectangle("White", "Silver", 4, 4));  // 16

            // Обхід дерева в зворотному порядку
            binar_tree.PostOrderTraversal();

            // Взаємодія через foreach (ітератор)
            Console.WriteLine("\n Tree bypass through foreach (PostOrder):");
            foreach (var rect in binar_tree)
            {
                //Console.WriteLine(rect);
                rect.PrintInfo();  
            }
        }
    }
}
