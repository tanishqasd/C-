using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public bool IsAvailable { get; set; } = true;
}

class Program
{
    static List<Book> library = new List<Book> 
    { 
        new Book { Title = "The Lean Startup" }, 
        new Book { Title = "Clean Code" } 
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Library System ---");
            Console.WriteLine("1. View Books | 2. Borrow Book | 3. Return Book | 4. Exit");
            
            string choice = Console.ReadLine();
            if (choice == "1") ViewBooks();
            else if (choice == "2") BorrowBook();
            else if (choice == "3") ReturnBook();
            else if (choice == "4") break;
        }
    }

    static void ViewBooks()
    {
        foreach (var b in library)
            Console.WriteLine($"- {b.Title} ({(b.IsAvailable ? "Available" : "Checked Out")})");
    }

    static void BorrowBook()
    {
        Console.Write("Enter book title to borrow: ");
        string title = Console.ReadLine();
        var book = library.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        
        if (book != null && book.IsAvailable) { book.IsAvailable = false; Console.WriteLine("Book borrowed."); }
        else Console.WriteLine("Book not found or already borrowed.");
    }

    static void ReturnBook()
    {
        Console.Write("Enter book title to return: ");
        string title = Console.ReadLine();
        var book = library.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        
        if (book != null && !book.IsAvailable) { book.IsAvailable = true; Console.WriteLine("Book returned."); }
        else Console.WriteLine("Invalid return.");
    }
}