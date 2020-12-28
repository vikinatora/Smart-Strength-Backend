using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class ExcercisesRepo: IExcercisesRepo
    {
        public int Difficulty { get; set; }
        public string Tempo { get; set; }
        public string CardioTempo { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }

        public void Init(string progressingRate, string trainingExperience, string fitnessGoal)
        {
            SetTempo(progressingRate);
            SetDifficulty(trainingExperience);
            SetCardioTempo(this.Difficulty);
            SetRepsAndSets(fitnessGoal);

        }
        public void SetCardioTempo(int difficulty)
        {
            if (difficulty == 1 || difficulty == 2)
            { 
                this.CardioTempo = "slow pace";
            }
            else if (difficulty == 3)
            {
                this.CardioTempo = "normal pace";
            }
            else
            {
                this.CardioTempo = "fast pace";
            }
        }
        public void SetDifficulty(string trainingExperience)
        {
            this.Difficulty = int.Parse(trainingExperience);
        }

        public void SetTempo(string progressionRate)
        {
            if (progressionRate == "1" || progressionRate == "2")
            {
                this.Tempo = "normal";
            }
            else if (progressionRate == "3")
            {
                this.Tempo = "slow";
            }
            else if (progressionRate == "4")
            {
                this.Tempo = "very slow";
            }
        }

        public void SetRepsAndSets(string fitnessGoal)
        {
            if (fitnessGoal == "1")
            {
                this.Reps = 10;
                this.Sets = 4;
            }
            else if (fitnessGoal == "3")
            {
                this.Reps = 8;
                this.Sets = 3;
            }
            else
            {
                this.Reps = 12;
                this.Sets = 3;
            }
        }

        public Excercise CreateExcercise(string name)
        {
            return new Excercise()
            {
                Name = name,
                Reps = this.Reps,
                Sets = this.Sets,
                Tempo = this.CardioTempo
            };
        }
        public Excercise GetTreadmillExcercise()
        {
            return this.CreateExcercise("Treadmill");
        }

        public Excercise GetBenchPressExcercise()
        {
            return this.CreateExcercise("Bench press");
        }

        public Excercise GetShoulderPressExcercise()
        {
            return this.CreateExcercise("Shoulder press");
        }

        public Excercise GetUpperDumbellBenchPressExcercise()
        {
            return this.CreateExcercise("Upper dumbell bench press");
        }

        public Excercise GetDipsExcercise()
        {
            return this.CreateExcercise("Dips");
        }

        public Excercise GetTricepsPushdownExcercise()
        {
            return this.CreateExcercise("Triceps pushdown");
        }

        public Excercise GetPullUpsExcercise()
        {
            return this.CreateExcercise("Pull ups");
        }

        public Excercise GetLatPulldownExcercise()
        {
            return this.CreateExcercise("Lat pulldown");
        }

        public Excercise GetFacePullsExcercise()
        {
            return this.CreateExcercise("Face pulls");
        }

        public Excercise GetBicepsCurlsExcercise()
        {
            return this.CreateExcercise("Bicep curls");
        }

        public Excercise GetHammerCurlsExcercise()
        {
            return this.CreateExcercise("Hammer curls");
        }

        public Excercise GetSquatsExcercise()
        {
            return this.CreateExcercise("Squats");
        }

        public Excercise GetLegExtensionsExcercise()
        {
            return this.CreateExcercise("Leg extensions");
        }

        public Excercise GetLegPressExcercise()
        {
            return this.CreateExcercise("Leg press");
        }

        public Excercise GetCrunchesExcercise()
        {
            return this.CreateExcercise("Crunches");
        }

        public Excercise GetLegRaisesExcercise()
        {
            return this.CreateExcercise("Leg raises");
        }

        public Excercise GetCrossoverExcercise()
        {
            return this.CreateExcercise("Cable crossover");
        }

        public Excercise GetDumbellShoulderPress()
        {
            return this.CreateExcercise("Dumbell shoulder press");
        }

        public Excercise GetSeatedCableRow()
        {
            return this.CreateExcercise("Seated cable row");
        }

        public Excercise GetLateralRaisesExcercise()
        {
            return this.CreateExcercise("Dumbell lateral raises");
        }

    }
}
