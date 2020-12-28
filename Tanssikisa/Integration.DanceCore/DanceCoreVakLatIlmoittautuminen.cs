using System.Collections.Generic;
using FluentValidation.Results;

namespace Integration.DanceCore
{
    public class DanceCoreVakLatIlmoittautuminen
    {
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

        public List<ValidationFailure> ValidationFailures { get; set; } = new List<ValidationFailure>();


        public bool IsHeaderRow => string.Equals("ID", ID) && string.Equals("MID", MID) && string.Equals("NID", NID) &&
                                   string.Equals("EtunimiM", EtunimiM) && string.Equals("SukunimiM", SukunimiM) &&
                                   string.Equals("EtunimiN", EtunimiN) && string.Equals("SukunimiN", SukunimiN);
    }
}
