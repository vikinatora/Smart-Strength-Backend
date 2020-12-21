using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IUsersService : IFirebaseService
    {
        Task<string> CreateUser(string fullName, string fbToken);

        Task<string> GetIdFromToken(string fbToken);
        Task<bool> AddTrainingProgramToUser(TrainingProgram trainingProgram, string userId);
        Task<User> GetUser(string userId);
    }
}
