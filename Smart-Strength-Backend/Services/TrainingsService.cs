using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class TrainingsService : FirebaseService, ITrainingsService
    {
        public IExcercisesService ExcercisesService { get; }

        public TrainingsService(IExcercisesService excercisesService)
        {
            this.ExcercisesService = excercisesService;
        }

        public async Task<string> CreateTrainingProgram(TrainingProgram trainingProgram)
        {
            CollectionReference workoutCollection = this.FirestoreDb.Collection("Workouts");
            CollectionReference excerciseCollection = this.FirestoreDb.Collection("Excercises");
            List<object> exIds = new List<object>();
            List<object> workoutIds = new List<object>();
            CollectionReference trainingProgramCollection = this.FirestoreDb.Collection("Training Programs");
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

                    DocumentReference result = await excerciseCollection.AddAsync(exObj);
                    exIds.Add(result.Id);
                }

                Dictionary<string, object> workoutObj = new Dictionary<string, object>
                {
                    { "excercises", exIds },
                    { "day", workout.Day },
                };

                DocumentReference wrResult = await workoutCollection.AddAsync(workoutObj);
                workoutIds.Add(wrResult.Id);
                Console.WriteLine();
            }

            Dictionary<string, object> trObj = new Dictionary<string, object>
            {
                { "name", trainingProgram.Name },
                { "workouts", workoutIds }
            };

            DocumentReference trResult = await trainingProgramCollection.AddAsync(trObj);

            return trResult.Id;
        }
        public async Task<string> GetTrainingProgramId(string userId)
        {

            DocumentReference docRef = this.FirestoreDb.Collection("Users").Document(userId);
            DocumentSnapshot docSnapshot = await docRef.GetSnapshotAsync();
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
                string workoutId = await this.GetTrainingProgramId(userId);
                if (String.IsNullOrEmpty(workoutId))
                {
                    return null;
                }
                DocumentReference workoutsCollection = this.FirestoreDb.Collection("Training Programs").Document(workoutId);
                DocumentSnapshot snapshot = await workoutsCollection.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    return null;
                }

                Dictionary<string, object> workoutsDict = snapshot.ToDictionary();
                IEnumerable<string> workoutIds = ((List<object>)workoutsDict["workouts"]).Cast<string>();
                string dayName = DateTime.Now.DayOfWeek.ToString();
                Workout workoutObj = new Workout();
                List<Excercise> excercises = new List<Excercise>();
                foreach (string id in workoutIds)
                {  
                    DocumentReference workout = this.FirestoreDb.Collection("Workouts").Document(id);
                    DocumentSnapshot snap = await workout.GetSnapshotAsync();
                    if (!snap.Exists)
                    {
                        continue;
                    }
                    Dictionary<string, object> fields = snap.ToDictionary();
                    string day = fields["day"].ToString();
                    IEnumerable<string> excerciseIds = ((List<object>)fields["excercises"]).Cast<string>();
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
