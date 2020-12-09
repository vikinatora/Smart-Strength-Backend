﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Models
{
    public class Post
    {
        public string Content { get; set; }
        public User Author { get; set; }
        public Comment[] Comments { get; set; }
        public string[] Likes { get; set; }
    }
}
