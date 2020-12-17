using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class PostsService : FirebaseService
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
            Query excercisesRef = this.FirestoreDb.Collection("Posts").OrderByDescending("created")
;
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
                string created = documentDictionary["created"].ToString();
                string achievement = documentDictionary["achievement"].ToString();

                var post = new Post();
                post.Id = document.Id;
                post.Author = author;
                post.Comments = commentsArray;
                post.Content = content;
                post.Likes = likes;
                post.Created = created;
                post.Achievement = achievement;
                posts.Add(post);
            }
            return posts.ToArray();

        }

        public async Task<bool> CreatePost(string userId, string content, string achievement)
        {
            CollectionReference excercisesRef = this.FirestoreDb.Collection("Posts");
            string date = DateTime.Now.ToString("M/d/yyyy HH:mm", CultureInfo.InvariantCulture);
            var newPost = new Dictionary<string, object>()
            {
                { "author" , userId },
                { "content" , content },
                { "achievement" , achievement },
                { "likes", new string[0] },
                { "comments", new string[0] },
                { "created", date }
            };

            DocumentReference result = await excercisesRef.AddAsync(newPost);
            if (!String.IsNullOrEmpty(result.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LikePost(string postId, string userId)
        {
            DocumentReference excercisesRef = this.FirestoreDb.Collection("Posts").Document(postId);
            var query = await excercisesRef.GetSnapshotAsync();
            if (query.Exists)
            {
                var fields = query.ToDictionary();
                var likes = ((List<object>)fields["likes"]).Cast<string>().ToList();
                likes.Add(userId);
                var newLikes = new Dictionary<string, object>()
                {
                    {"likes", likes.ToArray() }
                };
                var result = await excercisesRef.UpdateAsync(newLikes);
                if(result == null)
                {
                    return false;
                }

                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> UnlikePost(string postId, string userId)
        {
            DocumentReference excercisesRef = this.FirestoreDb.Collection("Posts").Document(postId);
            var query = await excercisesRef.GetSnapshotAsync();
            if (query.Exists)
            {
                var fields = query.ToDictionary();
                var likes = ((List<object>)fields["likes"]).Cast<string>().ToList();
                likes.Remove(userId);
                var newLikes = new Dictionary<string, object>()
                {
                    {"likes", likes.ToArray() }
                };
                var result = await excercisesRef.UpdateAsync(newLikes);
                if (result == null)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
