using Google.Cloud.Firestore;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class FirebaseService: IFirebaseService
    {
        public FirestoreDb FirestoreDb { get; set; }
        public FirebaseService()
        {
            this.FirestoreDb = FirestoreDb.Create("smart-strength");
        }

    }
}
