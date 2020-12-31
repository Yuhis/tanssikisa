using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanssikisa.DTO
{
    public class VakLatKilpailuTapahtumaDTO
    {
        public Tapahtuma Tapahtuma { get; set; } = Tapahtuma.Info;
        public DateTime Aikaleima { get; set; } = DateTime.Now;
        public string Kuvaus { get; set; } = "";
    }

    public enum Tapahtuma
    {
        Info = 0,
        Ilmoittautunut,
        Maksanut
    }
}
