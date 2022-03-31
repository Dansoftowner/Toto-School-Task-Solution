using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Toto
{
    class Program
    {

        private const string FilePath = "toto.txt";

        static void Main(string[] args)
        {

            List<Tip> tips = File.ReadLines(FilePath)
                .Skip(1)
                .Select(it => new Tip(it))
                .ToList();

            PrintTask(3, $"Fordulók száma: {tips.Count} db.");
            PrintTask(4, $"Telitalálatos szelvények száma: {tips.Sum(it => it.T13p1)} db.");

            double average = tips.Where(it => it.FullPrediction)
                .Average(it => it.Profit);
            PrintTask(5, $"Átlag: {Math.Round(average)} Ft.");

            Tip least = tips.Where(it => it.FullPrediction)
                .Aggregate((o1, o2) => o1.Ny13p1 < o2.Ny13p1 ? o1 : o2);
            Tip best = tips.Where(it => it.FullPrediction)
                .Aggregate((o1, o2) => o1.Ny13p1 > o2.Ny13p1 ? o1 : o2);

            string task6Output = $"\n\tLegnagyobb:{best}\n\n\tLegkisebb:{least}";
            PrintTask(6, task6Output);

            bool werentHeadToHead = tips.Count(it => new EredmenyElemzo(it.Results).NemvoltDontetlenMerkozes) == 0;
            string task8Output = werentHeadToHead ? 
                "Nem volt döntetlen nélküli forduló!" 
                : "Volt döntetlen nélküli forduló!";
            PrintTask(8, task8Output);


            Console.ReadKey();
        }

        private static void PrintTask(int n, string title)
        {
            Console.WriteLine($"{n}. Feladat: {title}");
        }
    }
}
