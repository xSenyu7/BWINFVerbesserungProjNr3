using ConsoleApp1.Services;

namespace ConsoleApp1.Data
{
    public class Schule
    {
        public string[,,] Grundriss { get; set; }

        public SchuleService SchuleService;

        public Schule(string pfad)
        {
            SchuleService = new SchuleService();

            Grundriss = SchuleService.GrundrissEinlesen(pfad);
        }
    }
}
