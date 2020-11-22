using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class TrainingService
    {
        public WorkoutsService WorkoutsService { get; private set; }
        public TrainingService()
        {
            this.WorkoutsService = new WorkoutsService();
        }

        public TrainingProgram CreateRegime(Questionnaire questionnaire)
        {
            TrainingProgram program = new TrainingProgram();
            Workout[] workout = this.WorkoutsService.CreateWorkouts(questionnaire);
            return program;
        } 
    }
}
