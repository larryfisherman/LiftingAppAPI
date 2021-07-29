using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Exceptions;
using LiftingAppAPI.Models;
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
        //public Exercises GetById(int workoutId, int exerciseId);
        public List<ExerciseDto> GetAll(int workoutId);
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

            exerciseEntity.WorkoutsId = workoutId;

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

        //public Exercises GetById(int workoutId, int exerciseId)
        //{
        //    var workout = _dbContext.Workouts.FirstOrDefault(w => w.Id == workoutId);
        //    if(workout is null)
        //    {
        //        throw new NotFoundException("Workout not found");
        //    }

        //    var exercise = _dbContext.Exercises.FirstOrDefault(e => e.Id == exerciseId);
        //    if(exercise is null || exercise.WorkoutsId != workoutId)
        //    {
        //        throw new NotFoundException("Exercise not found");
        //    }

        //    var exerciseDto = _mapper.Map<Exercises>(exercise);
        //    return exerciseDto;
        //}

        public List<ExerciseDto> GetAll(int workoutId)
        {
            //var workout = _dbContext.Workouts.Include(e => e.Exercises).FirstOrDefault(w => w.Id == workoutId);
            //if (workout is null) throw new NotFoundException("Workout not found");

            //var exerciseDto = _mapper.Map<List<Exercises>>(workout.Exercises);
            //return exerciseDto;

            var workout = _dbContext.Workouts.Any(p => p.Id == workoutId);

            if(!workout)
            {
                throw new NotFoundException("Workout not found");
            }

            var exercises = _dbContext.Exercises.Where(p => p.WorkoutsId == workoutId).ToList();
            var exerciseDto = exercises.Select(p => _mapper.Map<ExerciseDto>(p)).ToList();
            return exerciseDto;

        }


    }
}
