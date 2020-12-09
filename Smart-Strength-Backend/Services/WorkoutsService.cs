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

        public WorkoutsService(ExcercisesRepo excercisesRepo)
        {
            this.ExcercisesRepo = excercisesRepo;
        }

        public Workout[] CreateWorkouts(string fitnessGoal, string trainingExperience, string workoutsPerWeek)
        {
            Workout[] program = null;

            // Lose weight || Build muscle and lose weiУght
            if (fitnessGoal == "1" || fitnessGoal == "3")
            {
                if (trainingExperience == "1")
                {
                    program = this.CreateFulLBodyTrainingRegime(workoutsPerWeek, true);
                }
                else if (trainingExperience == "2" || trainingExperience == "3")
                {
                    program = this.CreatePPLTrainingRegime(workoutsPerWeek, true);
                }
                else
                {
                    program = this.CreateULTrainingRegime(workoutsPerWeek, true);
                }
            }
            // Build muscle || Maintain
            else if (fitnessGoal == "2" || fitnessGoal == "4")
            {
                if (trainingExperience == "1")
                {
                    program = this.CreateFulLBodyTrainingRegime(workoutsPerWeek, false);
                }
                else if (trainingExperience == "2" || trainingExperience == "3")
                {
                    program = this.CreatePPLTrainingRegime(workoutsPerWeek, false);
                }
                else
                {
                    program = this.CreateULTrainingRegime(workoutsPerWeek, false);
                }
            }
            if (program.Length == 3)
            {
                program[0].Day = "Monday";
                program[1].Day = "Wednesday";
                program[2].Day = "Friday";
            }

            if (program.Length == 4)
            {
                program[0].Day = "Monday";
                program[1].Day = "Tuesday";
                program[2].Day = "Thursday";
                program[3].Day = "Friday";
            }

            if (program.Length == 5)
            {
                program[0].Day = "Monday";
                program[1].Day = "Tuesday";
                program[2].Day = "Wednesday";
                program[3].Day = "Friday";
                program[4].Day = "Saturday";
            }

            if (program.Length == 6)
            {
                program[0].Day = "Monday";
                program[1].Day = "Tuesday";
                program[2].Day = "Wednesday";
                program[3].Day = "Friday";
                program[4].Day = "Saturday";
                program[5].Day = "Sunday";
            }
            return program;
        }

        private Workout[] CreateULTrainingRegime(string workoutsPerWeek, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();

            switch (workoutsPerWeek)
            {
                case "3":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    break;

                case "4":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    break;

                case "5":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    break;

                case "6":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    break;
            }

            return workouts.ToArray();
        }

        private Workout[] CreatePPLTrainingRegime(string workoutsPerWeek, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();
            switch (workoutsPerWeek)
            {
                case "3":
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    break;

                case "4":
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreatePushWorkout(includeCardio));
                    break;

                case "5":
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    break;

                case "6":
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreatePushWorkout(includeCardio));
                    workouts.Add(CreatePullWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    break;
            }
            var workoutArray = workouts.ToArray();
            return workoutArray;
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

        private Workout[] CreateFulLBodyTrainingRegime(string workoutsPerWeek, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();
            for (int i = 0; i < int.Parse(workoutsPerWeek); i++)
            {
                workouts.Add(CreateMixedWorkout(includeCardio));
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
