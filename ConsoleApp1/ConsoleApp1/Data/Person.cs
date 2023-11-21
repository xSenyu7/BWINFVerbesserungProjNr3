using ConsoleApp1.Services;

namespace ConsoleApp1.Data
{
    internal class Person : IKoordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public Person(string[,,] grundriss, int arrLänge, int arrBreite)
        {
            KoordinatenService kService = new KoordinatenService();

            PositionX = kService.PositionXFinden(grundriss, arrLänge, arrBreite, "A");
            PositionY = kService.PositionYFinden(grundriss, arrLänge, arrBreite, "A");
            PositionZ = kService.PositionZFinden(grundriss, arrLänge, arrBreite, "A");
        }
    }
}
