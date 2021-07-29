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
    public interface IWorkoutsService
    {
        public int Create(int userId, CreateWorkoutDto dto);
        public IEnumerable<WorkoutDto> GetAll();
        public Workouts GetById(int userId, int workoutId);


    }
    public class WorkoutsService : IWorkoutsService
    {
        private readonly LiftingAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkoutsService(LiftingAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<WorkoutDto> GetAll()
        {
            var exercises = _dbContext.Workouts.Include(w => w.Exercises).Select(p=>_mapper.Map<WorkoutDto>(p))
                .ToList();

            return exercises;
        }

        public Workouts GetById(int userId, int workoutId)
        {
            var user = GetUserById(userId);

            var workout = _dbContext.Workouts.FirstOrDefault(w => w.Id == workoutId);
            if (workout is null || workout.Id != workoutId)
            {
                throw new NotFoundException("Workout not found");
            }

            var workoutEntity = _mapper.Map<Workouts>(workout);
            return workoutEntity;
        }

        public int Create(int userId, CreateWorkoutDto dto)
        {
            var user = GetUserById(userId);

            if (user is null) throw new NotFoundException("User not found");
            
            var workoutEntity = _mapper.Map<Workouts>(dto);

            workoutEntity.UserId = userId;
            _dbContext.Workouts.Add(workoutEntity);
            _dbContext.SaveChanges();
           
            return workoutEntity.Id;
        }

        private User GetUserById(int userId)
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Id == userId);

            return user;
        }
    }
}
