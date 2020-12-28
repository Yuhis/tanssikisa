using System;
using System.Collections.Generic;
using System.Text;

namespace Tanssikisa.DTO
{
    public class VakLatTaitoluokkaDTO
    {
        private static Dictionary<Taitoluokka, string> _taitoluokkaTaulu = new Dictionary<Taitoluokka, string>() {
            { Taitoluokka.Tuntematon, "-" },
            { Taitoluokka.F, "F" },
            { Taitoluokka.E, "E" },
            { Taitoluokka.D, "D" },
            { Taitoluokka.C, "C" },
            { Taitoluokka.B, "B" },
            { Taitoluokka.A, "A" }
        };

        public Taitoluokka Taitoluokka { get; set; } = Taitoluokka.Tuntematon;

        public VakLatTaitoluokkaDTO(Taitoluokka taitoluokka = Taitoluokka.Tuntematon)
        {
            Taitoluokka = taitoluokka;
        }

        public VakLatTaitoluokkaDTO(string tl)
        {
            Taitoluokka = Taitoluokka.Tuntematon;
            if (!tl.Contains(","))
            {
                if (Enum.TryParse(tl.Trim().ToUpper(), out Taitoluokka taitoluokka))
                {
                    if (Enum.IsDefined(typeof(Taitoluokka), taitoluokka))
                    {
                        Taitoluokka = taitoluokka;
                    }
                }
            }
        }
    }

    public enum Taitoluokka
    {
        Tuntematon = 0,
        F, E, D, C, B, A
    };
}
