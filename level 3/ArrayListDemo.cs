using System;
using System.Collections; // Required for non-generic ArrayList

class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();
        list.Add(1);
        list.Add("Hello"); // ArrayList allows mixed types (not type-safe)
        list.Add(true);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}