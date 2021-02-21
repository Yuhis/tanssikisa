using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Tanssikisa.DTO;

namespace Integration.DanceCore
{
    public static class CustomValueResolver
    {
        private static readonly Regex DanceCoreSarja = new Regex(@"^(?<luokka>[A-E])\s*(\x28(?<laji>[LV])\x29){0,1}$");

        private static readonly Dictionary<string, string> IkasarjaTaulu = new Dictionary<string, string>() {
            { "Lapsi 1", "L1" },
            { "Lapsi 2", "L2" },
            { "Juniori 1", "J1" },
            { "Juniori 2", "J2" },
            { "Nuoriso", "Nu" },
            { "Yleinen", "Yl" },
            { "Seniori 1", "S1" },
            { "Seniori 2", "S2" },
            { "Seniori 3", "S3" },
            { "Seniori 4", "S4" },
            { "Seniori 5", "S5" }
        };

        private static readonly Dictionary<Taitoluokka, string> TaitoluokkaTaulu = new Dictionary<Taitoluokka, string>() {
            { Taitoluokka.Tuntematon, "Tuntematon" },
            { Taitoluokka.F, "F" },
            { Taitoluokka.E, "E" },
            { Taitoluokka.D, "D" },
            { Taitoluokka.C, "C" },
            { Taitoluokka.B, "B" },
            { Taitoluokka.A, "A" }
            };

        private static readonly Dictionary<string, string> Kilpailulaji = new Dictionary<string,string>()
        {
            { "-", "10-Tanssi"},
            { "V", "Vakio"},
            { "L", "Latin"}
        };

        /*public static VakLatTaitoluokkaDTO MapSarja(string sarja)
        {
            string luokka = sarja.Trim().ToLower();
            Taitoluokka taitoluokka = TaitoluokkaTaulu.Where(p => p.Value.ToLower() == luokka)
                .Select(p => p.Key)
                .DefaultIfEmpty(Taitoluokka.Tuntematon).First();
            return new VakLatTaitoluokkaDTO(taitoluokka);
        }*/

        public static string MapVakLatTaitoluokka(VakLatTaitoluokkaDTO taitoluokka)
        {
            return TaitoluokkaTaulu[taitoluokka.Taitoluokka];
        }

        public static VakLatKilpailuDTO MapKilpailu(string luokka, string sarja)
        {
            string danceCoreLuokka = luokka.Trim();
            if (!IkasarjaTaulu.ContainsKey(danceCoreLuokka))
            {
                return new VakLatKilpailuDTO();
            }

            //Ikasarja ikasarja = IkasarjaTaulu.Where(p => p.Value.ToLower() == danceCoreSarja)
            //    .Select(p => p.Key)
            //    .DefaultIfEmpty(Ikasarja.Tuntematon).First();


            Match m = DanceCoreSarja.Match(sarja.Trim().ToUpper());
            if (!m.Success)
            {
                return new VakLatKilpailuDTO();
            }

            string taitoluokka = m.Groups["luokka"].ToString();
            string laji = "-";
            if (m.Groups.ContainsKey("laji"))
            {
                laji = m.Groups["laji"].ToString();
            }

            var kilpailu = new VakLatKilpailuDTO
            {
                KilpailuId = $"{IkasarjaTaulu[danceCoreLuokka]}{taitoluokka}{laji}",
                KilpailuNimi = $"{danceCoreLuokka} {taitoluokka} {Kilpailulaji[laji]}"
            };

            return kilpailu;
        }
    }
}
