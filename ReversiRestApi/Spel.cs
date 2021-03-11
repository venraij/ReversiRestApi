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
            if (rijZet > 7 || kolomZet > 7)
            {
                return false;
            }

            if (Bord[rijZet,kolomZet] != Kleur.Geen)
            {
                return false;
            }

            Queue<Array> mogelijkeDoelwitten = new Queue<Array>();

            if (Bord[rijZet + 1, kolomZet] != AandeBeurt && Bord[rijZet + 1, kolomZet] != Kleur.Geen) {
                mogelijkeDoelwitten.Enqueue(new int[] {rijZet + 1, kolomZet});
            }
            if (Bord[rijZet - 1, kolomZet] != AandeBeurt && Bord[rijZet - 1, kolomZet] != Kleur.Geen) {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet - 1, kolomZet });
            }
            if (Bord[rijZet, kolomZet + 1] != AandeBeurt && Bord[rijZet, kolomZet + 1] != Kleur.Geen) {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet, kolomZet + 1 });
            }
            if (Bord[rijZet, kolomZet - 1] != AandeBeurt && Bord[rijZet, kolomZet - 1] != Kleur.Geen) {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet, kolomZet - 1 });
            }
            if (Bord[rijZet - 1, kolomZet - 1] != AandeBeurt && Bord[rijZet - 1, kolomZet - 1] != Kleur.Geen)
            {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet - 1, kolomZet - 1 });
            }
            if (Bord[rijZet + 1, kolomZet + 1] != AandeBeurt && Bord[rijZet + 1, kolomZet + 1] != Kleur.Geen)
            {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet + 1, kolomZet + 1 });
            }
            if (Bord[rijZet - 1, kolomZet + 1] != AandeBeurt && Bord[rijZet - 1, kolomZet + 1] != Kleur.Geen)
            {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet - 1, kolomZet + 1 });
            }
            if (Bord[rijZet + 1, kolomZet - 1] != AandeBeurt && Bord[rijZet + 1, kolomZet - 1] != Kleur.Geen)
            {
                mogelijkeDoelwitten.Enqueue(new int[] { rijZet + 1, kolomZet - 1 });
            }


            return false;
        }

        public Spel()
        {
            Bord = new Kleur[8,8];
        }
    }
}
