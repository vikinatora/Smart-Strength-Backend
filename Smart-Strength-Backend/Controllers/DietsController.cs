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
    [Route("api/diets")]
    [ApiController]
    public class DietsController : FirebaseController
    {
        public DietsService DietsService { get; private set; }
        public DietsController()
        {
            this.DietsService = new DietsService();
        }

        [HttpPost]
        [Route("create")]
        public Diet CreateDiet(Questionnaire questionnaire) 
        {
            Diet diet = this.DietsService.CreateDiet();
            return diet;
        }
    }
}
