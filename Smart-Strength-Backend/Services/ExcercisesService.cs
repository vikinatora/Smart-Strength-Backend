using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class ExcercisesService: FirebaseService
    {
        public async Task<Excercise> GetExcercise(string excerciseId)
        {
            var excerciseSnapshot = await this.FirestoreDb.Collection("Excercises").Document(excerciseId).GetSnapshotAsync();
            if (!excerciseSnapshot.Exists)
            {
                return null;
            }
            var fields = excerciseSnapshot.ToDictionary();
            var name = fields["name"].ToString();
            var tempo = fields["tempo"].ToString();
            var reps = int.Parse(fields["reps"].ToString());
            var sets = int.Parse(fields["sets"].ToString());

            var excercise = new Excercise();
            excercise.Name = name;
            excercise.Tempo = tempo;
            excercise.Reps = reps;
            excercise.Sets = sets;

            return excercise;
        }

    }
}
