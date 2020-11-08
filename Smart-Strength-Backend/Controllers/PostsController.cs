using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;

namespace Smart_Strength_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : FirebaseController
    {
        [HttpGet]
        public async Task<Comment> Get()
        {
            CollectionReference excercisesRef = this.FirestoreDb.Collection("Excercises");
            QuerySnapshot snapshot = await excercisesRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                Console.WriteLine($"Document id: {document.Id}");
                Console.WriteLine($"Document reps: {documentDictionary["reps"]}");
                Console.WriteLine($"Document sets: {documentDictionary["sets"]}");
                Console.WriteLine($"Document tempo: {documentDictionary["tempo"]}");
            }
            return null;
        }
    }
}
