namespace Tanssikisa.Domain.Kilpailijat
{
    public class KilpailuyksikkoSoolo : Kilpailuyksikko
    {
        public Henkilo Tanssija { get; set; } = new Henkilo();
    }
}
