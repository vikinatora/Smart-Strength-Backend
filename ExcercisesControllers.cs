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
	public class ExcercisesControllers : ControllerBase
	{
		[Route("api/excercises")]
		[ApiController]

		public ExcercisesService ExcercisesService { get; private set; }

		public ExcercisesControllers()
		{
			this.ExcercisesService = new ExcercisesService();
		}

        [HttpPost]
        [Route("create")]
        public async Task<Excercise> CreateExcercise(string userId, int sets, int reps, string tempo)
        {
            try
            {
                Excercise excercise = this.ExcercisesService.ExcercisesService(sets, reps, tempo);
                await this.ExcercisesService.AddExcerciseToUser(excercise, userId);
                return excercise;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}