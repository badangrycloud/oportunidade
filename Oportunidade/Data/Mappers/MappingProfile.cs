using AutoMapper;
using Data.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Channel, RssEntity>();
            CreateMap<Item, ItemEntity>();
        }
    }
}
