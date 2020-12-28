using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace Integration.DanceCore
{
    public class DanceCoreValidator : AbstractValidator<DanceCoreVakLatIlmoittautuminen>
    {
        private static readonly Regex DanceCoreSarja = new Regex(@"^(?<luokka>[A-E](-[A-E]){0,1})\s*(\x28(?<laji>[LV])\x29){0,1}$");

        public DanceCoreValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("Parin ID puuttuu");
            RuleFor(x => x.MID).NotEmpty().WithMessage("Miehen ID puuttuu");
            RuleFor(x => x.NID).NotEmpty().WithMessage("Naisen ID puuttuu");
            RuleFor(x => x.EtunimiM).NotEmpty().WithMessage("Miehen etunimi puuttuu");
            RuleFor(x => x.SukunimiM).NotEmpty().WithMessage("Miehen sukunimi puuttuu");
            RuleFor(x => x.EtunimiN).NotEmpty().WithMessage("Naisen sukunimi puuttuu");
            RuleFor(x => x.SukunimiM).NotEmpty().WithMessage("Naisen sukunimi puuttuu");
            RuleFor(x => x.Seura).NotEmpty().WithMessage("Seura puuttuu");
            RuleFor(x => x.Paikkakunta).NotEmpty().WithMessage("Paikkakunta puuttuu");
            RuleFor(x => x.Luokka).NotEmpty().WithMessage("Luokka puuttuu");
            RuleFor(x => x.Sarja).NotEmpty().WithMessage("Sarja puuttuu");
            RuleFor(x => x.Sarja).Must(BeAValidSarja).WithMessage("Sarja ei ole oikeassa muodossa");
            RuleFor(x => x.TasoV).NotEmpty().WithMessage("TasoV puuttuu");
            RuleFor(x => x.TasoL).NotEmpty().WithMessage("TasoL puuttuu");
            RuleFor(x => x.Maksettu).NotEmpty().WithMessage("Maksettu puuttuu");
            RuleFor(x => x.Ilmoittautunut).NotEmpty().WithMessage("Ilmoittautunut puuttuu");
        }

        private bool BeAValidSarja(string sarja)
        {
            Match m = DanceCoreSarja.Match(sarja.Trim().ToUpper());

            return m.Success;
        }
    }
}
