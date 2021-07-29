using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Models;
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
            #region Create models to backend models
            CreateMap<CreateRecipeDto, Recipes>();
            CreateMap<CreateWorkoutDto, Workouts>();
            CreateMap<CreateExerciseDto, Exercises>();
            #endregion

            #region DTO to FULL MODEL
            CreateMap<ExerciseDto, Exercises>();
            CreateMap<WorkoutDto, Workouts>();
            #endregion

            #region FULL MODEL to DTO
            CreateMap<Exercises, ExerciseDto>();
            CreateMap<Workouts, WorkoutDto>();
            #endregion
        }
    }
}
