using SeaMonsterBlog.Data;
using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Data_CLW
{
    public class PostRepo : IRepository
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
        public void CreateComment(Comment comment)
        {

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

        public int CreateNewPost(Post post)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);

                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@ExpDate", ' ');
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();

                post.PostId = (int)Param.Value;

                return post.PostId;
            }
        }

        public int CreatePostExpDate(Post post)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);

                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@ExpDate", post.ExpDate);
                cmd.Parameters.AddWithValue("@ToPostDate", ' ');
                cn.Open();
                cmd.ExecuteNonQuery();

                post.PostId = (int)Param.Value;
                return post.PostId;
            }

       
        }

        public int CreatePostDelayed(Post post)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);

                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@ToPostDate", post.ToPostDate);
                cmd.Parameters.AddWithValue("@ExpDate", ' '); //working on the white space

                cn.Open();
                cmd.ExecuteNonQuery();

                post.PostId = (int)Param.Value;
                return post.PostId;
            }

        }

        public int CreatePostDelayedAndExp(Post post)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CreatePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Param = new SqlParameter("@PostID", SqlDbType.Int);
                Param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Param);

                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@ExpDate", post.ExpDate);
                cmd.Parameters.AddWithValue("@ToPostDate", post.ToPostDate);
                cn.Open();
                cmd.ExecuteNonQuery();

                post.PostId = (int)Param.Value;
                return post.PostId;

            }

        }

        public void CreateReply(Reply reply)
        {
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
                SqlCommand cmd = new SqlCommand("GetAllPosts", cn);
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
                        post.Author = dr["DisplayAuthor"].ToString();
                        post.DisplayDate = DateTime.Parse(dr["DisplayDate"].ToString());
                        post.IsStatic = (bool)dr["isStatic"];
                        post.IsPublished = (bool)dr["isPublished"];
                        post.IsForReview = (bool)dr["isForReview"];

                        posts.Add(post);
                    }
                }
            }
            return posts;

        }

        public Post GetPostByID(int postId)
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

                        post.PostId = (int)dr["PostID"];
                        post.PostTitle = dr["PostTitle"].ToString();
                        post.PostText = dr["PostText"].ToString();
                        post.DateCreated = DateTime.Parse(dr["DateCreated"].ToString());
                        string toPostDate = dr["ToPostDate"].ToString();
                        if (!string.IsNullOrWhiteSpace(toPostDate))
                        {
                            post.ToPostDate = DateTime.Parse(toPostDate);
                        }

                        post.Author = dr["DisplayAuthor"].ToString();

                        string displayDate = dr["DisplayDate"].ToString();
                        if (!string.IsNullOrWhiteSpace(displayDate))
                        {
                            post.DisplayDate = DateTime.Parse(displayDate);
                        }

                        string expdate = dr["Expdate"].ToString();
                        if (!string.IsNullOrWhiteSpace(expdate))
                        {
                            post.ExpDate = DateTime.Parse(expdate);
                        }
                        post.IsStatic = (bool)dr["isStatic"];
                        post.IsPublished = (bool)dr["ispublished"];
                        post.IsForReview = (bool)dr["isforReview"];

                    }
                }
            }

            return post;

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

            replies = repo.GetAllReply(CommentID).Where(r => r.IsShown == true).ToList();

            return replies;

        }

        public List<Reply> GetAllReply(int CommentID)
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
            List<Hashtag> CurrentCategories = repo.GetHashtags();
            List<string> CatTags = new List<string>();
            foreach (Hashtag cat in CurrentCategories)
            {
                CatTags.Add(cat.HashtagName.ToLower());
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
                        Hashtag current = CurrentCategories.Where(m => m.HashtagName.ToLower() == c).FirstOrDefault();
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

        public List<Hashtag> GetHashtags()
        {
            List<Hashtag> CurrentCategories = new List<Hashtag>();
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("select * from Hashtags", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Hashtag c = new Hashtag();
                        c.HashtagID = (int)dr["HashtagID"];
                        c.HashtagName = dr["Hashtag"].ToString();
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
                        post.ToPostDate = DateTime.Parse(dr["PostDate"].ToString());
                        post.Author = dr["DisplayAuthor"].ToString();
                        post.DisplayDate = DateTime.Parse(dr["DisplayDate"].ToString());
                        string expdate = dr["Expdate"].ToString();
                        if (!string.IsNullOrWhiteSpace(expdate))
                        {
                            post.ExpDate = DateTime.Parse(expdate);
                        }
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
            post.SelectedCategories = GetCategoryByPost(post.PostId);
            post.Hashtags = repo.GetHashtagbyPost(post.PostId);
            post.Comments = GetPublishedComments(post.PostId);
            foreach (Comment c in post.Comments)
            {
                c.Replies = GetPublishedReplies(c.CommentId);
            }
            post.HashtagString = "";
            foreach (Hashtag h in post.Hashtags)
            {
                post.HashtagString += "#" + h.HashtagName + ",";
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
                        current.CategoryTag = dr["CategoryName"].ToString();
                        Cats.Add(current);
                    }
                }
            }
            return Cats;
        }

        public List<Hashtag> GetHashtagbyPost(int PostID)
        {
            List<Hashtag> hts = new List<Hashtag>();
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
                        Hashtag c = new Hashtag();
                        c.HashtagID = (int)dr["HashtagID"];
                        c.HashtagName = dr["Hashtag"].ToString();

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
                        current.CategoryTag = dr["CategoryName"].ToString();
                        Cats.Add(current);
                    }
                }
            }
            return Cats;
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
            post.SelectedCategories = GetCategoryByPost(post.PostId);
            post.Hashtags = repo.GetHashtagbyPost(post.PostId);
            post.Comments = GetAllComments(post.PostId);
            foreach (Comment c in post.Comments)
            {
                c.Replies = GetAllReply(c.CommentId);
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

        public Reply GetReplyByReplyId(int replyId)
        {
            Reply reply = new Reply();
            reply.ReplyID = replyId;

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = cn;
                cmd.CommandText = "SELECT ReplyName, ReplyText, ReplyDate, CommentID FROM Reply" +
                        " WHERE ReplyID = @ReplyId";
                cmd.Parameters.AddWithValue("@ReplyId", replyId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        reply.CommentID = (int)dr["CommentID"];
                        reply.ReplyName = dr["ReplyName"].ToString();
                        reply.ReplyText = dr["ReplyText"].ToString();
                        reply.ReplyDate = DateTime.Parse(dr["ReplyDate"].ToString());

                    }
                }
            }
            return reply;
        }

        public List<Post> GetPublishedPostByCategory(int CatId)
        {
            List<Post> posts = GetPostByCategory(CatId).Where(p => p.IsPublished == true).ToList();
            return posts;
        }

        public List<Post> GetAllPostByAuthor(string name)
        {
            List<Post> posts = GetAllPosts().Where(p => p.Author.ToLower() == name.ToLower()).ToList();
            return posts;
        }

        public List<Post> GetPublishedPostbyAuthor(string name)
        {
            List<Post> posts = GetAllPostByAuthor(name).Where(p => p.IsPublished).ToList();
            return posts;
        }


        public List<Image> GetAllImages()
        {
            List<Image> images = new List<Image>();

            string cs = "Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;";

            using (var cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = "SELECT * FROM Images";

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Image image = new Image();
                        image.ImageId = (int)dr["ImageId"];
                        image.ImageName = dr["ImageName"].ToString();

                        images.Add(image);
                    }
                }
            }

            return images;

        }

        public void SavePost(Post post)
        {
            List<Hashtag> OriginalTags = GetHashtagbyPost(post.PostId);
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SavePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", post.PostId);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@isForReview", post.IsForReview);
                cmd.Parameters.AddWithValue("@isStatic", post.IsStatic);
                if (post.DisplayDate != null)
                {
                    cmd.Parameters.AddWithValue("@DisplayDate", post.DisplayDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DisplayDate", DBNull.Value);
                }
                if (post.ExpDate != null)
                {
                    cmd.Parameters.AddWithValue("@ExpDate", post.ExpDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ExpDate", DBNull.Value);
                }
                if (post.ToPostDate != null)
                {
                    cmd.Parameters.AddWithValue("@ToPostDate", post.ToPostDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ToPostDate", DBNull.Value);
                }
                cn.Open();
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(post.HashtagString))
                {
                    SqlCommand cmd3 = new SqlCommand("ClearHashtags", cn);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@PostID", post.PostId);
                    cmd3.ExecuteNonQuery();
                    AddHashtags(post.HashtagString, post.PostId);
                    List<Hashtag> newtags = GetHashtagbyPost(post.PostId);

                }
            }
        }

        public void ADMINSavePost(Post post)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("AdminSavePost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", post.PostId);
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostText", post.PostText);
                cmd.Parameters.AddWithValue("@DisplayAuthor", post.Author);
                cmd.Parameters.AddWithValue("@DisplayDate", post.DisplayDate);
                cmd.Parameters.AddWithValue("@isForReview", post.IsForReview);
                cmd.Parameters.AddWithValue("@IsPublished", post.IsPublished);
                if (post.ToPostDate != null)
                {
                    cmd.Parameters.AddWithValue("@ToPostDate", post.ToPostDate);
                }

                if (post.ExpDate != null)
                {
                    cmd.Parameters.AddWithValue("@ExpDate", ' ');
                }
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveNewImage(string imageName)
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

        public int FindNextPublishedPost(int PostID)
        {
            List<Post> posts = GetPublishedPosts().Where(p => p.IsStatic == false).ToList();
            int next = posts.Max(p => p.PostId);
            int curr = posts.IndexOf(posts.Where(p => p.PostId == PostID).FirstOrDefault());
            if (curr < posts.Count - 1)
            {
                next = posts[curr + 1].PostId;
            }
            return next;
        }

        public int FindPreviousPublishedPost(int PostID)
        {
            int prev = 1;
            List<Post> posts = GetPublishedPosts().Where(p => p.IsStatic == false).ToList();

            int curr = posts.IndexOf(posts.Where(p => p.PostId == PostID).FirstOrDefault());
            if (curr > 0 && posts[curr - 1] != null)
            {
                prev = posts[curr - 1].PostId;
            }

            return prev;

        }

        public int FindFirstPublishedPost()
        {
            List<Post> posts = GetPublishedPosts().Where(p => p.IsStatic == false).ToList();
            int first = posts[0].PostId;
            return first;

        }

        public int FindLastPublishedPost()
        {
            List<Post> posts = GetPublishedPosts().Where(p => p.IsStatic == false).ToList();
            int last = posts.Max(p => p.PostId);
            return last;

        }
    }


}
