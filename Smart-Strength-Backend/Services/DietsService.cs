using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class DietsService
    {
        public Diet CreateDiet()
        {
            return new Diet()
            {
                Goal = "Build muscle",
                Calories = 2600,
                Carbs = 240,
                Fat = 50,
                Protein = 50,
            };
        }
    }
}
