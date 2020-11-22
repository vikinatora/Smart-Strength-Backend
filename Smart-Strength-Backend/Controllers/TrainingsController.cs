using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;

namespace Smart_Strength_Backend.Controllers
{
    [ApiController]
    [Route("api/trainings")]
    public class TrainingsController : FirebaseController
    {
        public WorkoutsService WorkoutsService { get; private set; }

        public TrainingsController()
        {
            this.WorkoutsService = new WorkoutsService();
        }


        [HttpGet]
        [Route("create")]
        public TrainingProgram CreateTrainingRegime(Questionnaire questionnaire)
        {
            //Workout[] workouts = this.WorkoutsService.CreateWorkouts(questionnaire);
            //SetRegimeName(questionnaire, trainingProgram);
            var trainingProgram = new TrainingProgram()
            {
                Name = "Push/Pull/Legs with slow reps",
                Workouts = new Workout[]
                {
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Dumbell shoulder press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Incline dumbell press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Lateral raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Cable crossover",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                            new Excercise()
                            {
                                Name = "Triceps Pushdown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                        }
                    },
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Pull ups",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Seated cable rows",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Pulldown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Face pulls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Ez bar curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Hammer curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                        }
                    },
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Squats",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Romanian deadlift",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Leg press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Leg extensions",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Calf raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                        }
                    },
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Dumbell shoulder press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Incline dumbell press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Lateral raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Cable crossover",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                            new Excercise()
                            {
                                Name = "Triceps Pushdown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                        }
                    },
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Pull ups",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Seated cable rows",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Pulldown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Face pulls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Ez bar curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Hammer curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal"
                            },
                        }
                    },
                    new Workout()
                    {
                        Difficulty = 1,
                        Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Squats",
                                Reps = 8,
                                Sets = 4,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Romanian deadlift",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Leg press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Leg extensions",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                            new Excercise()
                            {
                                Name = "Calf raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "slow"
                            },
                        }
                    },
                }

            };
            return trainingProgram;
        }

        private static void SetRegimeName(Questionnaire questionnaire, TrainingProgram trainingProgram)
        {
            switch (questionnaire.FitnessGoal)
            {
                case "1":
                    switch (questionnaire.TrainingExperience)
                    {
                        case "1":
                            trainingProgram.Name = "Push/Pull/Legs with slow tempo";
                            break;
                        case "2":
                            trainingProgram.Name = "Push/Pull/Legs with normal tempo";
                            break;
                        case "3":
                            trainingProgram.Name = "Brosplit with slow reps";
                            break;
                        default:
                            break;
                    }
                    break;

                case "2":
                    switch (questionnaire.TrainingExperience)
                    {
                        case "1":
                            trainingProgram.Name = "Push/Pull/Legs with slow tempo";
                            break;
                        case "2":
                            trainingProgram.Name = "Push/Pull/Legs with normal tempo";
                            break;
                        case "3":
                            trainingProgram.Name = "Brosplit with slow reps";
                            break;
                        default:
                            break;
                    }
                    break;

                case "3":
                    switch (questionnaire.TrainingExperience)
                    {
                        case "1":
                            trainingProgram.Name = "Push/Pull/Legs with slow tempo";
                            break;
                        case "2":
                            trainingProgram.Name = "Push/Pull/Legs with normal tempo";
                            break;
                        case "3":
                            trainingProgram.Name = "Brosplit with slow reps";
                            break;
                        default:
                            break;
                    }
                    break;
                case "4":
                    switch (questionnaire.TrainingExperience)
                    {
                        case "1":
                            trainingProgram.Name = "Push/Pull/Legs with slow tempo";
                            break;
                        case "2":
                            trainingProgram.Name = "Push/Pull/Legs with normal tempo";
                            break;
                        case "3":
                            trainingProgram.Name = "Brosplit with slow reps";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
