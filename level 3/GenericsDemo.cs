using System;

// Generic Class
class Box<T>
{
    private T _content;

    public void Pack(T item)
    {
        _content = item;
    }

    public T Unpack()
    {
        return _content;
    }
}

class Program
{
    static void Main()
    {
        Box<string> stringBox = new Box<string>();
        stringBox.Pack("Books");
        Console.WriteLine(stringBox.Unpack());

        Box<int> intBox = new Box<int>();
        intBox.Pack(100);
        Console.WriteLine(intBox.Unpack());
    }
}