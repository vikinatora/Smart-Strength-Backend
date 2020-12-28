using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Smart_Strength_Backend.Tests
{
    public class WorkoutsServiceTests
    {
        public IExcercisesRepo ExcercisesRepo { get; }
        public IWorkoutsService WorkoutsService { get; }
        public WorkoutsServiceTests()
        {
            this.ExcercisesRepo = new ExcercisesRepo();
            this.WorkoutsService = new WorkoutsService(this.ExcercisesRepo);
        }

        [Fact]
        public void AssertWorkoutsServiceInheritsInterface()
        {
            Assert.IsAssignableFrom<IWorkoutsService>(this.WorkoutsService);
        }

        [Fact]
        public void CreateULProgramReturnsCorrectNumberOfExcercisesWithoutCardio()
        {
            bool includeCardio = false;

            Workout[] workouts = this.WorkoutsService.CreateULTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);

        }

        [Fact]
        public void CreateULProgramReturnsCorrectNumberOfExcercisesWitCardio()
        {
            bool includeCardio = true;
            Workout[] workouts = this.WorkoutsService.CreateULTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreateULTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);
        }

        [Fact]
        public void CreatePPLProgramReturnsCorrectNumberOfExcercisesWitCardio()
        {
            bool includeCardio = true;
            Workout[] workouts = this.WorkoutsService.CreatePPLTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);
        }

        [Fact]
        public void CreatePPLProgramReturnsCorrectNumberOfExcercisesWithoutCardio()
        {
            bool includeCardio = false;
            Workout[] workouts = this.WorkoutsService.CreatePPLTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreatePPLTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);
        }

        [Fact]
        public void CreateFullBodyProgramReturnsCorrectNumberOfExcercisesWithoutCardio()
        {
            bool includeCardio = false;
            Workout[] workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);
        }
        [Fact]
        public void CreateFullBodyProgramReturnsCorrectNumberOfExcercisesWithCardio()
        {
            bool includeCardio = true;
            Workout[] workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("3", includeCardio);
            Assert.Equal(3, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("4", includeCardio);
            Assert.Equal(4, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("5", includeCardio);
            Assert.Equal(5, workouts.Length);

            workouts = this.WorkoutsService.CreateFulLBodyTrainingRegime("6", includeCardio);
            Assert.Equal(6, workouts.Length);
        }


        [Fact]
        public void CreatePullWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreatePullWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreatePullWorkoutDoesntIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreatePullWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreatePushWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreatePushWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreatePushWorkoutDoesntIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreatePushWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateChestTricepsWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateChestAndTricepsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateChestTricepsWorkoutIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateChestAndTricepsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateBackBicepsWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateBackAndBicepsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateBackBicepsWorkoutIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateBackAndBicepsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateShoulderWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateShoulderWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateShoulderWorkoutIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateShoulderWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateLegsWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateLegsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateLegsWorkoutDoesntIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateLegsWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateMixedWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateMixedWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateMixedWorkoutDoesntIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateMixedWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateUpperBodyWorkoutIncludesCardio()
        {
            bool includeCardio = true;
            Workout workout = this.WorkoutsService.CreateUpperBodyWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name == this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateUpperBodyWorkoutDoesntIncludeCardio()
        {
            bool includeCardio = false;
            Workout workout = this.WorkoutsService.CreateUpperBodyWorkout(includeCardio);

            Assert.Contains(workout.Excercises, e => e.Name != this.ExcercisesRepo.GetTreadmillExcercise().Name);
        }

        [Fact]
        public void CreateRegimeNameSetsCorrectTempo()
        {
            string name = this.WorkoutsService.CreateRegimeName("1", "1");
            Assert.Contains("fast tempo", name);

            name = this.WorkoutsService.CreateRegimeName("1", "2");
            Assert.Contains("normal tempo", name);

            name = this.WorkoutsService.CreateRegimeName("1", "3");
            Assert.Contains("normal tempo", name);

            name = this.WorkoutsService.CreateRegimeName("1", "4");
            Assert.Contains("slow tempo", name);
        }

        [Fact]
        public void CreateRegimeNameSetsCorrectWorkoutNameLosingWeight()
        {
            string name = this.WorkoutsService.CreateRegimeName("1", "1");
            Assert.Contains("Full body", name);

            name = this.WorkoutsService.CreateRegimeName("2", "1");
            Assert.Contains("Push/Pull/Legs", name);

            name = this.WorkoutsService.CreateRegimeName("3", "1");
            Assert.Contains("Upper/Lower", name);
        }

        [Fact]
        public void CreateRegimeNameSetsCorrectWorkoutNameBuildingMuscle()
        {
            string name = this.WorkoutsService.CreateRegimeName("1", "2");
            Assert.Contains("Full body", name);

            name = this.WorkoutsService.CreateRegimeName("2", "2");
            Assert.Contains("Push/Pull/Legs", name);

            name = this.WorkoutsService.CreateRegimeName("3", "2");
            Assert.Contains("Upper/Lower", name);
        }
        [Fact]
        public void CreateRegimeNameSetsCorrectWorkoutNameMaintainWeight()
        {
            string name = this.WorkoutsService.CreateRegimeName("1", "3");
            Assert.Contains("Full body", name);

            name = this.WorkoutsService.CreateRegimeName("2", "3");
            Assert.Contains("Push/Pull/Legs", name);

            name = this.WorkoutsService.CreateRegimeName("3", "3");
            Assert.Contains("Upper/Lower", name);
        }

        [Fact]
        public void CreateRegimeNameSetsCorrectWorkoutNameBuildMuscleLoseWeight()
        {
            string name = this.WorkoutsService.CreateRegimeName("1", "4");
            Assert.Contains("Full body", name);

            name = this.WorkoutsService.CreateRegimeName("2", "4");
            Assert.Contains("Push/Pull/Legs", name);

            name = this.WorkoutsService.CreateRegimeName("3", "4");
            Assert.Contains("Upper/Lower", name);
        }

    }
}
