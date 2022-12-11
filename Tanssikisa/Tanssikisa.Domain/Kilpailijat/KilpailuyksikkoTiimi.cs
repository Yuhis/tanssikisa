namespace Tanssikisa.Domain.Kilpailijat
{
    public class KilpailuyksikkoTiimi : Kilpailuyksikko
    {
        public List<Henkilo> Tanssijat { get; set; } = new List<Henkilo>();
    }
}
