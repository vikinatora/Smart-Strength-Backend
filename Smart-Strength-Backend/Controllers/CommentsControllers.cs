using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Strength_Backend.Models;
using Smart_Strength_Backend.Services;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Smart_Strength_Backend.Controllers
{
	public class CommentsControllers : ControllerBase
	{
		
		[Route("api/comments")]
		[ApiController]
		public CommentsService CommentsService { get; private set; }

		public CommentsControllers()
		{
			this.CommentsService = new CommentsService();
		}
        [HttpGet]
        [Route("get")]
        public async Task<Comment[]> GetPosts()
        {
            try
            {
                Comments[] comments = await this.CommentsService.GetComments();
                return comments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}