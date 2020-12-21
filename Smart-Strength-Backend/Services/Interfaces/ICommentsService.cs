using Smart_Strength_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Services.Interfaces
{
    public interface ICommentsService: IFirebaseService
    {
        Task<Comment[]> GetComments(object[] commentsIDs);
        Task<Comment> AddComment(string postId, string userId, string content);
        Task<bool> LikeComment(string commentId, string userId);
        Task<bool> UnlikeComment(string commentId, string userId);
    }
}
