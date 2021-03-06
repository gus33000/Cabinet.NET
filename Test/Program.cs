using Cabinet;
using System;
using System.Collections.Generic;
using System.IO;

namespace CabStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting innovative code");

            string outputDir = @"D:\Decomp";

            List<string> failedFiles = new List<string>();

            //foreach (var input in Directory.EnumerateFiles(@"D:\Backup\win-x64\10.0.21382.1.co_release.210511-1416_arm64fre_e5c131864586\FeaturesOnDemand\neutral\cabs", "*.cab"))
            {
                string input = @"D:\Backup\win-x64\10.0.21382.1.co_release.210511-1416_arm64fre_e5c131864586\_desktopdeployment.cab";
                bool PASS = true;
                string name = Path.GetFileName(input);
                string output = Path.Combine(outputDir, name);

                try
                {
                    CabinetExtractor.ExtractCabinet(input, output);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    PASS = false;
                }

                if (!PASS)
                {
                    failedFiles.Add(name);
                }

                //break;
            }

            Console.WriteLine("\nFAILEDFILES\n");
            foreach (var failedFile in failedFiles)
            {
                Console.WriteLine(failedFile);
            }

            Console.WriteLine("Ending innovative code");
        }
    }
}
