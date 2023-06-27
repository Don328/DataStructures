using Lnk_Lst;
using DStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DStructs;
internal static class LinkedListTests
{
    private const int listSize = 25;

    internal static void Test()
    {
        Console.WriteLine("");
        Console.WriteLine("**************** Linked List Test ****************");
        Console.WriteLine("");
        Item[] items = new Item[listSize];
        var random = new Random();

        for (int i = 0; i < listSize; i++)
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
        Console.WriteLine("[ first ]");
        Console.WriteLine(linkedList.First().Value);
        Console.WriteLine("");
        Console.WriteLine("[ last ]");
        Console.WriteLine(linkedList.Last().Value);
        Console.WriteLine("");
        Console.WriteLine("[ continue(3) ]");
        for (int i = 0; i < 3; i++) Console.WriteLine(linkedList.GetNext().Value);
        Console.WriteLine("");
        Console.WriteLine("[ first ]");
        Console.WriteLine(linkedList.First().Value);
        Console.WriteLine("");
        Console.WriteLine("[ last ]");
        Console.WriteLine(linkedList.Last().Value);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[ reverse(3) ]");
        for (int i = 0; i < 3; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine("");
        Console.WriteLine("----------------");
        Console.WriteLine("");
        Console.WriteLine("[ Restart(3) ]");
        Console.WriteLine(linkedList.Start().Value);
        for (int i = 0; i < 2; i++) Console.WriteLine(linkedList.GetNext().Value);
        Console.WriteLine();
        Console.WriteLine("[ Restart_Reverse(3) ]");
        Console.WriteLine(linkedList.Start_Reverse().Value);
        for (int i = 0; i < 2; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine();
        Console.WriteLine("----------------");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("[ Over the back ]");
        Console.WriteLine(linkedList.Start_Reverse().Value);
        for (int i = 0; i < 5; i++) Console.WriteLine(linkedList.GetNext().Value);
        Console.WriteLine("");
        Console.WriteLine("[ Over the back reverse]");
        Console.WriteLine(linkedList.Start().Value);
        for (int i = 0; i < 5; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine();
    }
}
