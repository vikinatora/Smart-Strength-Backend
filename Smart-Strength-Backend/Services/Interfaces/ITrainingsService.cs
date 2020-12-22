using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface ITrainingsService : IFirebaseService
    {
        Task<string> CreateTrainingProgram(TrainingProgram trainingProgram);
        Task<string> GetTrainingProgramId(string userId);
        Task<Workout> GetWorkout(string userId);
    }
}
