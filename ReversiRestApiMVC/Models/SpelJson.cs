namespace ReversiRestApiMVC.Models
{
    public class SpelJson
    {
        private string bord;

        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }
        public string Bord { get; set; }
        public string AandeBeurt { get; set; }
    }
}
