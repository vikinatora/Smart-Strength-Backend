using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class UsersService: FirebaseService, IUsersService
    {
        public ITrainingsService TrainingsService { get; private set; }

        public UsersService(ITrainingsService trainingsService)
        {
            this.TrainingsService = trainingsService;
        }

        public async Task<string> CreateUser(string fullName, string fbToken)
        {
            CollectionReference usersRef = this.FirestoreDb.Collection("Users");
            QuerySnapshot existingUsers = await usersRef.WhereEqualTo("fb_token", fbToken).GetSnapshotAsync();

            if (existingUsers.Documents.Count > 0)
            {
                return existingUsers[0].Id;
            }

            Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "fullName", fullName },
                    { "fb_token", fbToken },
                };
            DocumentReference writeResult = await usersRef.AddAsync(user);
            return writeResult.Id;

        }

        public async Task<string> GetIdFromToken(string fbToken)
        {
            CollectionReference usersRef = this.FirestoreDb.Collection("Users");
            QuerySnapshot existingUsers = await usersRef.WhereEqualTo("fb_token", fbToken).GetSnapshotAsync();

            if (existingUsers.Documents.Count > 0)
            {
                return existingUsers[0].Id;
            }

            return "";
        }

        public async Task<bool> AddTrainingProgramToUser(TrainingProgram trainingProgram, string userId)
        {
            try
            {
                string trProgramId = await this.TrainingsService.CreateTrainingProgram(trainingProgram);

                DocumentReference user = this.FirestoreDb.Collection("Users").Document(userId);
                var userSnapshot =  await user.GetSnapshotAsync();

                if (userSnapshot.Exists)
                {
                    Dictionary<string, object> trProgram = new Dictionary<string, object>
                    {
                        { "trainingProgram", trProgramId },
                    };
                    WriteResult writeResult = await user.UpdateAsync(trProgram);
                    return true;

                }

                return false;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<User> GetUser(string userId)
        {
            User user = new User();

            var docRef = this.FirestoreDb.Collection("Users").Document(userId);
            var docSnapshot = await docRef.GetSnapshotAsync();
            if(docSnapshot.Exists)
            {
                Dictionary<string, object> docDict = docSnapshot.ToDictionary();
                user.Id = userId;
                user.Name = docDict["fullName"].ToString();
            }

            return user;
        }
    }
}
