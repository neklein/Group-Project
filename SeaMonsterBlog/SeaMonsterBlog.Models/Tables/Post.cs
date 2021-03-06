﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeaMonsterBlog.Models.Tables
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public int UserId { get; set; }
        public string PostTitle { get; set; }
        public string HashtagString { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? ToPostDate { get; set; }
        public DateTime? DisplayDate { get; set; }
        public bool IsStatic { get; set; }
        public bool IsPublished { get; set; }
        public bool IsForReview { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Hashtag> Hashtags { get; set; }
        public List<Category> SelectedCategories { get; set; }
        public int? NumberOfUnapprovedComments { get; set; }
        public string Author { get; set; }
        

        
    }
}
