using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class ExcercisesService: FirebaseService, IExcercisesService
    {
        public async Task<Excercise> GetExcercise(string excerciseId)
        {
            DocumentSnapshot excerciseSnapshot = await this.FirestoreDb.Collection("Excercises").Document(excerciseId).GetSnapshotAsync();
            if (!excerciseSnapshot.Exists)
            {
                return null;
            }
            Dictionary<string, object> fields = excerciseSnapshot.ToDictionary();
            string name = fields["name"].ToString();
            string tempo = fields["tempo"].ToString();
            int reps = int.Parse(fields["reps"].ToString());
            int sets = int.Parse(fields["sets"].ToString());

            Excercise excercise = new Excercise();
            excercise.Name = name;
            excercise.Tempo = tempo;
            excercise.Reps = reps;
            excercise.Sets = sets;

            return excercise;
        }

    }
}
