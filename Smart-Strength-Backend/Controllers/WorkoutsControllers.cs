using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Smart_Strength_Backend.Controllers
{
    [Route("api/workouts")]
    [ApiController]



    public class WorkoutsControllers : ControllerBase
	{
		public WorkoutService WorkoutService { get; private set; }

        public WorkoutsControllers()
        {
            this.WorkoutService = new WorkoutService();
        }


        [HttpPost]
        [Route("create")]
        public async Task<Workout> CreateWorkout(string userId, int difficlity, int excercises, string type)
        {
            try
            {
                Workout workout = this.WorkoutService.WorkoutService(difficlity, excercises, type);
                await this.WorkoutService.AddWorkoutToUser(workout, userId);
                return workout;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}