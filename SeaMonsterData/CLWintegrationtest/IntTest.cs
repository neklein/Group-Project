using NUnit.Framework;
using SeaMonster.Data_CLW;
using SeaMonster.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLWintegrationtest
{
    [TestFixture]
    public class IntTest
    {
        [SetUp]
        public void Setup()
        {
            using(SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("MosterDBRest", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

      [Test]
      public void CanLoadHashtags()
        {
            PostRepo repo = new PostRepo();
            List<HashTag> Cats = repo.GetHashtags();
            Assert.IsNotNull(Cats);
            Assert.AreEqual(8, Cats.Count());
        }

        [Test]
        [TestCase("#Excited,#Scared",5,8)]
        [TestCase("#Excited,  #Scared", 5, 8)]
        public void CanResuseHashtag(string test, int postID, int expected)
        {
            PostRepo repo = new PostRepo();
            repo.AddHashtags(test, postID);
            List<HashTag> Cats = repo.GetHashtags();
            Assert.AreEqual(expected, Cats.Count());
        }

        [Test]
        [TestCase("#New #ShouldWork",5,10)]
        public void CanAddNewHashtag(string test, int postID, int expected)
        {
            PostRepo repo = new PostRepo();
            repo.AddHashtags(test, postID);
            List<HashTag> Cats = repo.GetHashtags();
            Assert.AreEqual(expected, Cats.Count());
        }
        [Test]

        public void CanCreatePost()
        {
            PostRepo repo = new PostRepo();
            repo.CreatePost("testTitle", "This is text for a test of the ability to add text to a new post");
            List<Post> posts = repo.GetAllPosts();
            Assert.AreEqual(6, posts.Count());
        }

        [Test]
        [TestCase(5,1)]
        [TestCase(4,2)]
        public void CanGetHashtagsbyID(int postid, int x)
        {
            PostRepo repo = new PostRepo();
            List<HashTag> hts = repo.GetHashtagbyPost(postid);
            Assert.AreEqual(x, hts.Count());
        }
        [Test]
        public void CanLoadCategories()
        {
            PostRepo repo = new PostRepo();
            List<Category> cats = repo.GetAllCategories();
            Assert.AreEqual(3, cats.Count());
        }

        [Test]
        [TestCase(2, 2)]
        [TestCase(5, 1)]
        public void CanLoadCategoriesbyPost(int postID, int x)
        {
            PostRepo repo = new PostRepo();
            List<Category> cats = repo.GetCategoryByPost(postID);
            Assert.AreEqual(x, cats.Count());
        }

        [Test]
        [TestCase(1,1)]
        [TestCase(5,0)]
        public void CanloadCommentsbyID(int postID, int x)
        {
            PostRepo repo = new PostRepo();
            List<Comment> cmts = repo.GetCommentsbyPost(postID);
            Assert.AreEqual(x, cmts.Count());
        }

        [Test]
        public void GetPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllPosts().ToList();

            Assert.AreEqual(5, posts.Count());
        }


      

        [Test]
        public void GetPublishedPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPost();

            Assert.AreEqual(4, posts.Count());
            Assert.AreEqual("Hello Fellow Monster Hunters", posts[0].PostTitle);
        }

        [Test]
        public void CanGetStaticPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllStatic();

            Assert.AreEqual(0, posts.Count());
        }

        [Test]
        public void CanGetStaticPublishedPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllStaticPublished();

            Assert.AreEqual(0, posts.Count());
        }


        

        [Test]
        public void GetImages()
        {
            PostRepo repo = new PostRepo();

            List<Image> images = repo.GetImagesByPost(1);

            Assert.AreEqual(2, images.Count());
            Assert.AreEqual("SeriousSelfie.jpg", images[0].ImageName);
        }

        [Test]
        public void CanGetCommentsByPost()
        {
            PostRepo repo = new PostRepo();
            List<Comment> comments = repo.GetAllComments(1);
            List<Comment> commentsEmpty = repo.GetAllComments(3);

            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual("Nice Boat!", comments[0].CommentText);

            Assert.AreEqual(0, commentsEmpty.Count);

        }

        [Test]
        public void CanGetPublishedCommentsByPost()
        {
            PostRepo repo = new PostRepo();
            List<Comment> comments = repo.GetPublishedComments(1);
            List<Comment> commentsEmpty = repo.GetPublishedComments(4);

            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual("Nice Boat!", comments[0].CommentText);

            Assert.AreEqual(0, commentsEmpty.Count);

        }

        [Test]
        public void GetRepliesByComment()
        {
            PostRepo repo = new PostRepo();
            List<Reply> replies = repo.GetReplies(1);

            Assert.AreEqual(1, replies.Count);
            Assert.AreEqual("I've seen better", replies[0].ReplyText);
        }

        [Test]
        public void GetPublishedRepliesByComment()
        {
            PostRepo repo = new PostRepo();
            List<Reply> replies = repo.GetPublishedReplies(1);

            Assert.AreEqual(1, replies.Count);
            Assert.AreEqual("I've seen better", replies[0].ReplyText);
        }

        [Test]
        public void CanSetPostList()
        {
            PostRepo repo = new PostRepo();
            Post post = repo.GetPostDetails(2);
            repo.SetPostLists(post);
            Assert.AreEqual(3,post.Hashtags.Count());
            Assert.AreEqual(2, post.PostCategories.Count());
            Assert.AreEqual(1, post.Comments.Count);
            Assert.AreEqual(1, post.Comments[0].Replies.Count());
        }

        [Test]
        public void CanSetADMINPostList()
        {
            PostRepo repo = new PostRepo();
            Post post = repo.GetPostDetails(2);
            repo.ADMINSetPostList(post);
            Assert.AreEqual(3, post.Hashtags.Count());
            Assert.AreEqual(2, post.PostCategories.Count());
            Assert.AreEqual(2, post.Comments.Count);
            Assert.AreEqual(2, post.Comments[0].Replies.Count());
        }

        [Test]
        public void CangetbyHashtag()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostbyHashtag(1);
            Assert.AreEqual(2, posts.Count());
            List<Post> posts2 = repo.GetPostbyHashtag(8);
            Assert.AreEqual(posts2.Count, 1);
        }
        [Test]
        public void CangetPublishedbyHashtag()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPostbyHashtag(1);
            Assert.AreEqual(2, posts.Count());
            List<Post> posts2 = repo.GetPublishedPostbyHashtag(8);
            Assert.AreEqual(posts2.Count, 0);
        }
        [Test]
        public void CanGetPostByCat()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostByCategory(1);
            Assert.AreEqual(3, posts.Count());
            List<Post> posts2 = repo.GetPostByCategory(3);
            Assert.AreEqual(posts2.Count, 1);
        }
        [Test]
        public void CanGetPublishedPostByCat()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPostByCategory(1);
            Assert.AreEqual(2, posts.Count());
            List<Post> posts2 = repo.GetPublishedPostByCategory(3);
            Assert.AreEqual(posts2.Count, 1);
        }

    }
}
