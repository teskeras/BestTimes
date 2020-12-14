using AutoMapper;
using BestTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestTimes.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BestTimeFormModel, BestTime>();
        }
    }
}
