using ConsoleApp1.Services;

namespace ConsoleApp1.Data
{
    internal class Schule
    {
        public string[,,] Grundriss { get; set; }

        public Schule(string pfad)
        {
            SchuleService schuleService = new SchuleService();

            Grundriss = schuleService.GrundrissEinlesen(pfad);
        }
    }
}
