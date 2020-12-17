using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;

namespace Smart_Strength_Backend.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public PostsService PostsService { get; }

        public PostsController()
        {
            this.PostsService = new PostsService();
        }
        [HttpGet]
        [Route("get")]
        public async Task<Post[]> GetPosts()
        {
            try
            {
                Post[] posts = await this.PostsService.GetPosts();
                return posts;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<bool> CreatePost(string userId, string content, string achievement)
        {
            try
            {
                bool result = await this.PostsService.CreatePost(userId, content, achievement);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost]
        [Route("like")]
        public async Task<bool> LikePost(string postId, string userId)
        {
            try
            {
                bool result = await this.PostsService.LikePost(postId, userId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost]
        [Route("unlike")]
        public async Task<bool> UnlikePost(string postId, string userId)
        {
            try
            {
                bool result = await this.PostsService.UnlikePost(postId, userId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
