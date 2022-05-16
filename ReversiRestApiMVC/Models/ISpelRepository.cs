using System.Collections.Generic;

namespace ReversiRestApiMVC
{
    public interface ISpelRepository
    {
        void AddSpel(Spel spel);
        public List<Spel> GetSpellen();
        Spel GetSpel(string spelToken);
        Spel GetSpelBySpeler(string spelerToken);
        void SaveSpel(Spel spel);
        void RemoveSpel(string spelToken);
    }

}
