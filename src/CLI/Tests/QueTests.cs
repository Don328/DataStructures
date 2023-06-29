using Que;

namespace DStructs.Tests;
internal static class QueTests
{
    private static Random _rand = new Random();

    internal static void Test()
    {
        TestInitEmpty();
        TestInitWithValue();
        TestInitWithList();
        TestPopToEnd();
    }

    private static void TestInitEmpty()
    {
        Console.WriteLine("--- Test init empty ---");

        var queue = new Que<Item>();
        var value = _rand.Next(1, 10);
        Console.WriteLine($"[push] {value}");
        queue.Push(new Item(value));

        Console.WriteLine($"[pop]  " + queue.Pop().Value);
        Console.WriteLine();
    }

    private static void TestInitWithValue()
    {
        Console.WriteLine("--- Test init with value ---");
        var value = _rand.Next(1, 10);
        Console.WriteLine($"[push] {value}");
        var queue = new Que<Item>(
            new Item(value));
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine();
    }

    private static void TestInitWithList()
    {
        Console.WriteLine("--- Test init with list ---");
        var list = new List<Item>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Item(
                _rand.Next(10, 99)));
        }

        var queue = new Que<Item>(list);
        Console.WriteLine("[peek] " + queue.Peek().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[peek] " + queue.Peek().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine();
    }

    private static void TestPopToEnd()
    {
        Console.WriteLine("--- Test pop to end ---");
        var list = new List<Item>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new Item(
                _rand.Next(10, 99)));
        }

        var queue = new Que<Item>(list);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine("[pop]  " + queue.Pop().Value);
        Console.WriteLine();
    }
}
