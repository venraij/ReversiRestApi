using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReversiRestApiMVC.Hubs
{
    public class GameHub : Hub
    {
        private readonly ISpelRepository iRepository;
        public GameHub(ISpelRepository repository)
        {
            iRepository = repository;
        }
        
        public Task Zet(int x, int y, string token)
        {
            Spel spel = iRepository.GetSpelBySpeler(token);
            string spelString = JsonConvert.SerializeObject(spel, Formatting.Indented);

            if (spel.Speler1Token == token && spel.AandeBeurt != Kleur.Zwart)
            {
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", spelString);
            } 
            
            if (spel.Speler2Token == token && spel.AandeBeurt != Kleur.Wit)
            {
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", spelString);
            }
            
            if (spel.DoeZet(y, x))
            {
                iRepository.SaveSpel(spel);
                spelString = JsonConvert.SerializeObject(spel, Formatting.Indented);
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt,  "SUCCEEDED", spelString);
            }

            return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", spelString);
        }
    }
}
