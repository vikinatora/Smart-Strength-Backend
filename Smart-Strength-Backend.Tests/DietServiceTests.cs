using Smart_Strength_Backend.Services;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using Xunit;

namespace Smart_Strength_Backend.Tests
{
    public class DietServiceTests
    {
        public DietsService DietsService { get; }

        public DietServiceTests()
        {
            this.DietsService = new DietsService(false);
        }

        [Fact]
        public void CalculatesBMRCorrectlyMale()
        {
            int age = 21;
            double weight = 75.5;
            string gender = "male";
            int height = 180;

            double calories = this.DietsService.CalcualteBMR(gender, weight, height, age);

            Assert.Equal(1780, calories);
        }

        [Fact]
        public void CalculatesBMRCorrectlyFemale()
        {
            int age = 25;
            double weight = 60;
            string gender = "female";
            int height = 172;

            double calories = this.DietsService.CalcualteBMR(gender, weight, height, age);

            Assert.Equal(1389, calories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightWithProgressionRate1()
        {
            int fitnessGoal = 1;
            string progressionRate = "1";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(1700, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightWithProgressionRate2()
        {
            int fitnessGoal = 1;
            string progressionRate = "2";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(1600, newCalories);
        }
        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightWithProgressionRate3()
        {
            int fitnessGoal = 1;
            string progressionRate = "3";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(1500, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForGainingWeightWithProgressionRate1()
        {
            int fitnessGoal = 2;
            string progressionRate = "1";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2300, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForGainingWeightWithProgressionRate2()
        {
            int fitnessGoal = 2;
            string progressionRate = "2";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2400, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForGainingWeightWithProgressionRate3()
        {
            int fitnessGoal = 2;
            string progressionRate = "3";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2500, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForMaintainingWeightWithProgressionRate1()
        {
            int fitnessGoal = 3;
            string progressionRate = "1";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2000, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForMaintainingWeightWithProgressionRate2()
        {
            int fitnessGoal = 3;
            string progressionRate = "2";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2000, newCalories);
        }

        [Fact]
        public void ModifiesBMRCorrectlyForMaintainingWeightWithProgressionRate3()
        {
            int fitnessGoal = 3;
            string progressionRate = "3";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2000, newCalories);
        }
        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightAndGainingMuscleWithProgressionRate1()
        {
            int fitnessGoal = 4;
            string progressionRate = "1";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2300, newCalories);
        }
        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightAndGainingMuscleWithProgressionRate2()
        {
            int fitnessGoal = 4;
            string progressionRate = "2";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2400, newCalories);
        }
        [Fact]
        public void ModifiesBMRCorrectlyForLosingWeightAndGainingMuscleWithProgressionRate3()
        {
            int fitnessGoal = 4;
            string progressionRate = "3";
            double calories = 2000;
            double newCalories = this.DietsService.GetCaloriesFromGoal(fitnessGoal, progressionRate, calories);

            Assert.Equal(2500, newCalories);
        }

        [Fact]
        public void CalculatesMacrosForLosingWeightCorrectly()
        {
            int weight = 80;
            double calories = 2000;
            double proteinCoef = 1.9;
            double fatCoef = 0.8;

            double protein = 0;
            double carbs = 0;
            double fats = 0;
            this.DietsService.CalculateProteinFatsCarbs(weight, calories, proteinCoef, fatCoef, out protein, out fats, out carbs);
            
            Assert.Equal(152, protein);
            Assert.Equal(64, fats);
            Assert.Equal(204, carbs);
        }

        [Fact]
        public void CalculatesMacrosForBuildingMuscleCorrectly()
        {
            int weight = 80;
            double calories = 2000;
            double proteinCoef = 1.6;
            double fatCoef = 1;

            double protein = 0;
            double carbs = 0;
            double fats = 0;

            this.DietsService.CalculateProteinFatsCarbs(weight, calories, proteinCoef, fatCoef, out protein, out fats, out carbs);

            Assert.Equal(128, protein);
            Assert.Equal(80, fats);
            Assert.Equal(192, carbs);
        }

        [Fact]
        public void CalculatesMacrosForMaintainingWeightCorrectly()
        {
            int weight = 80;
            double calories = 2000;
            double proteinCoef = 1.7;
            double fatCoef = 0.9;

            double protein = 0;
            double carbs = 0;
            double fats = 0;
            this.DietsService.CalculateProteinFatsCarbs(weight, calories, proteinCoef, fatCoef, out protein, out fats, out carbs);

            Assert.Equal(136, protein);
            Assert.Equal(72, fats);
            Assert.Equal(202, carbs);
        }

    }
}
