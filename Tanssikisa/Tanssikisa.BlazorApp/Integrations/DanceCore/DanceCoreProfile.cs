using AutoMapper;
using Integration.DanceCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tanssikisa.BlazorApp.Integrations.DanceCore
{
    public class DanceCoreProfile : Profile
    {
        public DanceCoreProfile()
        {
            CreateMap<DanceCoreVakLatIlmoittautuminen, VakLatIlmoittautuminen>();
        }
    }
}
