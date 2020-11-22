using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class WorkoutsService
    {
        public Workout[] CreateWorkouts (Questionnaire questionnaire)
        {
            // Lose weight
            if (questionnaire.FitnessGoal == "1")
            {
            } 
            // Build muscle
            else if(questionnaire.FitnessGoal == "2")
            {

            }
            // Maintain
            else if (questionnaire.FitnessGoal == "3")
            {

            }
            // Lose weight and build muscle
            else if (questionnaire.FitnessGoal == "4")
            {

            }
            return new Workout[] { };
        }
    }
}
