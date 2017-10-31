﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Models.Tables
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public int UserId { get; set; }
        public string PostTitle { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ToPostDate { get; set; }
        public bool IsStatic { get; set; }
        public bool IsPublished { get; set; }

        public List<Image> Images { get; set; }
    }
}
