﻿using AutoMapper;

namespace Data.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
        }
    }
}
