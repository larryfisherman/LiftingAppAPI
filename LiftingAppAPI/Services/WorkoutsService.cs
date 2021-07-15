using AutoMapper;
using LiftingAppAPI.Entities;
using LiftingAppAPI.Exceptions;
using LiftingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftingAppAPI.Services
{
    public class WorkoutsService
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
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

                if (user is null) throw new NotFoundException("User not found");

                var workoutEntity = _mapper.Map<Workouts>(dto);

              
            }

    }
}
