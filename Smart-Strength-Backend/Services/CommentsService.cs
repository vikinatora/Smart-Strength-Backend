using Google.Cloud.Firestore;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services
{
    public class CommentsService : FirebaseService, ICommentsService
    {
        public IUsersService UsersService { get; private set; }

        public CommentsService(IUsersService usersService)
        {
            this.UsersService = usersService;
        }

        public async Task<Comment[]> GetComments(object[] commentsIDs)
        {
            List<Comment> comments = new List<Comment>();
            CollectionReference commentsCollection = this.FirestoreDb.Collection("Comments");
            foreach (string id in commentsIDs)
            {
                DocumentSnapshot docSnapshot = await commentsCollection.Document(id).GetSnapshotAsync();
                Dictionary<string, object> docInfo = docSnapshot.ToDictionary();
                User author = await this.UsersService.GetUser(docInfo["author"].ToString());
                List<object> likes = (List<object>)docInfo["likes"];

                Comment comment = new Comment();
                comment.Id = id;
                comment.Author = author;
                comment.Content = docInfo["content"].ToString();
                comment.Likes = likes.Cast<string>().ToArray();

                comments.Add(comment);

            }

            return comments.ToArray();
        }

        public async Task<Comment> AddComment(string postId, string userId, string content)
        {
            Dictionary<string, object> newComment = new Dictionary<string, object>()
            {
                { "content", content },
                { "author", userId },
                { "likes", new string[0] }

            };

            DocumentReference result = await this.FirestoreDb.Collection("Comments").AddAsync(newComment);
            if (result == null)
            {
                return null;
            }
            DocumentReference post = this.FirestoreDb.Collection("Posts").Document(postId);
            DocumentSnapshot query = await post.GetSnapshotAsync();

            if (!query.Exists)
            {
                return null;
            }
            Dictionary<string, object> fields = query.ToDictionary();
            List<string> comments = ((List<object>)fields["comments"]).Cast<string>().ToList();
            comments.Add(result.Id);

            Dictionary<string, object> newComments = new Dictionary<string, object>()
            {
                { "comments", comments}
            };

            WriteResult updareResult = await post.UpdateAsync(newComments);
            if (updareResult == null)
            {
                return null;
            }
            Comment comment = new Comment();
            comment.Author = await this.UsersService.GetUser(userId);
            comment.Content = content;
            comment.Likes = new string[0];

            return comment;
        }

        public async Task<bool> LikeComment(string commentId, string userId)
        {
            DocumentReference excercisesRef = this.FirestoreDb.Collection("Comments").Document(commentId);
            DocumentSnapshot query = await excercisesRef.GetSnapshotAsync();
            if (query.Exists)
            {
                Dictionary<string, object> fields = query.ToDictionary();
                List<string> likes = ((List<object>)fields["likes"]).Cast<string>().ToList();
                likes.Add(userId);
                Dictionary<string, object> newLikes = new Dictionary<string, object>()
                {
                    {"likes", likes.ToArray() }
                };
                WriteResult result = await excercisesRef.UpdateAsync(newLikes);
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

        public async Task<bool> UnlikeComment(string commentId, string userId)
        {
            DocumentReference excercisesRef = this.FirestoreDb.Collection("Comments").Document(commentId);
            DocumentSnapshot query = await excercisesRef.GetSnapshotAsync();
            if (query.Exists)
            {
                Dictionary<string, object> fields = query.ToDictionary();
                List<string> likes = ((List<object>)fields["likes"]).Cast<string>().ToList();
                likes.Remove(userId);
                Dictionary<string, object> newLikes = new Dictionary<string, object>()
                {
                    {"likes", likes.ToArray() }
                };
                WriteResult result = await excercisesRef.UpdateAsync(newLikes);
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
