using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class FirebaseService
    {
        protected FirestoreDb FirestoreDb { get; set; }
        public FirebaseService()
        {
            this.FirestoreDb = FirestoreDb.Create("smart-strength");
        }

    }
}
