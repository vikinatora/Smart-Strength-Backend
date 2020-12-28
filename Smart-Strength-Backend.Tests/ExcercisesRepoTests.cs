using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Smart_Strength_Backend.Tests
{
    public class ExcercisesRepoTests
    {
        public ExcercisesRepo ExcercisesRepo { get; }

        public ExcercisesRepoTests()
        {
            this.ExcercisesRepo = new ExcercisesRepo();
        }

        [Fact]
        public void ServiceInheritsInterface()
        {
            Assert.IsAssignableFrom<IExcercisesRepo>(this.ExcercisesRepo);
        }

        [Fact]
        public void CardioTempoIsSetCorrectlySlowPace()
        {
            this.ExcercisesRepo.SetCardioTempo(1);
            Assert.Equal("slow pace", this.ExcercisesRepo.CardioTempo);

            this.ExcercisesRepo.SetCardioTempo(2);
            Assert.Equal("slow pace", this.ExcercisesRepo.CardioTempo);
        }

        [Fact]
        public void CardioTempoIsSetCorrectlyNormalPace()
        {
            this.ExcercisesRepo.SetCardioTempo(3);
            Assert.Equal("normal pace", this.ExcercisesRepo.CardioTempo);
        }

        [Fact]
        public void CardioTempoIsSetCorrectlyFastPace()
        {
            this.ExcercisesRepo.SetCardioTempo(4);
            Assert.Equal("fast pace", this.ExcercisesRepo.CardioTempo);
        }

        [Fact]
        public void TempoIsSetCorrectlyNormalTempo()
        {
            this.ExcercisesRepo.SetTempo("1");
            Assert.Equal("normal", this.ExcercisesRepo.Tempo);

            this.ExcercisesRepo.SetTempo("2");
            Assert.Equal("normal", this.ExcercisesRepo.Tempo);
        }

        [Fact]
        public void TempoIsSetCorrectlySlowTempo()
        {
            this.ExcercisesRepo.SetTempo("3");
            Assert.Equal("slow", this.ExcercisesRepo.Tempo);
        }

        [Fact]
        public void TempoIsSetCorrectlyVerySlowTempo()
        {
            this.ExcercisesRepo.SetTempo("4");
            Assert.Equal("very slow", this.ExcercisesRepo.Tempo);
        }

        [Fact]
        public void RepsAreSetCorrectlyLoseWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("1");
            Assert.Equal(10, this.ExcercisesRepo.Reps );
        }

        [Fact]
        public void RepsAreSetCorrectlyMaintainWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("2");
            Assert.Equal(12, this.ExcercisesRepo.Reps);
        }

        [Fact]
        public void RepsAreSetCorrectlyBuildMuscle()
        {
            this.ExcercisesRepo.SetRepsAndSets("3");
            Assert.Equal(8, this.ExcercisesRepo.Reps);
        }

        [Fact]
        public void RepsAreSetCorrectlyBuildMuscleLoseWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("4");
            Assert.Equal(12, this.ExcercisesRepo.Reps);
        }

        [Fact]
        public void SetsAreSetCorrectlyLoseWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("1");
            Assert.Equal(4, this.ExcercisesRepo.Sets);
        }

        [Fact]
        public void SetsAreSetCorrectlyMaintainWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("2");
            Assert.Equal(3, this.ExcercisesRepo.Sets);
        }

        [Fact]
        public void SetsAreSetCorrectlyBuildMuscle()
        {
            this.ExcercisesRepo.SetRepsAndSets("3");
            Assert.Equal(3, this.ExcercisesRepo.Sets);
        }

        [Fact]
        public void SetsAreSetCorrectlyBuildMuscleLoseWeight()
        {
            this.ExcercisesRepo.SetRepsAndSets("4");
            Assert.Equal(3, this.ExcercisesRepo.Sets);
        }

        [Fact]
        public void CreateExcerciseSetsNameCorrectly()
        {
            string excerciseName = "BenchPres1235!#@#!@";
            this.ExcercisesRepo.Init("1", "1", "1");
            Excercise excercise = this.ExcercisesRepo.CreateExcercise(excerciseName);
            Assert.Equal(excerciseName, excercise.Name);
        }
    }
}
