using Lnk_Lst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DStructs.Tests;
internal static class LinkedListTests
{
    private const int listSize = 25;

    internal static void Test()
    {
        Item[] items;
        LnkList<Item> linkedList;
     
        ShowHeader();
        SetupValues(out items, out linkedList);
        ShowValues(items);

        Current(linkedList);
        
        Next(linkedList, 5);
        Current(linkedList);
        
        Previous(linkedList);
        Current(linkedList);
        
        First(linkedList);
        Current(linkedList);
        
        Last(linkedList);
        Current(linkedList);
        
        Next(linkedList, 3);
        Current(linkedList);
        
        First(linkedList);
        Current(linkedList);
        
        Last(linkedList);
        Current(linkedList);
        
        Reverse(linkedList, 3);
        Current(linkedList);
        
        Restart(linkedList, 1);
        Current(linkedList);
        
        ReverseFromEnd(linkedList, 1);
        Current(linkedList);
        
        OverTheBack(linkedList, 3);
        Current(linkedList);
        
        OverTheBackReverse(linkedList, 3);
        Current(linkedList);
    }

    private static void SetupValues(out Item[] items, out LnkList<Item> linkedList)
    {
        items = new Item[listSize];
        var random = new Random();

        for (int i = 0; i < listSize; i++)
        {
            items[i] = new Item(random.Next(100, 999));
        }

        linkedList = new LnkList<Item>(items);
    }

    private static void ShowHeader()
    {
        Console.WriteLine("");
        Console.WriteLine("**************** Linked List Test ****************");
        Console.WriteLine("");
    }

    private static void ShowValues(Item[] items)
    {
        Console.WriteLine("---- Values ----");

        foreach (var item in items)
        {
            Console.WriteLine(item.Value);
        }
        Console.WriteLine("");
        Console.WriteLine("----------------");
        Console.WriteLine("");
    }

    private static void Current(LnkList<Item> linkedList)
    {
        Console.WriteLine("[ current item ]");
        Console.WriteLine(linkedList.Get().Value);
        Console.WriteLine("");
    }

    private static void Next(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine($"[ next {quantity} ]");
        for (int i = 0; i < quantity; i++)
        {
            Console.WriteLine(linkedList.GetNext().Value);
        }

        Console.WriteLine("");
    }

    private static void Previous(LnkList<Item> linkedList)
    {
        Console.WriteLine("[ previous ] ");
        Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine("");
    }

    private static void First(LnkList<Item> linkedList)
    {
        Console.WriteLine("[ first ]");
        Console.WriteLine(linkedList.First().Value);
        Console.WriteLine("");
    }

    private static void Last(LnkList<Item> linkedList)
    {
        Console.WriteLine("[ last ]");
        Console.WriteLine(linkedList.Last().Value);
        Console.WriteLine("");
    }

    private static void Reverse(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine($"[ reverse({quantity}) ]");
        for (int i = 0; i < quantity; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine("");
    }

    private static void Restart(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine($"[ Restart({quantity}) ]");
        Console.WriteLine(linkedList.Start().Value);
        for (int i = 0; i < quantity-1; i++) Console.WriteLine(linkedList.GetNext().Value);
        Console.WriteLine();
    }

    private static void ReverseFromEnd(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine($"[ Restart_Reverse({quantity}) ]");
        Console.WriteLine(linkedList.Start_Reverse().Value);
        for (int i = 0; i < quantity-1; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine();
    }

    private static void OverTheBack(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine("[ Over the back ]");
        Console.WriteLine(linkedList.Start_Reverse().Value);
        for (int i = 0; i < quantity; i++) Console.WriteLine(linkedList.GetNext().Value);
        Console.WriteLine("");
    }

    private static void OverTheBackReverse(LnkList<Item> linkedList, int quantity)
    {
        Console.WriteLine("[ Over the back reverse]");
        Console.WriteLine(linkedList.Start().Value);
        for (int i = 0; i < quantity; i++) Console.WriteLine(linkedList.GetPrevious().Value);
        Console.WriteLine("");
    }
}
