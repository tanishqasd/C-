using System;

namespace MultipleInheritanceDemo
{
    // 1. FIRST INTERFACE
    interface IPhone
    {
        void MakeCall(string phoneNumber);
        void EndCall();
    }

    // 2. SECOND INTERFACE
    interface ICamera
    {
        void TakePicture();
        void RecordVideo();
    }

    // 3. THE CLASS IMPLEMENTING MULTIPLE INTERFACES
    // A comma separates the multiple interfaces this class agrees to implement.
    class SmartPhone : IPhone, ICamera
    {
        private string _model;

        public SmartPhone(string model)
        {
            _model = model;
        }

        // Implementing IPhone methods
        public void MakeCall(string phoneNumber)
        {
            Console.WriteLine($"[{_model}] Dialing {phoneNumber}...");
        }

        public void EndCall()
        {
            Console.WriteLine($"[{_model}] Call disconnected.");
        }

        // Implementing ICamera methods
        public void TakePicture()
        {
            Console.WriteLine($"[{_model}] Flash fired! Picture captured and saved to gallery.");
        }

        public void RecordVideo()
        {
            Console.WriteLine($"[{_model}] Recording video... 00:00:01");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Multiple Inheritance Demo ---\n");

            // Instantiate the SmartPhone class
            SmartPhone myDevice = new SmartPhone("TechPro X1");

            // The single object can seamlessly use methods from both interfaces
            Console.WriteLine("Testing Phone Capabilities:");
            myDevice.MakeCall("555-0199");
            myDevice.EndCall();

            Console.WriteLine("\nTesting Camera Capabilities:");
            myDevice.TakePicture();
            myDevice.RecordVideo();

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}