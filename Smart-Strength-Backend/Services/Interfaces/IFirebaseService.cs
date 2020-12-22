using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IFirebaseService
    {
        public FirestoreDb FirestoreDb { get; set; }
    }
}
