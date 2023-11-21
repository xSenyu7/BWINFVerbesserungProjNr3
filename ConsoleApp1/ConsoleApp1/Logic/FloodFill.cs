
using ConsoleApp1.Data;

namespace ConsoleApp1.Logic
{
    public class FloodFill
    {
        List<IKoordinate> KoordinatenListe = new List<IKoordinate>();
        private Schule _schule;
        private Person _person;
        private Ziel _ziel;

        int _floodNummer = 1;

        public FloodFill(Schule schule, Person person, Ziel ziel)
        {
            _schule = schule;
            _person = person;
            _ziel = ziel;
        }

        public Schule AuffüllenDerStockwerke()
        {
            KoordinatenListe.Add(_ziel);

            while (NotwendigkeitFürAufladungPrüfen())
            {
                if (!PrüfenObAmZiel())
                {
                    FelderAuffüllen();
                    _floodNummer++;
                }
                else
                {
                    Console.WriteLine("Der Weg wurde Gefunden.");
                    break;
                }
            }
            return _schule;
        }

        private void FelderAuffüllen()
        {
            int anzahlKoordinaten = KoordinatenListe.Count;

            for(int i = 0; i < anzahlKoordinaten; i++)
            {
                if (KoordinatenListe[i].PositionZ == 0)
                {
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ + 1] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ + 1] = (3 + _floodNummer).ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ + 1));
                    }
                }
                else if (KoordinatenListe[i].PositionZ == 1)
                {
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX + 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX - 1, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY + 1, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ] = _floodNummer.ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY - 1, KoordinatenListe[i].PositionZ));
                    }
                    if (_schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ - 1] == ".")
                    {
                        _schule.Grundriss[KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ - 1] = (3 + _floodNummer).ToString();
                        KoordinatenListe.Add(new Koordinate(KoordinatenListe[i].PositionX, KoordinatenListe[i].PositionY, KoordinatenListe[i].PositionZ - 1));
                    }
                }
            }
        }

        private bool PrüfenObAmZiel()
        {
            foreach (IKoordinate k in KoordinatenListe)
            {
                if (k.PositionZ == 0)
                {
                       if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ + 1] == "A")
                        return true;
                }
                else if (k.PositionZ == 1)
                {
                       if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == "A"
                   || _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ - 1] == "A")
                        return true;
                }
            }
            return false;
        }

        private bool NotwendigkeitFürAufladungPrüfen()
        {
            foreach(IKoordinate k in KoordinatenListe)
            {
                if (k.PositionZ == 0)
                {
                        if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == "."
                    || _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == "."
                    || _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == "."
                    || _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == "."
                    || _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ + 1] == ".")
                                return true;
                }
                else if (k.PositionZ == 1)
                {
                    if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == "."
               || _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == "."
               || _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == "."
               || _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == "."
               || _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ - 1] == ".")
                        return true;
                }
                
            }
            return false;
        }
    }
}
