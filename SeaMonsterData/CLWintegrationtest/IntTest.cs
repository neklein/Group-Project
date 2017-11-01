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

        public void CanCreatePostWithExpDate() //finish
        {
            PostRepo repo = new PostRepo();

        }

        [Test]
        public void GetImages()
        {
            PostRepo repo = new PostRepo();

            List<Image> images = repo.GetImagesByPost(1);

            Assert.AreEqual(2, images.Count());
            Assert.AreEqual("SeriousSelfie.jpg", images[0].ImageName);
        }
    }
}
