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

        public void Createcomment()
        {
            throw new NotImplementedException();
        }

        public void CreatePost(string PostTitle, string posttext)
        {
            throw new NotImplementedException();
        }

        public void CreatePost(string PostTitle, string posttext, DateTime expdate)
        {
            throw new NotImplementedException();
        }

        public void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate)
        {
            throw new NotImplementedException();
        }

        public void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate, DateTime expdate)
        {
            throw new NotImplementedException();
        }

        public void CreateReply()
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int CommmentID)
        {
            throw new NotImplementedException();
        }

        public void DeleteReply(int ReplyID)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments(int PostID)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPost()
        {
            List<Post> posts = new List<Post>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GetPublishedPosts", cn);
                SqlCommand cmdImage = new SqlCommand("GetImagesForPost", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmdImage.CommandType = CommandType.StoredProcedure;

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
                        post.PostText = dr["PostText"].ToString();

                        cmdImage.Parameters.AddWithValue("@PostID", post.PostId);

                        using (SqlDataReader dr1 = cmdImage.ExecuteReader())
                        {
                            while (dr1.Read())
                            {
                                Image image = new Image();
                                image.ImageId = (int)dr1["ImageID"];
                                image.ImageName = dr["ImageName"].ToString();

                                post.Images.Add(image);
                            }
                        }
                        posts.Add(post);
                    }
                }
            }
            return posts;

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

        public List<Post> GetPublishefPost()
        {
            throw new NotImplementedException();
        }

        public List<Reply> GetReplies(int CommentID)
        {
            throw new NotImplementedException();
        }
        public void AddCategoryTags(string categoryinput, int PostID)
        {
            PostRepo repo = new PostRepo();
            List<Category> CurrentCategories = repo.GetCategories();
            List<string> CatTags = new List<string>();
            foreach(Category cat in CurrentCategories)
            {
                CatTags.Add(cat.CategoryTag);
            }
            char[] delimiters = new char[] { ',', '#', ' ' };
            List<string> Categories = categoryinput.Split(delimiters).ToList();
            List<string> categorysort = new List<string>();
            foreach(string s in Categories)
            {
                if (s.Length > 3)
                {
                    categorysort.Add(s);
                }
            }
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                foreach (string c in categorysort)
                {
                    if (CatTags.Contains(c))
                    {
                        Category current = CurrentCategories.Where(m => m.CategoryTag == c).FirstOrDefault();
                        SqlCommand cmd = new SqlCommand("ReuseCategory", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", current.CategoryID);
                        cmd.Parameters.AddWithValue("@PostID", PostID);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("AddNewCategory", cn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("CategoryTag", c);
                        cmd2.Parameters.AddWithValue("PostID", PostID);
                        cn.Open();
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> CurrentCategories = new List<Category>();
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("select * from Categories", cn);
                cmd.CommandType = CommandType.Text;
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Category c = new Category();
                        c.CategoryID = (int)dr["CategoryID"];
                        c.CategoryTag = dr["CategoryTag"].ToString();
                        string date = dr["DateAdded"].ToString();
                        c.DateAdded = DateTime.Parse(date);
                    }
                }
            }
            return CurrentCategories;
        }
    }
}
