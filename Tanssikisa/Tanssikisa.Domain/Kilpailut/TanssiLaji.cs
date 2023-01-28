using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanssikisa.Domain.Kilpailut
{
    public class TanssiLaji
    {
        private static Dictionary<Laji, Tuple<string, string>> _lajiTaulu = new Dictionary<Laji, Tuple<string, string>>() {
            { Laji.Tuntematon, new Tuple<string, string>( "-", "Tuntematon") },
            { Laji.Vakiot, new Tuple<string, string>( "V", "Vakiot") },
            { Laji.Latin, new Tuple<string, string>( "L", "Latinalaiset") },
            { Laji.Kymppi, new Tuple<string, string>( "-", "10-Tanssi") }
        };

        public Laji Laji { get; set; } = Laji.Tuntematon;

        public TanssiLaji(Laji tanssilaji)
        {
            Laji = tanssilaji;
        }
    }

    public enum Laji
    {
        Tuntematon = 0,
        Vakiot,
        Latin,
        Kymppi
    }
}
