using System;

namespace CabStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting innovative code");

            string output = @"D:\Decomp";
            string input = @"D:\Backup\win-x64\10.0.21382.1.co_release.210511-1416_arm64fre_e5c131864586\FeaturesOnDemand\neutral\cabs\Microsoft-OneCore-ApplicationModel-Sync-Desktop-FOD-Package~31bf3856ad364e35~arm64~~.cab";

            CabinetExtractor.ExtractCabinet(input, output);

            Console.WriteLine("Ending innovative code");
        }
    }
}
