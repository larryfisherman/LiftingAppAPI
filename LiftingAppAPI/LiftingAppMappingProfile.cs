using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI
{
    public class LiftingAppMappingProfile : Profile
    {
        public LiftingAppMappingProfile()
        {
            CreateMap<CreateRecipeDto, Recipes>();
        }
    }
}
