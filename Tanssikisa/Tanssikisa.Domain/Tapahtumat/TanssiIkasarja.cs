namespace Tanssikisa.Domain.Tapahtumat
{
    public class TanssiIkasarja
    {
        private static Dictionary<Ikasarja, Tuple<string, string>> _ikasarjaTaulu = new Dictionary<Ikasarja, Tuple<string, string>>() {
            { Ikasarja.Tuntematon, new Tuple<string, string>( "--", "Tuntematon") },
            { Ikasarja.Lapsi_1, new Tuple<string, string>( "L1", "Lapsi 1") },
            { Ikasarja.Lapsi_2, new Tuple<string, string>( "L2", "Lapsi 2") },
            { Ikasarja.Juniori_1, new Tuple<string, string>( "J1", "Juniori 1") },
            { Ikasarja.Juniori_2, new Tuple<string, string>( "J2", "Juniori 2") },
            { Ikasarja.Nuoriso, new Tuple<string, string>( "NU", "Nuoriso") },
            { Ikasarja.Yleinen, new Tuple<string, string>( "YL", "Yleinen") },
            { Ikasarja.Seniori_1, new Tuple<string, string>( "S1", "Seniori 1") },
            { Ikasarja.Seniori_2, new Tuple<string, string>( "S2", "Seniori 2") },
            { Ikasarja.Seniori_3, new Tuple<string, string>( "S3", "Seniori 3") },
            { Ikasarja.Seniori_4, new Tuple<string, string>( "S4", "Seniori 4") },
            { Ikasarja.Seniori_5, new Tuple<string, string>( "S5", "Seniori 5") }
        };

        public Ikasarja Ikasarja { get; set; } = Ikasarja.Tuntematon;

        public TanssiIkasarja(Ikasarja ikasarja = Ikasarja.Tuntematon)
        {
            Ikasarja = ikasarja;
        }
    }

    public enum Ikasarja
    {
        Tuntematon = 0,
        Lapsi_1,
        Lapsi_2,
        Juniori_1,
        Juniori_2,
        Nuoriso,
        Yleinen,
        Seniori_1,
        Seniori_2,
        Seniori_3,
        Seniori_4,
        Seniori_5
    }
}
