using ConsoleApp1.Data;
using ConsoleApp1.Logic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pfad = "../../../../../zauberschule0.txt";

            Schule schule = new(pfad);

            Person person = new(schule.Grundriss, schule.SchuleService.ArrLänge, schule.SchuleService.ArrBreite);

            Ziel ziel = new(schule.Grundriss, schule.SchuleService.ArrLänge, schule.SchuleService.ArrBreite);

            FloodFill floodfill = new(schule, person, ziel);

            schule = floodfill.AuffüllenDerStockwerke();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < schule.SchuleService.ArrLänge; j++)
                {
                    for (int k = 0; k < schule.SchuleService.ArrBreite; k++)
                    {
                        Console.Write(schule.Grundriss[k, j, i] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            LaufAlgorithmus laufAlgorithmus = new();
        }
    }
}