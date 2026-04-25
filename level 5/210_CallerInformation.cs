using System;
using System.Runtime.CompilerServices;

namespace AdvancedCSharp
{
    // 210. Caller Information Attributes
    // These attributes automatically inject the exact file, method, and line number 
    // that called a function. This is an absolute necessity for enterprise auditing and logging.

    public class SystemAuditor
    {
        // The compiler automatically fills in the parameters marked with [Caller...] attributes.
        public static void LogSecurityEvent(
            string message,
            [CallerMemberName] string callingMethod = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine($"[SECURITY AUDIT]");
            Console.WriteLine($"Message : {message}");
            Console.WriteLine($"Method  : {callingMethod}");
            Console.WriteLine($"File    : {sourceFilePath}");
            Console.WriteLine($"Line    : {sourceLineNumber}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Caller Information Attributes ---\n");
            AttemptUnauthorizedAccess();
        }

        static void AttemptUnauthorizedAccess()
        {
            // We only pass the message. The compiler magically passes the method name, file, and line!
            SystemAuditor.LogSecurityEvent("User attempted to view restricted payroll data.");
        }
    }
}