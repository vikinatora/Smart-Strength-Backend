using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface IPostsService : IFirebaseService
    {
        Task<Post[]> GetPosts();
        Task<bool> CreatePost(string userId, string content, string achievement);
        Task<bool> LikePost(string postId, string userId);
        Task<bool> UnlikePost(string postId, string userId);
    }
}
