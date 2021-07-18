using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Services
{
    public interface IExerciseService
    {
        public int Create(int workoutId, CreateExerciseDto dto);
    }
    public class ExercisesService : IExerciseService
    {
        private readonly LiftingAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public ExercisesService(LiftingAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int workoutId, CreateExerciseDto dto)
        {
            var workout = GetWorkoutById(workoutId);

            if (workout is null) throw new NotFoundException("Workout not found");

            var exerciseEntity = _mapper.Map<Exercises>(dto);

            exerciseEntity.WorkoutId = workoutId;

            _dbContext.Exercises.Add(exerciseEntity);
            _dbContext.SaveChanges();

            return exerciseEntity.Id;
        }
        private Workouts GetWorkoutById(int workoutId)
        {
            var workout = _dbContext.Workouts
                .FirstOrDefault(w => w.Id == workoutId);

            return workout;
        }
    }
}
