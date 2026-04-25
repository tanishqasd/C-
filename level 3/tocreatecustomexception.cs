using System;

namespace MyApp.Exceptions
{
    // 1. Inherit from Exception
    public class MyCustomException : Exception
    {
        // 2. Default constructor
        public MyCustomException() { }

        // 3. Constructor with a custom message
        public MyCustomException(string message) 
            : base(message) { }

        // 4. Constructor for inner exceptions (wraps another error)
        public MyCustomException(string message, Exception inner) 
            : base(message, inner) { }
    }
}
