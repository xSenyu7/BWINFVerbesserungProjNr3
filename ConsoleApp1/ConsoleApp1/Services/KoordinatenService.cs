
namespace ConsoleApp1.Services
{
    public class KoordinatenService
    {
        //TODO: Dafür sorgen, dass die richtige koordinate auch aus der zweiten etage ausgelesen wird.

        public int PositionXFinden(string[,,] grundriss, int arrLänge, int arrBreite, string gesuchterString)
        {
            for (int i = 0; i < 2 - 1; i++)
            {
                for (int j = 0; j < arrLänge; j++)
                {
                    for (int k = 0; k < arrBreite; k++)
                    {
                        if (grundriss[k,j,i] == gesuchterString)
                        {
                            Console.WriteLine("PositionX von " + gesuchterString + " ist: " + k);
                            return k;
                        }
                    }
                }
            }
            return 0;
        }

        public int PositionYFinden(string[,,] grundriss, int arrLänge, int arrBreite, string gesuchterString)
        {
            for (int i = 0; i < 2 - 1; i++)
            {
                for (int j = 0; j < arrLänge; j++)
                {
                    for (int k = 0; k < arrBreite; k++)
                    {
                        if (grundriss[k, j, i] == gesuchterString)
                        {
                            Console.WriteLine("PositionY von " + gesuchterString + " ist: " + j);
                            return j;
                        }
                    }
                }
            }
            return 0;
        }

        public int PositionZFinden(string[,,] grundriss, int arrLänge, int arrBreite, string gesuchterString)
        {
            for (int i = 0; i < 2 - 1; i++)
            {
                for (int j = 0; j < arrLänge; j++)
                {
                    for (int k = 0; k < arrBreite; k++)
                    {
                        if (grundriss[k, j, i] == gesuchterString)
                        {
                            Console.WriteLine("PositionZ von " + gesuchterString + " ist: " + i);
                            return i;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
