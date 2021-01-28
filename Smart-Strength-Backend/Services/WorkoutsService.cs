using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class WorkoutsService: IWorkoutsService
    {
        public string Tempo { get; set; }
        public int Difficulty { get; set; }
        public IExcercisesRepo ExcercisesRepo { get; set; }

        public WorkoutsService(IExcercisesRepo excercisesRepo)
        {
            this.ExcercisesRepo = excercisesRepo;
        }

        public TrainingProgram CreateWorkouts(string fitnessGoal, string trainingExperience, string workoutsPerWeek)
        {
            Workout[] workouts = null;
            bool includeCardio = false;
            TrainingProgram trainingProgram = new TrainingProgram();
            // Lose weight || Build muscle and lose weight
            if (fitnessGoal == "1" || fitnessGoal == "3")
            {
                includeCardio = true;
            }

            switch (trainingExperience)
            {
                case "1":
                    workouts = this.CreateFulLBodyTrainingRegime(workoutsPerWeek, includeCardio);
                    break;
                case "2":
                    workouts = this.CreatePPLTrainingRegime(workoutsPerWeek, includeCardio);
                    break;
                case "3":
                    workouts = this.CreateULTrainingRegime(workoutsPerWeek, includeCardio);
                    break;
                default:
                    workouts = this.CreateULTrainingRegime(workoutsPerWeek, includeCardio);
                    break;
            }
            trainingProgram.Workouts = workouts;
            trainingProgram.Name = CreateRegimeName(trainingExperience, fitnessGoal);

            if (workouts.Length == 3)
            {
                workouts[0].Day = "Monday";
                workouts[1].Day = "Wednesday";
                workouts[2].Day = "Friday";
            }

            if (workouts.Length == 4)
            {
                workouts[0].Day = "Monday";
                workouts[1].Day = "Tuesday";
                workouts[2].Day = "Thursday";
                workouts[3].Day = "Friday";
            }

            if (workouts.Length == 5)
            {
                workouts[0].Day = "Monday";
                workouts[1].Day = "Tuesday";
                workouts[2].Day = "Wednesday";
                workouts[3].Day = "Friday";
                workouts[4].Day = "Saturday";
            }

            if (workouts.Length == 6)
            {
                workouts[0].Day = "Monday";
                workouts[1].Day = "Tuesday";
                workouts[2].Day = "Wednesday";
                workouts[3].Day = "Friday";
                workouts[4].Day = "Saturday";
                workouts[5].Day = "Sunday";
            }


            return trainingProgram;
        }

        public Workout[] CreateULTrainingRegime(string workoutsPerWeek, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();

            switch (workoutsPerWeek)
            {
                case "3":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    break;
                case "4":
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
                    workouts.Add(CreateUpperBodyWorkout(includeCardio));
                    workouts.Add(CreateLegsWorkout(includeCardio));
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

        public Workout[] CreatePPLTrainingRegime(string workoutsPerWeek, bool includeCardio)
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
            Workout[] workoutArray = workouts.ToArray();
            return workoutArray;
        }

        public Workout CreatePullWorkout(bool includeCardio)
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

        public Workout CreatePushWorkout(bool includeCardio)
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

        public Workout[] CreateFulLBodyTrainingRegime(string workoutsPerWeek, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();
            for (int i = 0; i < int.Parse(workoutsPerWeek); i++)
            {
                workouts.Add(CreateMixedWorkout(includeCardio));
            }

            return workouts.ToArray();
        }

        public Workout CreateChestAndTricepsWorkout(bool includeCardio)
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

        public Workout CreateShoulderWorkout(bool includeCardio)
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

        public Workout CreateBackAndBicepsWorkout(bool includeCardio)
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

        public Workout CreateLegsWorkout(bool includeCardio)
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

        public Workout CreateMixedWorkout(bool includeCardio)
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

        public Workout CreateUpperBodyWorkout(bool includeCardio)
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

        public string CreateRegimeName(string trainingExperience, string fitnessGoal)
        {
            switch (fitnessGoal)
            {
                case "1":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Full body with fast tempo";
                        case "2":
                            return "Push/Pull/Legs with fast tempo";
                        case "3":
                            return "Upper/Lower split with fast tempo";
                        default:
                            break;
                    }
                    break;
                case "2":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Full body with normal tempo";
                        case "2":
                            return "Push/Pull/Legs with normal tempo";
                        case "3":
                            return "Upper/Lower with normal tempo";
                        default:
                            break;
                    }
                    break;
                case "3":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Full body with normal tempo";

                        case "2":
                            return "Push/Pull/Legs with normal tempo";

                        case "3":
                            return "Upper/Lower with normal tempo";
                        default:
                            break;
                    }
                    break;
                case "4":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Full body with slow tempo";

                        case "2":
                            return "Push/Pull/Legs with slow tempo";

                        case "3":
                            return "Upper/Lower with slow tempo";
                        default:
                            break;
                    }
                    break;
                default:
                    break;

            }
            return null;

        }
    }
}
