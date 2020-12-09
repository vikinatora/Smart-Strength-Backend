using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class DietsService : FirebaseService
    {
        public Diet CreateDiet(string gender, double weight, int height, int fitnessGoal, int age, string progressionRate)
        {
            Diet diet = new Diet();
            double calories = CalcualteBMR(gender, weight, height, age);
            calories = GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);
            double protein = 0;
            double fats = 0;
            double carbs = 0;
            string dietName = "";

            if (fitnessGoal == 2 || fitnessGoal == 4)
            {
                dietName = fitnessGoal == 2 ? "Diet for building muscle" : "Diet for building muscle and losing weight";
                calcualteProteinFatsCars(weight, calories, 1.6, 1, out protein, out fats, out carbs);
            }
            else if (fitnessGoal == 1)
            {
                dietName = "Diet for losing weight";
                calcualteProteinFatsCars(weight, calories, 1.9, 0.8, out protein, out fats, out carbs);
            }
            else
            {
                dietName = "Diet for maintaining weight";
                calcualteProteinFatsCars(weight, calories, 1.7, 0.9, out protein, out fats, out carbs);
            }
            return new Diet()
            {
                Goal = dietName,
                Calories = Convert.ToInt32(calories),
                Carbs = Convert.ToInt32(carbs),
                Fat = Convert.ToInt32(fats),
                Protein = Convert.ToInt32(protein)
            };
        }

        private static double calcualteProteinFatsCars(double weight, double calories, double proteinCoeficient, double fatCoeficient, out double protein, out double fats, out double carbs)
        {
            protein = proteinCoeficient * weight;
            fats = fatCoeficient * weight;
            double proteinCalories = protein * 4;
            double fatCalories = fats * 9;
            double carbsCalories = calories - proteinCalories - fatCalories;
            carbs = carbsCalories / 4;

            return calories;
        }

        private static double GetCaloriesFromGoal(int fitnessGoal, string progressionRate, double calories)
        {
            double caloriesChange = 0;
            if (progressionRate == "1")
            {
                caloriesChange = 0.15;
            }
            else if (progressionRate == "2")
            {
                caloriesChange = 0.20;
            }
            else
            {
                caloriesChange = 0.25;
            }
            // Build muscle
            if (fitnessGoal == 2 || fitnessGoal == 4)
            {
                calories = calories + calories * caloriesChange;
            }
            else if (fitnessGoal == 1)
            {
                calories = calories - calories * caloriesChange;
            }

            return calories;
        }

        private static double CalcualteBMR(string gender, double weight, int height, int age)
        {
            double calories = 10 * weight + 6.25 * height - 5 * age;
            if (gender == "male")
            {
                calories += 5;
            }
            else if (gender == "female")
            {
                calories -= 161;
            }

            return calories;
        }
        public async Task<bool> AddDietToUser(Diet diet, string userId)
        {
            var dietCollection = this.FirestoreDb.Collection("Diets");
            var dietObj = new Dictionary<string, object>
            {
                { "calories", diet.Calories },
                { "protein", diet.Protein },
                { "carbs", diet.Carbs },
                { "protein", diet.Protein },
                { "name", diet.Goal }
            };
            var result = dietCollection.AddAsync(dietObj);

            var user = this.FirestoreDb.Collection("Users").Document(userId);
            var userSnapshot = await user.GetSnapshotAsync();
            if (userSnapshot.Exists)
            {
                var userObj = new Dictionary<string, object>
                {
                    { "diet", result.Id }
                };

                await user.SetAsync(userObj);
                return true;
            }
            return false;
        }

    }



}
