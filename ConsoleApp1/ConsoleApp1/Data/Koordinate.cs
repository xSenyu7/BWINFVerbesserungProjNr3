
using ConsoleApp1.Services;

namespace ConsoleApp1.Data
{
    internal class Koordinate : IKoordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public Koordinate(int positionX, int positionY, int positionZ)
        {
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
        }
    }
}
