using ConsoleApp1.Services;

namespace ConsoleApp1.Data
{
    public class Ziel : IKoordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public Ziel(string[,,] grundriss, int arrLänge, int arrBreite)
        {
            KoordinatenService kService = new KoordinatenService();

            PositionX = kService.PositionXFinden(grundriss, arrLänge, arrBreite, "B");
            PositionY = kService.PositionYFinden(grundriss, arrLänge, arrBreite, "B");
            PositionZ = kService.PositionZFinden(grundriss, arrLänge, arrBreite, "B");
        }
    }
}
