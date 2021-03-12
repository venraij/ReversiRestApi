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
            for (int y = 0; y < Bord.GetLength(0); y++)
            {
                for (int x = 0; x < Bord.GetLength(1); x++)
                {
                    if (ZetMogelijk(y,x) == true)
                    {
                        return false;
                    }
                    if (ZetMogelijk(y, x) == true)
                    {
                        return false;
                    }
                }
            }

            foreach (Kleur plek in Bord)
            {
                if (plek == Kleur.Geen)
                {
                    return false;
                }
            }

            return true;
        }

        public bool DoeZet(int rijZet, int kolomZet)
        {
            if (rijZet >= Bord.GetLength(0) || kolomZet >= Bord.GetLength(1))
            {
                return false;
            }

            if (Bord[rijZet, kolomZet] != Kleur.Geen)
            {
                return false;
            }

            return true;
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
            if (rijZet >= Bord.GetLength(0) || kolomZet >= Bord.GetLength(1))
            {
                return false;
            }

            if (Bord[rijZet,kolomZet] != Kleur.Geen)
            {
                return false;
            }

            for (int i = rijZet; i < Bord.GetLength(0); i++)
            {
                if (Bord[i, kolomZet] == AandeBeurt)
                {
                    for (int a = rijZet; a < i; a++)
                    {
                        if (Bord[a, kolomZet] != AandeBeurt && Bord[a, kolomZet] != Kleur.Geen)
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = rijZet; i >= 0; i--)
            {
                if (Bord[i, kolomZet] == AandeBeurt)
                {
                    for (int a = rijZet; a > i; a--)
                    {
                        if (Bord[a, kolomZet] != AandeBeurt && Bord[a, kolomZet] != Kleur.Geen)
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = kolomZet; i < Bord.GetLength(0); i++)
            {
                if (Bord[rijZet, i] == AandeBeurt)
                {
                    for (int a = kolomZet; a < i; a++)
                    {
                        if (Bord[rijZet, a] != AandeBeurt && Bord[rijZet, a] != Kleur.Geen)
                        {
                            return true;
                        }
                    }
                }
            }

            for (int i = kolomZet; i >= 0; i--)
            {
                if (Bord[rijZet, i] == AandeBeurt)
                {
                    for (int a = kolomZet; a > i; a--)
                    {
                        if (Bord[rijZet, a] != AandeBeurt && Bord[rijZet, a] != Kleur.Geen)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Spel()
        {
            Bord = new Kleur[8,8];

            Bord[3, 3] = Kleur.Wit;
            Bord[4, 4] = Kleur.Wit;
            Bord[4, 3] = Kleur.Zwart;
            Bord[3, 4] = Kleur.Zwart;
        }
    }
}
