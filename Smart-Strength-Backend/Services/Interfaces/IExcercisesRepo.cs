using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IExcercisesRepo
    {
        public int Difficulty { get; set; }
        public string Tempo { get; set; }
        public string CardioTempo { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        void Init (string progressingRate, string trainingExperience, string fitnessGoal);
        void SetCardioTempo(int difficulty);
        void SetDifficulty(string trainingExperience);
        void SetTempo(string progressionRate);
        void SetRepsAndSets(string fitnessGoal);
        Excercise CreateExcercise(string name);
        Excercise GetTreadmillExcercise();
        Excercise GetBenchPressExcercise();
        Excercise GetShoulderPressExcercise();
        Excercise GetPullUpsExcercise();
        Excercise GetLatPulldownExcercise();
        Excercise GetSeatedCableRow();
        Excercise GetFacePullsExcercise();
        Excercise GetBicepsCurlsExcercise();
        Excercise GetHammerCurlsExcercise();
        Excercise GetUpperDumbellBenchPressExcercise();
        Excercise GetLateralRaisesExcercise();
        Excercise GetDipsExcercise();
        Excercise GetTricepsPushdownExcercise();
        Excercise GetCrossoverExcercise();
        Excercise GetDumbellShoulderPress();
        Excercise GetSquatsExcercise();
        Excercise GetLegExtensionsExcercise();
        Excercise GetLegPressExcercise();
        Excercise GetCrunchesExcercise();
        Excercise GetLegRaisesExcercise();
    }
}
