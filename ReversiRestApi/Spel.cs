using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi
{
    public class Spel : ISpel
    {
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }
        public Kleur[,] Bord { get; set; }
        public Kleur AandeBeurt { get; set; }

        public bool Afgelopen()
        {
            throw new NotImplementedException();
        }

        public bool DoeZet(int rijZet, int kolomZet)
        {
            throw new NotImplementedException();
        }

        public Kleur OverwegendeKleur()
        {
            throw new NotImplementedException();
        }

        public bool Pas()
        {
            throw new NotImplementedException();
        }

        public bool ZetMogelijk(int rijZet, int kolomZet)
        {
            throw new NotImplementedException();
        }
    }
}
