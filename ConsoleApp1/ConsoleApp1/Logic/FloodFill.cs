
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
            foreach(IKoordinate k in KoordinatenListe)
            {
                if (k.PositionZ == 0)
                {
                    if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ + 1] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ + 1] = _floodNummer.ToString();
                    }
                }
                else if (k.PositionZ == 1)
                {
                    if (_schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX + 1, k.PositionY, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX - 1, k.PositionY, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY + 1, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY - 1, k.PositionZ] = _floodNummer.ToString();
                    }
                    if (_schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ - 1] == ".")
                    {
                        _schule.Grundriss[k.PositionX, k.PositionY, k.PositionZ - 1] = _floodNummer.ToString();
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
