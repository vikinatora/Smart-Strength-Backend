using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class PostsService:FirebaseService
    {
        public UsersService UsersService { get; private set; }
        public CommentsService CommentsService { get; private set; }

        public PostsService()
        {
            this.UsersService = new UsersService();
            this.CommentsService = new CommentsService();
        }

        public async Task<Post[]> GetPosts()
        {
            List<Post> posts = new List<Post>();
            CollectionReference excercisesRef = this.FirestoreDb.Collection("Posts");
            QuerySnapshot snapshot = await excercisesRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                string content = documentDictionary["content"].ToString();
                string authorId = documentDictionary["author"].ToString();
                User author = await this.UsersService.GetUser(authorId);
                List<object> commentsIds = (List<object>)documentDictionary["comments"];
                Comment[] commentsArray = await this.CommentsService.GetComments(commentsIds.ToArray());
                string[] likes = ((List<object>)documentDictionary["likes"]).Cast<string>().ToArray();

                var post = new Post();
                post.Author = author;
                post.Comments = commentsArray;
                post.Content = content;
                post.Likes = likes;
                posts.Add(post);
            }
            return posts.ToArray();

        }
    }
}
