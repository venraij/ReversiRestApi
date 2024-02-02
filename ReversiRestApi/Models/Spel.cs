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
            bool bordVol = true;

            foreach (Kleur plek in Bord)
            {
                if (plek == Kleur.Geen)
                {
                    bordVol = false;
                    break;
                }
            }

            if (bordVol == false)
            {
                for (int y = 0; y < Bord.GetLength(0) - 1; y++)
                {
                    for (int x = 0; x < Bord.GetLength(1) - 1; x++)
                    {
                        if (ZetMogelijk(y, x))
                        {
                            return false;
                        }
                    }
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

            if (ZetMogelijk(rijZet, kolomZet))
            {
                Bord[rijZet, kolomZet] = AandeBeurt;

                for (int i = rijZet; i < Bord.GetLength(0); i++)
                {
                    if (Bord[i, kolomZet] == AandeBeurt)
                    {
                        for (int a = rijZet; a < i; a++)
                        {
                            if (Bord[a, kolomZet] != AandeBeurt && Bord[a, kolomZet] != Kleur.Geen)
                            {
                                Bord[a, kolomZet] = AandeBeurt;
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
                                Bord[a, kolomZet] = AandeBeurt;
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
                                Bord[rijZet, a] = AandeBeurt;
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
                                Bord[rijZet, a] = AandeBeurt;
                            }
                        }
                    }
                }

                for (int i = rijZet + 1; i < Bord.GetLength(0); i++)
                {
                    if (Bord[i, i] == AandeBeurt)
                    {
                        for (int a = rijZet + 1; a < i; a++)
                        {
                            if (Bord[a, a] != AandeBeurt && Bord[a, a] != Kleur.Geen)
                            {
                                Bord[a, a] = AandeBeurt;
                            }
                        }
                    }
                }

                for (int i = rijZet - 1; i > 0; i--)
                {
                    if (Bord[i, i] == AandeBeurt)
                    {
                        for (int a = rijZet - 1; a > i; a--)
                        {
                            if (Bord[a, a] != AandeBeurt && Bord[a, a] != Kleur.Geen)
                            {
                                Bord[a, a] = AandeBeurt;
                            }
                        }
                    }
                }

                for (int i = rijZet - 1; i > 0; i--)
                {
                    if (Bord[i, (Bord.GetLength(1) - 1) - i] == AandeBeurt)
                    {
                        for (int a = rijZet - 1; a > i; a--)
                        {
                            if (Bord[a, (Bord.GetLength(1) - 1) - a] != AandeBeurt && Bord[a, (Bord.GetLength(1) - 1) - a] != Kleur.Geen)
                            {
                                Bord[a, (Bord.GetLength(1) - 1) - a] = AandeBeurt;
                            }
                        }
                    }
                }

                for (int i = rijZet + 1; i < Bord.GetLength(0); i++)
                {
                    if (Bord[i, (Bord.GetLength(1) - 1) - i] == AandeBeurt)
                    {
                        for (int a = rijZet + 1; a < i; a++)
                        {
                            if (Bord[a, (Bord.GetLength(1) - 1) - a] != AandeBeurt && Bord[a, (Bord.GetLength(1) - 1) - a] != Kleur.Geen)
                            {
                                Bord[a, (Bord.GetLength(1) - 1) - a] = AandeBeurt;
                            }
                        }
                    }
                }
                
                Bord[rijZet, kolomZet] = AandeBeurt;
                AandeBeurt = AandeBeurt == Kleur.Zwart ? Kleur.Wit : Kleur.Zwart;
                return true;
            }

            return false;
        }

        public Kleur OverwegendeKleur()
        {
            int zwart = 0;
            int wit = 0;

            for (int y = 0; y < Bord.GetLength(0) - 1; y++)
            {
                for (int x = 0; x < Bord.GetLength(1) - 1; x++)
                {
                    if (Bord[y,x] == Kleur.Zwart)
                    {
                        zwart++;
                    } else if (Bord[y, x] == Kleur.Wit)
                    {
                        wit++;
                    }
                }
            }

            if (wit > zwart)
            {
                return Kleur.Wit;
            } else if (wit < zwart)
            {
                return Kleur.Zwart;
            } else
            {
                return Kleur.Geen;
            }
        }

        public bool Pas()
        {
            if (AandeBeurt == Kleur.Zwart)
            {
                AandeBeurt = Kleur.Wit;
                return true;
            } else
            {
                AandeBeurt = Kleur.Zwart;
                return true;
            }
        }

        public bool ZetMogelijk(int rijZet, int kolomZet)
        {
            if (rijZet >= Bord.GetLength(0) || kolomZet >= Bord.GetLength(1))
            {
                return false;
            }
            
            if (Bord[rijZet, kolomZet] != Kleur.Geen)
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

            bool mogelijk = false;
            for (int i = rijZet; i > 0; i--)
            {
                if (Bord[i - 1, (Bord.GetLength(1) - i)] == AandeBeurt)
                {
                    if (mogelijk)
                    {
                        return true;
                    }
                } else if (Bord[i - 1, (Bord.GetLength(1) - i)] != Kleur.Geen)
                {
                    mogelijk = true;
                }
            }

            mogelijk = false;
            for (int i = rijZet; i < 7; i++)
            {
                if (Bord[i + 1, (i + 1)] == AandeBeurt)
                {
                    if (mogelijk)
                    {
                        return true;
                    }
                }
                else if (Bord[i + 1, (i + 1)] != Kleur.Geen)
                {
                    mogelijk = true;
                }
            }

            mogelijk = false;
            for (int i = rijZet; i > 0; i--)
            {
                if (Bord[i - 1, (i - 1)] == AandeBeurt)
                {
                    if (mogelijk)
                    {
                        return true;
                    }
                }
                else if (Bord[i - 1, (i - 1)] != Kleur.Geen)
                {
                    mogelijk = true;
                }
            }

            mogelijk = false;
            for (int i = rijZet; i < 7; i++)
            {
                if (Bord[i + 1, ((Bord.GetLength(1) - 1) - (i + 1))] == AandeBeurt)
                {
                    if (mogelijk)
                    {
                        return true;
                    }
                }
                else if (Bord[i + 1, ((Bord.GetLength(1) - 1) - (i + 1))] != Kleur.Geen)
                {
                    mogelijk = true;
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
            AandeBeurt = Kleur.Zwart;
        }
    }
}
