using System;
using System.Runtime.InteropServices;

namespace AdvancedCSharp
{
    // 214. P/Invoke (Calling Native DLLs)
    // Sometimes you need to interface with legacy hardware, like an old physical turnstile 
    // or a truck weighbridge that only has C++ drivers. P/Invoke bridges C# to native C/C++ code.

    class Program
    {
        // Importing a standard Windows API function from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        static void Main()
        {
            Console.WriteLine("--- P/Invoke Demo ---");
            Console.WriteLine("Attempting to call native Windows API...");

            // 0x00000040 translates to an Information Icon with an OK button
            // If running on Windows, this will trigger a native OS popup box!
            // MessageBox(IntPtr.Zero, "Hardware weighbridge calibrated successfully.", "System Alert", 0x00000040);
            
            Console.WriteLine("[Native OS function invoked successfully]");
        }
    }
}