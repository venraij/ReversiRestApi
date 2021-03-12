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
            if (rijZet > 7 || kolomZet > 7)
            {
                return false;
            }

            if (Bord[rijZet,kolomZet] != Kleur.Geen)
            {
                return false;
            }

            for (int i = rijZet; i < 8; i++)
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

            for (int i = kolomZet; i < 8; i++)
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

            int x = kolomZet + 1;
            bool tegenGekomen = false;
            for (int y = rijZet -1; y > 0; y--)
            {
                if (Bord[y, x] == AandeBeurt && tegenGekomen == true)
                {
                    return true;
                } else if (Bord[y, x] != AandeBeurt && Bord[y, x] != Kleur.Geen)
                {
                    tegenGekomen = true;
                }
                x++;
            }

            x = kolomZet + 1;
            tegenGekomen = false;
            for (int y = rijZet + 1; y < 8; y++)
            {
                if (Bord[y, x] == AandeBeurt && tegenGekomen == true)
                {
                    return true;
                }
                else if (Bord[y, x] != AandeBeurt && Bord[y, x] != Kleur.Geen)
                {
                    tegenGekomen = true;
                }
                x++;
            }

            //x = kolomZet - 1;
            //tegenGekomen = false;
            //for (int y = rijZet - 1; y > 0; y--)
            //{
            //    if (Bord[y, x] == AandeBeurt && tegenGekomen == true)
            //    {
            //        return true;
            //    }
            //    else if (Bord[y, x] != AandeBeurt && Bord[y, x] != Kleur.Geen)
            //    {
            //        tegenGekomen = true;
            //    }
            //    x--;
            //}

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
