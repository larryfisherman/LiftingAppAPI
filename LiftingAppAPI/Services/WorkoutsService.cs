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
                .Include(w => w.Workouts)
                .FirstOrDefault(u => u.Id == userId);

            return user;
        }
    }
}
