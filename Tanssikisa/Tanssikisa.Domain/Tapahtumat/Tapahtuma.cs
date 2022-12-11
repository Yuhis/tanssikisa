using Tanssikisa.Domain.Kilpailijat;

namespace Tanssikisa.Domain.Tapahtumat
{
    public class Tapahtuma
    {
        public Dictionary<string, Kilpailuyksikko> Kilpailijat { get; set; } = new Dictionary<string, Kilpailuyksikko>();

    }
}
