using System;

namespace Level5_DDD
{
    // 267. Anti-Corruption Layer (ACL).
    // When your new system talks to a messy, old legacy system, the ACL translates 
    // the old data into your clean domain models so the "corruption" doesn't spread.

    public class LegacyVendorSystem // The "Messy" System
    {
        public string GetRawData() => "VND_99|STEEL|500|TONS";
    }

    public class VendorAdapter // The Anti-Corruption Layer
    {
        private readonly LegacyVendorSystem _legacy = new();

        public (string Name, int Qty) GetCleanMaterialData()
        {
            var raw = _legacy.GetRawData().Split('|');
            return (raw[1], int.Parse(raw[2])); // Translating messy strings to clean types
        }
    }

    class Program
    {
        static void Main()
        {
            var acl = new VendorAdapter();
            var data = acl.GetCleanMaterialData();
            Console.WriteLine($"ACL translated legacy data: {data.Name} - {data.Qty} units.");
        }
    }
}