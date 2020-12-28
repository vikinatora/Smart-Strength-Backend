using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IDietsService : IFirebaseService
    {
        Diet CreateDiet(string gender, double weight, int height, int fitnessGoal, int age, string progressionRate);
        double CalculateProteinFatsCarbs(double weight, double calories, double proteinCoeficient, double fatCoeficient, out double protein, out double fats, out double carbs);
        double GetCaloriesFromGoal(int fitnessGoal, string progressionRate, double calories);
        double CalcualteBMR(string gender, double weight, int height, int age);
        Task<bool> AddDietToUser(Diet diet, string userId, string gender, double weight, int height, int age);

    }
}
