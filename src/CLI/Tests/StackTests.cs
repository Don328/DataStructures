using Stk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DStructs.Tests;
internal static class StackTests
{
    private static readonly Random rand = new Random();
    private const int stackSize = 10;

    internal static void Test()
    {
        TestCreateWithValue();
        TestCreateWithList();
        TestCreateEmpty();
        TestBackAndForth();
    }

    private static void TestCreateWithValue()
    {
        var item = new Item(rand.Next(0, 10));
        var stack = new Stk<Item>(item);
        Console.WriteLine("--- Test create with value ---");
        Console.WriteLine();
        Console.WriteLine(stack.Peek().Value);
        Console.WriteLine();
    }

    private static void TestCreateWithList()
    {
        List<Item> items = GetList();

        var stack = new Stk<Item>(items);
        Console.WriteLine("--- Test create with list ---");
        Console.WriteLine();
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine();
    }

    private static List<Item> GetList()
    {
        var items = new List<Item>();
        for (int i = 0; i < stackSize; i++)
        {
            items.Add(new Item(rand.Next(10, 99)));
        }

        return items;
    }

    private static void TestAdd()
    {
    }

    private static void TestCreateEmpty()
    {
        var stack = new Stk<Item>();
        stack.Push(new Item(4));

        Console.WriteLine("--- Test create empty ---");        
        Console.WriteLine();        
        Console.WriteLine(stack.Peek().Value);
        Console.WriteLine();        
    }

    private static void TestPopLastAndContinue()
    {
        var stack = new Stk<Item>(GetList());

        Console.WriteLine("--- Test pop last and continue ---");
        Console.WriteLine();
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine();
    }

    private static void TestBackAndForth()
    {
        int testValue = rand.Next(10, 99);
        var stack = new Stk<Item>(GetList());

        Console.WriteLine("--- Test back and forth ---");
        Console.WriteLine();
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine($"[Adding value {testValue}]");
        stack.Push(new Item(testValue));
        Console.WriteLine("[peek] " + stack.Peek().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine("[pop]  " + stack.Pop().Value);
        Console.WriteLine();
    }
}
