

namespace ConsoleApp1.Services
{
    public class SchuleService
    {
        public int ArrLänge;
        public int ArrBreite;
        private int aktuelleReie = 0;

        public string[,,] GrundrissEinlesen(string pfad)
        {
            string[] linien = File.ReadAllLines(pfad);

            LängeUndBreiteermitteln(linien[0]);

            int etagen = 2;
            int reien = ArrLänge;
            int spalten = ArrBreite;

            string[,,] grundriss = new string[spalten, reien, etagen];

            for (int i = 0; i < etagen; i++)
            {
                for (int j = 0; j < reien; j++)
                {
                    string reie = linien[aktuelleReie];

                    if (reie.Length != 0)
                    {
                        for (int k = 0; k < spalten; k++)
                        {
                            grundriss[k, j, i] = Convert.ToString(reie[k]);
                        }
                    }
                    aktuelleReie++;
                    if (reie.Length == 0)
                        j--;
                }
            }

            return grundriss;
        }

        public void LängeUndBreiteermitteln(string linien)
        {
            string arrLänge = null;
            string arrBreite = null;

            for (int i = 0; i < linien.Length; i++)
            {
                if (char.IsNumber(linien[i]))
                {
                    arrLänge = arrLänge + linien[i];
                }
                else if (char.IsWhiteSpace(linien[i]))
                {
                    for (int j = i + 1; j < linien.Length; j++)
                    {
                        if (char.IsNumber(linien[j]))
                        {
                            arrBreite = arrBreite + linien[j];
                        }
                        else
                        {
                            break;
                        }
                        i++;
                    }
                }
            }

            ArrLänge = Convert.ToInt32(arrLänge);
            ArrBreite = Convert.ToInt32(arrBreite);

            aktuelleReie++;
        }

        public void WriteSchule(string[,,] schule)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < ArrLänge; j++)
                {
                    for (int k = 0; k < ArrBreite; k++)
                    {
                        if (bla(schule[k,j,i]))
                        schule[k, j, i] = ".";

                        Console.Write(schule[k,j,i] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private bool bla(string s)
        {
            try
            {
                Convert.ToInt32(s);
                return true;
            }
            catch { }
            return false;
        }
    }
}
