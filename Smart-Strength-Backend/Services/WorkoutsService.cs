using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class WorkoutsService
    {
        public Workout[] CreateWorkouts(Questionnaire questionnaire)
        {
            // Lose weight
            if (questionnaire.FitnessGoal == "1")
            {
                this.CreateWeightLossWorkout(questionnaire);
            }
            // Build muscle
            else if (questionnaire.FitnessGoal == "2")
            {
                this.CreateMuscleBuildingWorkout(questionnaire);
            }
            // Maintain
            else if (questionnaire.FitnessGoal == "3")
            {
                this.CreateMaintainingWorkout(questionnaire);
            }
            // Lose weight and build muscle
            else if (questionnaire.FitnessGoal == "4")
            {
                this.CreateWeightLossAndMuscleBuildingWorkout(questionnaire);
            }
            return new Workout[] { };
        }

        private void CreateWeightLossAndMuscleBuildingWorkout(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        private void CreateMaintainingWorkout(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        private void CreateMuscleBuildingWorkout(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        private void CreateWeightLossWorkout(Questionnaire questionnaire)
        {
            if (questionnaire.TrainingExperience == "1")
            {
                this.CreateBroSplitWorkout(questionnaire, true);
            }
            else if (questionnaire.TrainingExperience == "1" || questionnaire.TrainingExperience == "2")
            {
                this.CreatePPLWorkout(questionnaire, true);
            }
            else if (questionnaire.TrainingExperience == "4")
            {
                this.CreateULWorkout(questionnaire, true);
            }
        }

        private void CreateULWorkout(Questionnaire questionnaire, bool v)
        {
            throw new NotImplementedException();
        }

        private void CreatePPLWorkout(Questionnaire questionnaire, bool includeCardio)
        {
            throw new NotImplementedException();
        }

        private Workout[] CreateBroSplitWorkout(Questionnaire questionnaire, bool includeCardio)
        {
            List<Workout> workouts = new List<Workout>();
            string tempo = "";
            if (questionnaire.ProgressionRate == "1" || questionnaire.ProgressionRate == "2")
            {
                tempo = "normal";
            }
            else if (questionnaire.ProgressionRate == "3")
            {
                tempo = "slow";
            }
            else if (questionnaire.ProgressionRate == "4")
            {
                tempo = "very slow";
            }

            Workout chestAndTricepsWorkouCardio = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                       {
                            new Excercise()
                            {
                                Name = "Treadmill",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal pace"
                            },
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Shoulder press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Upper dumbell bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Triceps pushdown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
                       }
            };
            Workout backAndBicepsWorkoutCardio = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                {
                    new Excercise()
                    {
                        Name = "Treadmill",
                        Reps = 10,
                        Sets = 3,
                        Tempo = "normal pace"
                    },
                    new Excercise()
                    {
                        Name = "Pull ups",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Lat pulldown",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Face pulls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Bicep curls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Hammer curls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    }
                }
            };
            Workout legsWorkoutCardio = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Treadmill",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal pace"
                            },
                            new Excercise()
                            {
                                Name = "Squats",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg extensions",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Crunches",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
                        }
            };
            Workout mixedWorkout = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Pull ups",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Upper dumbell chest press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Lat pulldown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Bicep curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
                        }
            };
            Workout mixedWorkoutCardio = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
            {
                             new Excercise()
                            {
                                Name = "Treadmill",
                                Reps = 10,
                                Sets = 3,
                                Tempo = "normal pace"
                            },
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Pull ups",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Upper dumbell chest press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Lat pulldown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Bicep curls",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
            }
            };

            Workout chestAndTricepsWorkout = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                       {
                            new Excercise()
                            {
                                Name = "Bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Shoulder press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Upper dumbell bench press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Dips",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Triceps pushdown",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
                       }
            };
            Workout backAndBicepsWorkous = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                {
                    new Excercise()
                    {
                        Name = "Pull ups",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Lat pulldown",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Face pulls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Bicep curls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    },
                    new Excercise()
                    {
                        Name = "Hammer curls",
                        Reps = 10,
                        Sets = 3,
                        Tempo = tempo
                    }
                }
            };
            Workout legsWorkout = new Workout()
            {
                Difficulty = int.Parse(questionnaire.TrainingExperience),
                Excercises = new Excercise[]
                        {
                            new Excercise()
                            {
                                Name = "Squats",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg extensions",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg press",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Crunches",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            },
                            new Excercise()
                            {
                                Name = "Leg raises",
                                Reps = 10,
                                Sets = 3,
                                Tempo = tempo
                            }
                        }
            };

            switch (questionnaire.WorkoutsPerWeek)
            {
                case "3":
                    if (includeCardio)
                    {
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);
                        workouts.Add(legsWorkoutCardio);
                    }
                    else
                    {
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                        workouts.Add(legsWorkout);

                    }
                    break;

                case "4":
                    if (includeCardio)
                    {
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);
                        workouts.Add(legsWorkoutCardio);
                        workouts.Add(mixedWorkoutCardio);
                    }
                    else
                    {
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                        workouts.Add(legsWorkout);
                        workouts.Add(mixedWorkout);

                    }
                    break;

                case "5":
                    if (includeCardio)
                    {
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);
                        workouts.Add(legsWorkoutCardio);
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);

                    }
                    else
                    {
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                        workouts.Add(legsWorkout);
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                    }
                    break;

                case "6":
                    if (includeCardio)
                    {
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);
                        workouts.Add(legsWorkoutCardio);
                        workouts.Add(chestAndTricepsWorkouCardio);
                        workouts.Add(backAndBicepsWorkoutCardio);
                        workouts.Add(mixedWorkoutCardio);

                    }
                    else
                    {
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                        workouts.Add(legsWorkout);
                        workouts.Add(chestAndTricepsWorkout);
                        workouts.Add(backAndBicepsWorkous);
                        workouts.Add(mixedWorkout);
                    }
                    break;
            }

            return workouts.ToArray();
        }
    }
}
