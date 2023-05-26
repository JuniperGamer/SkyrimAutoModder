using System;
using System.IO;
using System.Net;

namespace SkyrimCheck
{
    class Program
    {
        private static readonly string SkyrimPath = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim Special Edition\SkyrimSE.exe";
        private static readonly string LootUrl = "https://github.com/loot/loot/releases/download/0.19.1/loot_0.19.1-win64.exe";
        private static readonly string SkseUrl = "https://skse.silverlock.org/beta/skse64_2_02_03.7z";

        static void Main(string[] args)
        {
            if (File.Exists(SkyrimPath))
            {
                Console.WriteLine("Skyrim is installed.");
                if (!IsAnniversaryEdition())
                {
                    Console.WriteLine("Skyrim is not the Anniversary Edition, downloading required files...");
                    try
                    {
                        DownloadFile(LootUrl, "loot.exe");
                        DownloadFile(SkseUrl, "skse.7z");
                        Console.WriteLine("Files downloaded successfully.");
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine($"Error Code 1: Failed to download files - {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Code 2: Unexpected error - {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Skyrim is the Anniversary Edition, no action required.");
                }
            }
            else
            {
                Console.WriteLine("Skyrim is not installed, this may occur if skyrim is not in the normal install location.");
            }
        }

        static bool IsAnniversaryEdition()
        {
            // TODO: Implement actual logic to check if Skyrim is the Anniversary Edition.
            return false;
        }

        static void DownloadFile(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }
    }
}
