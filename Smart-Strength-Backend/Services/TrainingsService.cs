using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class TrainingsService:FirebaseService
    {
        public async Task<string> CreateTrainingProgram(TrainingProgram trainingProgram)
        {
            var workoutCollection = this.FirestoreDb.Collection("Workouts");
            var excerciseCollection = this.FirestoreDb.Collection("Excercises");
            var exIds = new List<object>();
            var workoutIds = new List<object>();
            var trainingProgramCollection = this.FirestoreDb.Collection("Training Programs");
            foreach (Workout workout in trainingProgram.Workouts)
            {
                foreach (Excercise excercise in workout.Excercises) 
                {
                    Dictionary<string, object> exObj = new Dictionary<string, object>
                    {
                        { "sets", excercise.Sets },
                        { "reps", excercise.Reps },
                        { "tempo", excercise.Tempo },
                        { "name", excercise.Name },
                    };

                    var result = await excerciseCollection.AddAsync(exObj);
                    exIds.Add(result.Id);
                }

                Dictionary<string, object> workoutObj = new Dictionary<string, object>
                {
                    { "excercises", exIds },
                };

                var wrResult = await workoutCollection.AddAsync(workoutObj);
                workoutIds.Add(wrResult.Id);
                Console.WriteLine();
            }

            var trObj = new Dictionary<string, object>
            {
                { "name", trainingProgram.Name },
                { "workouts", workoutIds }
            };

            var trResult = await trainingProgramCollection.AddAsync(trObj);

            return trResult.Id;
        }
    }
}
