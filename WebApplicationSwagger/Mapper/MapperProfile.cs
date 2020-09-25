using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.Resource;
using TicketingSystem.Core.Models;

namespace TicketingSystem.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Domain To Resource
            CreateMap<Ticket, TicketResource>();

            //Resource to Domain
            CreateMap<TicketResource, Ticket>();
        }

    }
}
