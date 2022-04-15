using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            String bord = JsonConvert.SerializeObject(spel.Bord);

            if (spel.Speler1Token == token && spel.AandeBeurt != Kleur.Zwart)
            {
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", bord);
            } 
            
            if (spel.Speler2Token == token && spel.AandeBeurt != Kleur.Wit)
            {
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", bord);
            }
            
            if (spel.DoeZet(y, x))
            {
                iRepository.SaveSpel(spel);
                bord = JsonConvert.SerializeObject(spel.Bord);
                return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt,  "SUCCEEDED", bord);
            }
            
            return Clients.All.SendAsync("ZetDone", (int) spel.AandeBeurt, "FAILED", bord);
        }
    }
}
