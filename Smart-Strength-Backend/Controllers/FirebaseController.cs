using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace Smart_Strength_Backend.Controllers
{
    public class FirebaseController : ControllerBase
    {
        protected FirestoreDb FirestoreDb { get; set; }
        public FirebaseController()
        {
            this.FirestoreDb = FirestoreDb.Create("smart-strength");
        }
    }
}
