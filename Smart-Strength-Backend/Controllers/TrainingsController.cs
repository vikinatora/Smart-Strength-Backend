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

        [HttpPost]
        [Route("create")]
        public TrainingProgram CreateTrainingRegime(Questionnaire questionnaire)
        {
            ExcercisesRepo excercisesRepo = new ExcercisesRepo(questionnaire.ProgressionRate, questionnaire.TrainingExperience, questionnaire.FitnessGoal);
            WorkoutsService workoutsService = new WorkoutsService(questionnaire, excercisesRepo);
            Workout[] workouts = workoutsService.CreateWorkouts(questionnaire);
            TrainingProgram trainingProgram = new TrainingProgram();

            trainingProgram.Workouts = workouts;
            trainingProgram.Name = CreateRegimeName(questionnaire.TrainingExperience, questionnaire.FitnessGoal);
            
            return trainingProgram;
        }

        private string CreateRegimeName(string trainingExperience, string fitnessGoal)
        {
            switch (fitnessGoal)
            {
                case "1":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Push/Pull/Legs with slow tempo";
                        case "2":
                            return "Push/Pull/Legs with normal tempo";
                        case "3":
                            return "Full body with slow reps";
                        default:
                            break;
                    }
                    break;

                case "2":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Push/Pull/Legs with slow tempo";
                        case "2":
                            return "Push/Pull/Legs with normal tempo";
                        case "3":
                            return "Full body with slow reps";
                        default:
                            break;
                    }
                    break;

                case "3":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Push/Pull/Legs with slow tempo";
                           
                        case "2":
                            return "Push/Pull/Legs with normal tempo";
                          
                        case "3":
                            return "Full body with slow reps";
                           
                        default:
                            break;
                    }
                    break;
                case "4":
                    switch (trainingExperience)
                    {
                        case "1":
                            return "Push/Pull/Legs with slow tempo";
                          
                        case "2":
                            return "Push/Pull/Legs with normal tempo";
              
                        case "3":
                            return "Full body with slow reps";

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
