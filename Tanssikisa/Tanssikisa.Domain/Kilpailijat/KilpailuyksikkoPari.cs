namespace Tanssikisa.Domain.Kilpailijat
{
    public class KilpailuyksikkoPari : Kilpailuyksikko
    {
        public Henkilo Vieja { get; set; } = new Henkilo();
        public Henkilo Seuraaja { get; set; } = new Henkilo();
    }
}
