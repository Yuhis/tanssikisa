using System;
using System.Collections.Generic;
using System.Text;

namespace Tanssikisa.DTO
{
    public class VakLatPariDTO : ParitanssiPariDTO
    {
        public VakLatIkasarjaDTO Ikasarja { get; set; } = new VakLatIkasarjaDTO();
        public VakLatTaitoluokkaDTO VakioLuokka { get; set; } = new VakLatTaitoluokkaDTO();
        public VakLatTaitoluokkaDTO LatinLuokka { get; set; } = new VakLatTaitoluokkaDTO();
    }
}
