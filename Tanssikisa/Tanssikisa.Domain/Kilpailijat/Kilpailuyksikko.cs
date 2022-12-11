namespace Tanssikisa.Domain.Kilpailijat
{
    public class Kilpailuyksikko
    {
        public string Id { get; set; } = "";
        Edustusseura Seura { get; set; } = new Edustusseura();
    }
}
