using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IWorkoutsService
    {
        public string Tempo { get; set; }
        public int Difficulty { get; set; }
        public ExcercisesRepo ExcercisesRepo { get; set; }

        Workout[] CreateWorkouts(string fitnessGoal, string trainingExperience, string workoutsPerWeek);
        Workout[] CreateULTrainingRegime(string workoutsPerWeek, bool includeCardio);
        Workout[] CreatePPLTrainingRegime(string workoutsPerWeek, bool includeCardio);
        Workout CreatePullWorkout(bool includeCardio);
        Workout CreatePushWorkout(bool includeCardio);
        Workout[] CreateFulLBodyTrainingRegime(string workoutsPerWeek, bool includeCardio);
        Workout CreateChestAndTricepsWorkout(bool includeCardio);
        Workout CreateShoulderWorkout(bool includeCardio);
        Workout CreateBackAndBicepsWorkout(bool includeCardio);
        Workout CreateLegsWorkout(bool includeCardio);
        Workout CreateMixedWorkout(bool includeCardio);
        Workout CreateUpperBodyWorkout(bool includeCardio);
    }
    
}
