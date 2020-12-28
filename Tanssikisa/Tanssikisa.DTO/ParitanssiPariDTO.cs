using System;

namespace Tanssikisa.DTO
{
    public class ParitanssiPariDTO
    {
        public string ParitanssiPariId { get; set; } = "";
        public HenkiloDTO Vieja { get; set; } = new HenkiloDTO();
        public HenkiloDTO Seuraaja { get; set; } = new HenkiloDTO();
        public EdustusseuraDTO Edustusseura { get; set; } = new EdustusseuraDTO();
    }
}
