using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tanssikisa.DTO;

namespace Integration.DanceCore
{
    public static class DanceCoreMapper
    {
        // https://stackoverflow.com/questions/52550183/access-automapper-from-other-class-library-in-net-core
        private static readonly IMapper StaticMapper;

        static DanceCoreMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DanceCoreProfile>();
            });

            StaticMapper = config.CreateMapper();
        }

        public static T MapFrom<T>(object entity)
        {
            return StaticMapper.Map<T>(entity);
        }
    }
}
