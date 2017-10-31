using SeaMonster.Models.Tables;
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
            throw new NotImplementedException();
        }

        public void Approvepost(int postID)
        {
            throw new NotImplementedException();
        }

        public void ApproveReply(int ReplyID)
        {
            throw new NotImplementedException();
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

        public void CreatePost(string PostTitle, string posttext)
        {
            using(SqlConnection cn =new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@ExpDate", ' ');
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreatePost(string PostTitle, string posttext, DateTime expdate)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);
                cmd.Parameters.AddWithValue("@PostTitle", PostTitle);
                cmd.Parameters.AddWithValue("@PostText", posttext);
                cmd.Parameters.AddWithValue("@ExpDate", expdate);
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate)
        {
            throw new NotImplementedException();
        }

        public void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate, DateTime expdate)
        {
            throw new NotImplementedException();
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
            List<Post> posts = new List<Post>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Post";

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post post = new Post();

                        post.PostId = (int)dr["PostID"];
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());

                        posts.Add(post);
                    }
                }
            }
            return posts;

        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Post";

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post post = new Post();

                        post.PostId = (int)dr["PostID"];
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());

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
            List<Comment> comments = new List<Comment>();


            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetCommentbyID", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", PostID);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommenterName = dr["CommenterName"].ToString();
                        comment.CommentDate = DateTime.Parse(dr["CommentDate"].ToString());
                        comment.CommentText = dr["CommentText"].ToString();

                        comments.Add(comment);
                    }
                }

            }


            return comments;

        }

        public List<Reply> GetPublishedReplies(int CommentID)
        {
            throw new NotImplementedException();
        }

        //May need to edit to match procedure in Sprocks
        public List<Reply> GetReplies(int CommentID)
        {
            List<Reply> replies = new List<Reply>();


            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetReplybyID", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", CommentID);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Reply reply = new Reply();
                        reply.ReplyName = dr["ReplyName"].ToString();
                        reply.ReplyDate = DateTime.Parse(dr["ReplyDate"].ToString());
                        reply.ReplyText = dr["ReplyText"].ToString();

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
            foreach(HashTag cat in CurrentCategories)
            {
                CatTags.Add(cat.Hashtag.ToLower());
            }
            char[] delimiters = new char[] { ',', '#', ' ' };
            List<string> Categories = categoryinput.Split(delimiters).ToList();
            List<string> categorysort = new List<string>();
            foreach(string s in Categories)
            {
                if (s.Length >2 && !string.IsNullOrWhiteSpace(s))
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
                        HashTag current=  CurrentCategories.Where(m => m.Hashtag.ToLower() == c).FirstOrDefault();
                        SqlCommand cmd = new SqlCommand("ReuseCategory", cn);
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
                SqlCommand cmd = new SqlCommand("select * from Categories", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
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

        public List<Post> GetPublishedPost()
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

                        post.PostTitle = dr["PostTitle"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        post.ToPostDate = DateTime.Parse(dr["ToPostDate"].ToString());
                        post.PostText = dr["PostText"].ToString();

                        posts.Add(post);
                    }
                }
            }
            return posts;
        }
    }
}
