using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class TrainingsService : FirebaseService
    {
        public ExcercisesService ExcercisesService { get; }

        public TrainingsService()
        {
            this.ExcercisesService = new ExcercisesService();
        }

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
                    { "day", workout.Day },
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
        public async Task<string> GetTrainingProgramId(string userId)
        {

            var docRef = this.FirestoreDb.Collection("Users").Document(userId);
            var docSnapshot = await docRef.GetSnapshotAsync();
            if (docSnapshot.Exists)
            {
                Dictionary<string, object> docDict = docSnapshot.ToDictionary();
                string trainingProgramId = docDict["trainingProgram"].ToString();
                return trainingProgramId;
            }

            return null;

        }

        public async Task<Workout> GetWorkout(string userId)
        {
            try
            {
                var workoutId = await this.GetTrainingProgramId(userId);
                if (String.IsNullOrEmpty(workoutId))
                {
                    return null;
                }
                var workoutsCollection = this.FirestoreDb.Collection("Training Programs").Document(workoutId);
                var snapshot = await workoutsCollection.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    return null;
                }

                var workoutsDict = snapshot.ToDictionary();
                var workoutIds = ((List<object>)workoutsDict["workouts"]).Cast<string>();
                string dayName = DateTime.Now.DayOfWeek.ToString();
                var workoutObj = new Workout();
                var excercises = new List<Excercise>();
                foreach (string id in workoutIds)
                {
                    var workout = this.FirestoreDb.Collection("Workouts").Document(id);
                    var snap = await workout.GetSnapshotAsync();
                    if (!snap.Exists)
                    {
                        continue;
                    }
                    Dictionary<string, object> fields = snap.ToDictionary();
                    string day = fields["day"].ToString();
                    var excerciseIds = ((List<object>)fields["excercises"]).Cast<string>();
                    if (dayName == day)
                    {
                        foreach (string exId in excerciseIds)
                        {
                            Excercise ex = await this.ExcercisesService.GetExcercise(exId);
                            if (ex != null)
                            {
                                excercises.Add(ex);
                            }
                        }
                        break;
                    }
                }
                if (excercises.Count == 0)
                {
                    return null;
                } else
                {
                    workoutObj.Excercises = excercises.ToArray();
                    return workoutObj;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}
