using ConsoleApp1.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pfad = "../../../zauberschule0.txt";

            Schule schule = new(pfad);
        }
    }
}