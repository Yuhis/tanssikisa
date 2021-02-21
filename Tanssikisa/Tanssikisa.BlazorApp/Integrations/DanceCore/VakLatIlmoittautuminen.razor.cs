using Integration.DanceCore;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanssikisa.BlazorApp.Integrations.DanceCore
{
    public partial class VakLatIlmoittautuminen : ComponentBase
    {
        public int RowNumber { get; set; } = 0;
        public string ID { get; set; } = "";
        public string MID { get; set; } = "";
        public string NID { get; set; } = "";
        public string EtunimiM { get; set; } = "";
        public string SukunimiM { get; set; } = "";
        public string EtunimiN { get; set; } = "";
        public string SukunimiN { get; set; } = "";
        public string Seura { get; set; } = "";
        public string Paikkakunta { get; set; } = "";
        public string Luokka { get; set; } = "";
        public string Sarja { get; set; } = "";
        public string TasoV { get; set; } = "";
        public string TasoL { get; set; } = "";
        public string Maksettu { get; set; } = "";
        public string Ilmoittautunut { get; set; } = "";

        public Dictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();

        [DisplayName("Pari")] public string Pari { get { return $"{EtunimiM} {SukunimiM} - {EtunimiN} {SukunimiN}"; } set { } }

        [DisplayName("Seura")] public string Edustusseura { get { return $"{Seura}, {Paikkakunta}"; } set { } }

        public string ValidointiVirheet 
        { get 
            { 
                var s = new StringBuilder();
                string prefix = "";
                foreach (KeyValuePair<string, List<string>> err in ValidationErrors)
                {
                    foreach (var msg in err.Value)
                    {
                        s.Append($"{prefix}{msg}");
                        prefix = ", ";
                    }
                }
                return s.ToString();
            } 
          set { }
        }
    }
}
