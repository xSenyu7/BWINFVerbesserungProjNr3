
using ConsoleApp1.Data;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
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
                linkeZahl = SucheLinkeZahl();
                rechteZahl = SucheRechteZahl();
                andereEtageZahl = SucheAndereEtageZahl();

                if (_person.PositionZ == 0)
                {
                    if (EntscheidenObNachVorne(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachVorne();
                    }
                    else if (EntscheidenObNachHinten(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachHinten();
                    }
                    else if (EntscheidenObNachRechts(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachRechts();
                    }
                    else if (EntscheidenObNachLinks(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachLinks();
                    }
                    else if (EntscheidenObAndereEtage(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        EtageHoch();
                    }
                    //if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ + 1] == "B")
                    //{
                    //    _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ + 1] = "!";
                    //}
                }
                else if (_person.PositionZ == 1)
                {
                    if (EntscheidenObNachVorne(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachVorne();
                    }
                    else if (EntscheidenObNachHinten(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachHinten();
                    }
                    else if (EntscheidenObNachRechts(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachRechts();
                    }
                    else if (EntscheidenObNachLinks(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachLinks();
                    }
                    else if (EntscheidenObAndereEtage(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        EtageRunter();
                    }

                    //if (_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ - 1] == "B")
                    //{
                    //    _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ - 1] = "!";
                    //}
                }
            }
            return _schulgebäude;
        }

        private void EtageHoch()
        {
            _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "!";
            _person.PositionZ++;
            _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "!";
        }

        private void EtageRunter()
        {
            _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "!";
            _person.PositionZ--;
            _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "!";
        }

        private void NachHinten()
        {
            if (_person.PositionZ == 0)
            {
                _person.PositionY++;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "v";
            }
            else if (_person.PositionZ == 1)
            {
                _person.PositionY++;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "v";
            }
        }

        private void NachVorne()
        {
            if (_person.PositionZ == 0)
            {
                _person.PositionY--;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "^";
            }
            else if (_person.PositionZ == 1)
            {
                _person.PositionY--;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "^";
            }
        }

        private void NachLinks()
        {
            if (_person.PositionZ == 0)
            {
                _person.PositionX--;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "<";
            }
            else if (_person.PositionZ == 1)
            {
                _person.PositionX--;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = "<";
            }
        }

        private void NachRechts()
        {
            if (_person.PositionZ == 0)
            {
                _person.PositionX++;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = ">";
            }
            else if (_person.PositionZ == 1)
            {
                _person.PositionX++;
                _schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ] = ">";
            }
        }

        private bool EntscheidenObAndereEtage(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (andereEtageZahl <= vordereZahl
                && andereEtageZahl <= hintereZahl
                && andereEtageZahl <= linkeZahl
                && andereEtageZahl <= rechteZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachLinks(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (linkeZahl <= rechteZahl
                && linkeZahl <= hintereZahl
                && linkeZahl <= vordereZahl
                && linkeZahl <= andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachRechts(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (rechteZahl <= hintereZahl
                && rechteZahl <= linkeZahl
                && rechteZahl <= vordereZahl
                && rechteZahl <= andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachHinten(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (hintereZahl <= vordereZahl
                && hintereZahl <= rechteZahl
                && hintereZahl <= linkeZahl
                && hintereZahl <= andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachVorne(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (vordereZahl <= hintereZahl
                && vordereZahl <= rechteZahl
                && vordereZahl <= linkeZahl
                && vordereZahl <= andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private int SucheAndereEtageZahl()
        {
            if (_person.PositionZ == 0)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ + 1]);
                }
                catch { }
            }
            else if (_person.PositionZ == 1)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY, _person.PositionZ - 1]);
                }
                catch { }
            }
            return 2147483647;
        }

        private int SucheHintereZahl()
        {
            if (_person.PositionZ == 0)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY + 1, _person.PositionZ]);
                }
                catch { }
            }
            else if (_person.PositionZ == 1)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY + 1, _person.PositionZ]);
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
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY - 1, _person.PositionZ]);
                }
                catch { }
            }
            else if (_person.PositionZ == 1)
            {
                try
                {
                    return Convert.ToInt32(_schulgebäude.Grundriss[_person.PositionX, _person.PositionY  -1, _person.PositionZ]);
                }
                catch { }
            }
            return 2147483647;
        }

        private int SucheLinkeZahl()
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

        private int SucheRechteZahl()
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

        private bool AbfragenObAmZiel()
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
