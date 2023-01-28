using Tanssikisa.Domain.Kilpailijat;

namespace Tanssikisa.Domain.Tapahtumat
{
    public class Tapahtuma
    {
        public string Nimi { get; set; }

        public string Jarjestaja { get; set; }

        public DateTimeOffset Paivamaara { get; set; }

        public Dictionary<string, Kilpailuyksikko> Kilpailijat { get; set; } = new();

    }
}
