using LinkedList;
using DStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DStructs;
internal static class LinkedListTests
{
    internal static void Test()
    {

        Item[] items = new Item[100];
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            items[i] = new Item(random.Next(100, 999));
        }

        var linkedList = new LnkList<Item>(items);

        Console.WriteLine("");
        Console.WriteLine("---- Values ----");

        foreach (var item in items)
        {
            Console.WriteLine(item.Value);
        }
        Console.WriteLine("");
        Console.WriteLine("----------------");
        Console.WriteLine("");

        Console.WriteLine("[ index 0 ]");
        Console.WriteLine(linkedList.Get().Value);
        Console.WriteLine("");

        Console.WriteLine("[ next 5 ]");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(linkedList.GetNext().Value);
        }
        Console.WriteLine("");

        Console.WriteLine("[ previous ] ");
        Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine("");
    }
}
