
using ConsoleApp1.Data;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.Logic
{
    public class LaufAlgorithmus
    {
        private Schule _schulgebäude {  get; set; }
        private Person _person { get; set; }

        public LaufAlgorithmus(Schule schule, Person person)
        {
            _person = person;
            _schulgebäude = schule;
        }

        Koordinate _aktuellePosition { get; set; }

        public Schule SchnellstenWegFinden()
        {
            int vordereZahl;
            int hintereZahl;
            int rechteZahl;
            int linkeZahl;
            int andereEtageZahl;

            while(!AbfragenObAmZiel())
            {
                vordereZahl = SucheVordereZahl();
                hintereZahl = SucheHintereZahl();
            }

            return _schulgebäude;
        }

        private int SucheHintereZahl()
        {
            if (_person.PositionZ == 0)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX - 1, _person.PositionY, _person.PositionZ]);
                }
                catch { }
            }
            else if (_person.PositionZ == 1)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX - 1, _person.PositionY, _person.PositionZ]);
                }
                catch { }
            }
            return 2147483647;
        }

        private int SucheVordereZahl()
        {
            if (_person.PositionZ == 0)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX + 1, _person.PositionY, _person.PositionZ]);
                }
                catch { }
            }
            else if (_person.PositionZ == 1)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX + 1, _person.PositionY, _person.PositionZ]);
                }
                catch { }
            }
            return 2147483647;
        }

        public bool AbfragenObAmZiel()
        {
            if(_person.PositionZ == 0)
            {
                if (_schulgebäude.Grundriss[_person.PositionX + 1, _person.PositionY, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX - 1, _person.PositionY, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY + 1, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY - 1, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ + 1] == "B")
                { return true; }
            }
            else if(_person.PositionZ == 1)
            {
                if (_schulgebäude.Grundriss[_person.PositionX + 1, _person.PositionY, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX - 1, _person.PositionY, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY + 1, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY - 1, _person.PositionZ] == "B")
                { return true; }
                else if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ - 1] == "B")
                { return true; }
            }
            return false;
        }
    }
}
