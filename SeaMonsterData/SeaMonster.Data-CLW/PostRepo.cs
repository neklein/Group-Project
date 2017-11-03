﻿using SeaMonster.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Data_CLW
{
    public class PostRepo : IPostRepo
    {
        const string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

        public void ApproveComment(int CommentID)
        {
            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("ApproveComment", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", CommentID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void Approvepost(int postID)
        {
            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("ApprovePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", postID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void ApproveReply(int ReplyID)
        {
            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("ApproveReply", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReplyId", ReplyID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        //need to clarify procedure name
        public void CreateComment(int postId, string commenterName, string commentText)
        {
            Comment comment = new Comment();

            comment.PostId = postId;
            comment.CommenterName = commenterName;
            comment.CommentText = commentText;

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateComment", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@CommentId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@PostId", comment.PostId);
                cmd.Parameters.AddWithValue("@CommenterName", comment.CommenterName);
                cmd.Parameters.AddWithValue("@CommentText", comment.CommentText);

                cn.Open();
                cmd.ExecuteNonQuery();

                comment.CommentId = (int)param.Value;
            }
        }

        public int CreatePost(string PostTitle, string posttext, string displayauthor, string displaydate)
        { int x = 0;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@DisplayAuthor", displayauthor);
                cmd.Parameters.AddWithValue("@DisplayDate", (DateTime.Parse(displaydate)));
                cmd.Parameters.AddWithValue("@ExpDate", ' ');
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();
                x = (int)Param.Value;
            }
            return x;
            
        }

        public int CreatePost(string PostTitle, string posttext, string displayauthor, DateTime displaydate, DateTime expdate)
        {
            int x = 0;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@DisplayAuthor", displayauthor);
                cmd.Parameters.AddWithValue("@DisplayDate", displaydate);
                cmd.Parameters.AddWithValue("@ExpDate", expdate);
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();
                x = (int)Param.Value; 
            }
            return x;
        }

        public int CreatePostDelayed(string PostTitle, string posttext, string displayauthor, DateTime displaydate, DateTime postdate)
        {
            int x = 0;
            using (SqlConnection cn = new SqlConnection(cs))
            { 

                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@DisplayAuthor", displayauthor);
                cmd.Parameters.AddWithValue("@DisplayDate", displaydate);
                cmd.Parameters.AddWithValue("@ToPostDate", postdate);
                cmd.Parameters.AddWithValue("@ExpDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();
                x = (int)Param.Value;
            }
            return x;
        }

        public int CreatePostDelayed(string PostTitle, string posttext, DateTime postdate, string displayauthor, DateTime displaydate, DateTime expdate)
        {
            int x;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@ToPostDate", postdate);
                cmd.Parameters.AddWithValue("@ExpDate", expdate);
                cmd.Parameters.AddWithValue("@DisplayAuthor", displayauthor);
                cmd.Parameters.AddWithValue("@DisplayDate", displaydate);
                cn.Open();
                cmd.ExecuteNonQuery();
                x = (int)Param.Value;
            }
            return x;
        }

        public void CreateReply(int commentId, string replyName, string replyText)
        {
            Reply reply = new Reply();

            reply.CommentID = commentId;
            reply.ReplyName = replyName;
            reply.ReplyText = replyText;

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreateReply", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ReplyId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CommentId", reply.CommentID);
                cmd.Parameters.AddWithValue("@ReplyName", reply.ReplyName);
                cmd.Parameters.AddWithValue("@CommentText", reply.ReplyText);

                cn.Open();
                cmd.ExecuteNonQuery();

                reply.ReplyID = (int)param.Value;
            }

        }

        public void DeleteComment(int CommentID)
        {
            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CommentDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CommentId", CommentID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteReply(int ReplyID)
        {
            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("ReplyDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReplyId", ReplyID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<Comment> GetAllComments(int PostID)
        {
            List<Comment> comments = new List<Comment>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Comment" +
                        " WHERE PostId = @PostID";
                cmd.Parameters.AddWithValue("@PostID", PostID);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Comment comment = new Comment();

                        comment.PostId = PostID;
                        comment.CommentId = (int)dr["CommentID"];
                        comment.CommenterName = dr["CommenterName"].ToString();
                        comment.CommentDate = DateTime.Parse(dr["CommentDate"].ToString());
                        comment.CommentText = dr["CommentText"].ToString();
                        comment.IsShown = (bool)dr["IsShown"];
                        comments.Add(comment);
                    }
                }
            }
            return comments;

        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetALLPosts",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post post = new Post();

                        post.PostId = (int)dr["PostID"];
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.PostText = dr["PostText"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        post.DisplayAuthor = dr["DisplayAuthor"].ToString();
                        post.DisplayDate = DateTime.Parse(dr["DisplayDate"].ToString());
                        post.IsStatic = (bool)dr["isStatic"];
                        post.IsPublished = (bool)dr["ispublished"];
                        post.IsForReview = (bool)dr["isforReview"];

                        posts.Add(post);
                    }
                }
            }
            return posts;

        }

        public Post GetPostDetails(int postId)
        {
            Post post = new Post();
            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetPostByID", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostId", postId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        post.PostId = postId;
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        post.PostText = dr["PostText"].ToString();

                    }
                }
            }
            PostRepo repo = new PostRepo();
            post.Images = repo.GetImagesByPost(postId);

            return post;
        }



        public List<Image> GetImagesByPost(int postId)
        {
            List<Image> images = new List<Image>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetImagesForPost", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", postId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Image image = new Image();
                        image.ImageId = (int)dr["ImageId"];
                        image.PostId = postId;
                        image.ImageName = dr["ImageName"].ToString();

                        images.Add(image);
                    }
                }
            }

            return images;
        }

        public List<Comment> GetPublishedComments(int PostID)
        {
            PostRepo repo = new PostRepo();
            List<Comment> comments = repo.GetAllComments(PostID).Where(c => c.IsShown == true).ToList();

            return comments;

        }

        public List<Reply> GetPublishedReplies(int CommentID)
        {
            List<Reply> replies = new List<Reply>();
            PostRepo repo = new PostRepo();

            replies = repo.GetReplies(CommentID).Where(r => r.IsShown == true).ToList();

            return replies;

        }

        //May need to edit to match procedure in Sprocks
        public List<Reply> GetReplies(int CommentID)
        {
            List<Reply> replies = new List<Reply>();


            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Reply" +
                        " WHERE CommentID = @CommentID";

                cmd.Parameters.AddWithValue("@CommentID", CommentID);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Reply reply = new Reply();
                        reply.ReplyID = (int)dr["ReplyId"];
                        reply.ReplyName = dr["ReplyName"].ToString();
                        reply.ReplyDate = DateTime.Parse(dr["ReplyDate"].ToString());
                        reply.ReplyText = dr["ReplyText"].ToString();
                        reply.IsShown = (bool)dr["IsShown"];

                        replies.Add(reply);
                    }
                }

            }


            return replies;


        }
        public void AddHashtags(string categoryinput, int PostID)
        {
            PostRepo repo = new PostRepo();
            List<HashTag> CurrentCategories = repo.GetHashtags();
            List<string> CatTags = new List<string>();
            foreach (HashTag cat in CurrentCategories)
            {
                CatTags.Add(cat.Hashtag.ToLower());
            }
            char[] delimiters = new char[] { ',', '#', ' ' };
            List<string> Categories = categoryinput.Split(delimiters).ToList();
            List<string> categorysort = new List<string>();
            foreach (string s in Categories)
            {
                if (s.Length > 2 && !string.IsNullOrWhiteSpace(s))
                {
                    categorysort.Add(s.ToLower());
                }
            }
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                foreach (string c in categorysort)
                {
                    if (CatTags.Contains(c))
                    {
                        HashTag current = CurrentCategories.Where(m => m.Hashtag.ToLower() == c).FirstOrDefault();
                        SqlCommand cmd = new SqlCommand("ReuseHashtag", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HashtagID", current.HashtagID);
                        cmd.Parameters.AddWithValue("@PostID", PostID);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("AddNewHashtag", cn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        SqlParameter Param = new SqlParameter("@HashtagID", SqlDbType.Int);
                        Param.Direction = ParameterDirection.Output;
                        cmd2.Parameters.Add(Param);
                        cmd2.Parameters.AddWithValue("@Hashtag", c);
                        cmd2.Parameters.AddWithValue("@PostID", PostID);
                        cn.Open();
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
        }

        public List<HashTag> GetHashtags()
        {
            List<HashTag> CurrentCategories = new List<HashTag>();
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("select * from Hashtags", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        HashTag c = new HashTag();
                        c.HashtagID = (int)dr["HashtagID"];
                        c.Hashtag = dr["Hashtag"].ToString();
                        string date = dr["DateAdded"].ToString();
                        c.DateAdded = DateTime.Parse(date);
                        CurrentCategories.Add(c);
                    }
                }
            }
            return CurrentCategories;
        }

        public List<Post> GetPublishedPosts()
        {
            List<Post> posts = new List<Post>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetPublishedPosts", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post post = new Post();
                        post.PostId = (int)dr["PostID"];
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.PostText = dr["PostText"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        post.DisplayAuthor = dr["DisplayAuthor"].ToString();
                        post.DisplayDate = DateTime.Parse(dr["DisplayDate"].ToString());
                        post.IsStatic = (bool)dr["isStatic"];
                        post.IsPublished = (bool)dr["ispublished"];
                        post.IsForReview = (bool)dr["isforReview"];
                        posts.Add(post);
                    }
                }
            }
            return posts;
        }



        public List<Post> GetAllStaticPublished()
        {

            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllPosts().Where(p => p.IsStatic == true && p.IsPublished == true).ToList();

            return posts;

        }




        public void SetPostLists(Post post)
        {
            PostRepo repo = new PostRepo();
            post.PostCategories = GetCategoryByPost(post.PostId);
            post.Hashtags = repo.GetHashtagbyPost(post.PostId);
            post.Comments = GetPublishedComments(post.PostId);
            foreach (Comment c in post.Comments)
            {
                c.Replies = GetPublishedReplies(c.CommentId);
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> Cats = new List<Category>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from categories", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Category current = new Category();
                        current.CategoryID = (int)dr["CategoryID"];
                        current.CategoryName = dr["CategoryName"].ToString();
                        Cats.Add(current);
                    }
                }
            }
            return Cats;
        }

        public List<HashTag> GetHashtagbyPost(int PostID)
        {
            List<HashTag> hts = new List<HashTag>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetHashtagsByPost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", PostID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        HashTag c = new HashTag();
                        c.HashtagID = (int)dr["HashtagID"];
                        c.Hashtag = dr["Hashtag"].ToString();

                        hts.Add(c);
                    }
                }
            }
            return hts;
        }

        public List<Category> GetCategoryByPost(int PostID)
        {
            List<Category> Cats = new List<Category>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetCategorybyPost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", PostID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Category current = new Category();
                        current.CategoryID = (int)dr["CategoryID"];
                        current.CategoryName = dr["CategoryName"].ToString();
                        Cats.Add(current);
                    }
                }
            }
            return Cats;
        }

        public List<Comment> GetCommentsbyPost(int PostId)
        {
            List<Comment> comments = new List<Comment>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetCommentbyID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", PostId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Comment cmt = new Comment();
                        cmt.CommentId = (int)dr["CommentID"];
                        cmt.CommenterName = dr["CommenterName"].ToString();
                        cmt.CommentText = dr["CommentText"].ToString();
                        string date = dr["CommentDate"].ToString();
                        cmt.CommentDate = DateTime.Parse(date);
                        comments.Add(cmt);
                    }
                }

            }
            return comments;
        }

        public List<Post> GetAllStatic()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllPosts().Where(p => p.IsStatic == true).ToList();

            return posts;
        }

        public void ADMINSetPostList(Post post)
        {
            PostRepo repo = new PostRepo();
            post.PostCategories = GetCategoryByPost(post.PostId);
            post.Hashtags = repo.GetHashtagbyPost(post.PostId);
            post.Comments = GetCommentsbyPost(post.PostId);
            foreach (Comment c in post.Comments)
            {
                c.Replies = GetReplies(c.CommentId);
            }
        }

        public List<Post> GetPublishedPostbyHashtag(int HashtagID)
        {
            List<Post> posts = GetPostbyHashtag(HashtagID);
            List<Post> PublishedPosts = posts.Where(p => p.IsPublished).ToList();
            return PublishedPosts;
        }

        public List<Post> GetPostbyHashtag(int HashtagID)
        {
            List<Post> posts = new List<Post>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetPostByHashtag", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HashtagID", HashtagID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post current = new Post();
                        current.PostId = (int)dr["PostID"];
                        current.PostTitle = dr["PostTitle"].ToString();
                        current.PostText = dr["PostText"].ToString();
                        current.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        current.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        current.IsPublished = (bool)dr["IsPublished"];
                        posts.Add(current);
                    }
                }
            }
            return posts;
        }

        public List<Post> GetPostByCategory(int CatId)
        {
            List<Post> posts = new List<Post>();
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetPostByCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CatId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post current = new Post();
                        current.PostId = (int)dr["PostID"];
                        current.PostTitle = dr["PostTitle"].ToString();
                        current.PostText = dr["PostText"].ToString();
                        current.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        current.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        current.IsPublished = (bool)dr["IsPublished"];
                        posts.Add(current);
                    }
                }
            }
            return posts;
        }
        //may need to adjust the procedure name
        public void AddImage(string imageName)
        {
            using (var cn = new SqlConnection(cs))
            {
                Image image = new Image();
                image.ImageName = imageName;

                SqlCommand cmd = new SqlCommand("AddImage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ImageId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ImageName", imageName);

                cn.Open();
                cmd.ExecuteNonQuery();

                image.ImageId = (int)param.Value;
            }

        }

        public Comment GetCommentByCommentId(int commentId)
        {

            Comment comment = new Comment();
            comment.CommentId = commentId;

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT CommenterName, CommentText, CommentDate, PostId FROM Comment" +
                        " WHERE CommentID = @CommentId";
                cmd.Parameters.AddWithValue("@CommentId", commentId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        comment.PostId = (int)dr["PostId"];
                        comment.CommenterName = dr["CommenterName"].ToString();
                        comment.CommentDate = DateTime.Parse(dr["CommentDate"].ToString());
                        comment.CommentText = dr["CommentText"].ToString();
                        comment.IsShown = (bool)dr["IsShown"];
                    }
                }
            }

            return comment;
        }

        /*public Reply GetReplyByReplyId(int replyId)
        {
            Reply reply = new Reply();
            reply.ReplyID = replyId;

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT ReplyName, ReplyText, ReplyDate, PostId FROM Reply" +
                        " WHERE ReplyID = @ReplyId";
                cmd.Parameters.AddWithValue("@ReplyId", replyId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                    
                    }
                }
            }
            return ;}*/


        public List<Post> GetPublishedPostByCategory(int CatId)
        {
            List<Post> posts = GetPostByCategory(CatId).Where(p => p.IsPublished == true).ToList();
            return posts;
        }

        public Reply GetReplyByReplyId(int replyId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostByAuthor(string name)
        {
            List<Post> posts = GetAllPosts().Where(p => p.DisplayAuthor.ToLower() == name.ToLower()).ToList();
            return posts;
        }

        public Category GetCategoryByCatID(int CatID)
        {
            Category cat = GetAllCategories().Where(c => c.CategoryID == CatID).FirstOrDefault();
            return cat; 
        }

        public void SavePost()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPublishedPostbyAuthor(string name)
        {
            List<Post> posts = GetAllPostByAuthor(name).Where(p => p.IsPublished).ToList();
            return posts;
        }

        public Category GetCategoryByCatName(string name)
        {
            Category cat = GetAllCategories().Where(c => c.CategoryName == name).FirstOrDefault();
            return cat;
        }
    }

  
}
