using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class WorkoutsService
    {
        public string Tempo { get; private set; }
        public int Difficulty { get; private set; }
        public ExcercisesRepo ExcercisesRepo { get; private set; }

        public WorkoutsService(Questionnaire questionnaire, ExcercisesRepo excercisesRepo)
        {
            this.ExcercisesRepo = excercisesRepo;
        }

        public Workout[] CreateWorkouts(Questionnaire questionnaire)
        {
            Workout[] program = null;

            // Lose weight || Build muscle and lose weiУght
            if (questionnaire.FitnessGoal == "1" || questionnaire.FitnessGoal == "3")
            {
                if (questionnaire.TrainingExperience == "1")
                {
                    program = this.CreateFulLBodyTrainingRegime(questionnaire, true);
                }
                else if (questionnaire.TrainingExperience == "2" || questionnaire.TrainingExperience == "3")
                {
                    program = this.CreatePPLTrainingRegime(questionnaire, true);
                }
                else
                {
                    program = this.CreateULTrainingRegime(questionnaire, true);
                }
            }
            // Build muscle || Maintain
            else if (questionnaire.FitnessGoal == "2" || questionnaire.FitnessGoal == "4")
            {
                if (questionnaire.TrainingExperience == "1")
                {
                    program = this.CreateFulLBodyTrainingRegime(questionnaire, false);
                }
                else if (questionnaire.TrainingExperience == "2" || questionnaire.TrainingExperience == "3")
                {
                    program = this.CreatePPLTrainingRegime(questionnaire, false);
                }
                else
                {
                    program = this.CreateULTrainingRegime(questionnaire, false);
                }
            }
            return program;
        }

        private Workout[] CreateULTrainingRegime(Questionnaire questionnaire, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();

            Workout upperWorkout = CreateUpperBodyWorkout(includeCardio);
            Workout lowerWorkout = CreateLegsWorkout(includeCardio);

            switch (questionnaire.WorkoutsPerWeek)
            {
                case "3":
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    break;

                case "4":
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    workouts.Add(upperWorkout);
                    break;

                case "5":
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    workouts.Add(upperWorkout);
                    break;

                case "6":
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    workouts.Add(upperWorkout);
                    workouts.Add(lowerWorkout);
                    break;
            }

            return workouts.ToArray();
        }

        private Workout[] CreatePPLTrainingRegime(Questionnaire questionnaire, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();

            Workout pushWorkout = CreatePushWorkout(includeCardio);
            Workout pullWorkout = CreatePullWorkout(includeCardio);
            Workout legsWorkout = CreateLegsWorkout(includeCardio);

            switch (questionnaire.WorkoutsPerWeek)
            {
                case "3":
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    workouts.Add(legsWorkout);
                    break;

                case "4":
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    workouts.Add(legsWorkout);
                    break;

                case "5":
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    workouts.Add(legsWorkout);
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    break;

                case "6":
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    workouts.Add(legsWorkout);
                    workouts.Add(pushWorkout);
                    workouts.Add(pullWorkout);
                    workouts.Add(legsWorkout);
                    break;
            }

            return workouts.ToArray();
        }

        private Workout CreatePullWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetPullUpsExcercise());
            excecises.Add(this.ExcercisesRepo.GetLatPulldownExcercise());
            excecises.Add(this.ExcercisesRepo.GetSeatedCableRow());
            excecises.Add(this.ExcercisesRepo.GetFacePullsExcercise());
            excecises.Add(this.ExcercisesRepo.GetBicepsCurlsExcercise());
            excecises.Add(this.ExcercisesRepo.GetHammerCurlsExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreatePushWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetShoulderPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetUpperDumbellBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetLateralRaisesExcercise());
            excecises.Add(this.ExcercisesRepo.GetDipsExcercise());
            excecises.Add(this.ExcercisesRepo.GetTricepsPushdownExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout[] CreateFulLBodyTrainingRegime(Questionnaire questionnaire, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();

            Workout mixedWorkout = CreateMixedWorkout(includeCardio);
            for (int i = 0; i < int.Parse(questionnaire.WorkoutsPerWeek); i++)
            {
                workouts.Add(mixedWorkout);
            }

            return workouts.ToArray();
        }

        private Workout CreateChestAndTricepsWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if(includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetUpperDumbellBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetCrossoverExcercise());
            excecises.Add(this.ExcercisesRepo.GetDipsExcercise());
            excecises.Add(this.ExcercisesRepo.GetTricepsPushdownExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreateShoulderWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetShoulderPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetDumbellShoulderPress());
            excecises.Add(this.ExcercisesRepo.GetLateralRaisesExcercise());
            excecises.Add(this.ExcercisesRepo.GetFacePullsExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreateBackAndBicepsWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetPullUpsExcercise());
            excecises.Add(this.ExcercisesRepo.GetLatPulldownExcercise());
            excecises.Add(this.ExcercisesRepo.GetFacePullsExcercise());
            excecises.Add(this.ExcercisesRepo.GetBicepsCurlsExcercise());
            excecises.Add(this.ExcercisesRepo.GetHammerCurlsExcercise());

            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreateLegsWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetSquatsExcercise());
            excecises.Add(this.ExcercisesRepo.GetLegExtensionsExcercise());
            excecises.Add(this.ExcercisesRepo.GetLegPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetCrunchesExcercise());
            excecises.Add(this.ExcercisesRepo.GetLegRaisesExcercise());

            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreateMixedWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }

            excecises.Add(this.ExcercisesRepo.GetBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetPullUpsExcercise());
            excecises.Add(this.ExcercisesRepo.GetUpperDumbellBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetLatPulldownExcercise());
            excecises.Add(this.ExcercisesRepo.GetDipsExcercise());
            excecises.Add(this.ExcercisesRepo.GetBicepsCurlsExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }

        private Workout CreateUpperBodyWorkout(bool includeCardio)
        {
            List<Excercise> excecises = new List<Excercise>();
            if (includeCardio)
            {
                excecises.Add(this.ExcercisesRepo.GetTreadmillExcercise());
            }
            excecises.Add(this.ExcercisesRepo.GetBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetPullUpsExcercise());
            excecises.Add(this.ExcercisesRepo.GetShoulderPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetSeatedCableRow());
            excecises.Add(this.ExcercisesRepo.GetUpperDumbellBenchPressExcercise());
            excecises.Add(this.ExcercisesRepo.GetFacePullsExcercise());
            excecises.Add(this.ExcercisesRepo.GetBicepsCurlsExcercise());
            excecises.Add(this.ExcercisesRepo.GetDipsExcercise());


            Workout workout = new Workout()
            {
                Difficulty = this.Difficulty,
                Excercises = excecises.ToArray()
            };

            return workout;
        }
    }
}
