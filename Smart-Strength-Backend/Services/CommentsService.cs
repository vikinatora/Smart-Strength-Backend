using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class CommentsService:FirebaseService
    {
        public UsersService UsersService { get; private set; }
        public CommentsService()
        {
            this.UsersService = new UsersService();
        }

        public async Task<Comment[]> GetComments(object[] commentsIDs)
        {
            var comments = new List<Comment>();
            var commentsCollection = this.FirestoreDb.Collection("Comments");
            foreach (string id in commentsIDs)
            {
                var docSnapshot = await commentsCollection.Document(id).GetSnapshotAsync();
                Dictionary<string, object> docInfo = docSnapshot.ToDictionary();
                User author = await this.UsersService.GetUser(docInfo["author"].ToString());
                List<object> likes = (List<object>) docInfo["likes"];

                Comment comment = new Comment();
                comment.Author = author;
                comment.Content = docInfo["content"].ToString();
                comment.Likes = likes.Cast<string>().ToArray(); 

                comments.Add(comment);

            }

            return comments.ToArray();
        }
    }
}
