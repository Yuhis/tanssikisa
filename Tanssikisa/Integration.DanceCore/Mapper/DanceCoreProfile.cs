using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tanssikisa.DTO;

namespace Integration.DanceCore
{
    public class DanceCoreProfile : Profile
    {
        public DanceCoreProfile()
        {
            CreateMap<VakLatKilpailuIlmoittautuminenDTO, DanceCoreVakLatIlmoittautuminen>()
                .ForMember(dest => dest.ID,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.ParitanssiPariId))
                .ForMember(dest => dest.MID,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Vieja.HenkiloId))
                .ForMember(dest => dest.EtunimiM,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Vieja.Etunimi))
                .ForMember(dest => dest.SukunimiM,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Vieja.Sukunimi))
                .ForMember(dest => dest.NID,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Seuraaja.HenkiloId))
                .ForMember(dest => dest.EtunimiN,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Seuraaja.Etunimi))
                .ForMember(dest => dest.SukunimiN,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Seuraaja.Sukunimi))
                .ForMember(dest => dest.Seura,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Edustusseura.EdustusseuraNimi))
                .ForMember(dest => dest.Paikkakunta,
                    opts => opts.MapFrom(
                        src => src.VakLatPari.Edustusseura.EdustusseuraPaikkakunta))
                .ForMember(dest => dest.Sarja,
                    opts => opts.Ignore())
                .ForMember(dest => dest.Luokka,
                    opts => opts.Ignore())
                .ForMember(dest => dest.TasoV,
                    opts => opts.Ignore())
                .ForMember(dest => dest.TasoL,
                    opts => opts.Ignore())
                .ForMember(dest => dest.Maksettu,
                    opts => opts.Ignore())
                .ForMember(dest => dest.Ilmoittautunut,
                    opts => opts.Ignore())
                .ForMember( dest => dest.ValidationFailures,
                    opts => opts.Ignore())
                .ReverseMap()
                    .ForMember(dest => dest.VakLatKilpailu,
                            opts => opts.MapFrom(
                                src => CustomValueResolver.MapKilpailu(src.Luokka, src.Sarja)));
        }
    }
}
