namespace Tanssikisa.Domain.Kilpailijat
{
    public class Henkilo
    {
        public string HenkiloId { get; set; } = "";
        public string Etunimi { get; set; } = "";
        public string Sukunimi { get; set; } = "";
        public string Nimi { get { return $"{Etunimi} {Sukunimi}".Trim(); } }
    }
}