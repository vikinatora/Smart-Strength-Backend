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
            var comments = new List<Comment>();
            var commentsCollection = this.FirestoreDb.Collection("Comments");
            foreach (string id in commentsIDs)
            {
                var docSnapshot = await commentsCollection.Document(id).GetSnapshotAsync();
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
            var newComment = new Dictionary<string, object>()
            {
                { "content", content },
                { "author", userId },
                { "likes", new string[0] }

            };

            var result = await this.FirestoreDb.Collection("Comments").AddAsync(newComment);
            if (result == null)
            {
                return null;
            }
            var post = this.FirestoreDb.Collection("Posts").Document(postId);
            var query = await post.GetSnapshotAsync();

            if (!query.Exists)
            {
                return null;
            }
            var fields = query.ToDictionary();
            var comments = ((List<object>)fields["comments"]).Cast<string>().ToList();
            comments.Add(result.Id);

            var newComments = new Dictionary<string, object>()
            {
                { "comments", comments}
            };

            var updareResult = await post.UpdateAsync(newComments);
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
