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

        Post TestPost = new Post
        {
            PostTitle="TestPost",
            PostText="This is a test of a tests post",
            DisplayAuthor="Test Author",
            IsForReview=true
          

        };

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
            List<Post> posts1 = repo.GetAllPosts();
            Assert.AreEqual(9, posts1.Count());
            repo.CreatePost(TestPost);
            List<Post> posts = repo.GetAllPosts();
            Assert.AreEqual(10, posts.Count());
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

            Assert.AreEqual(9, posts.Count());
        }


      

        [Test]
        public void GetPublishedPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPosts();

            Assert.AreEqual(5, posts.Count());
            Assert.AreEqual("Hello Fellow Monster Hunters", posts[0].PostTitle);
        }

        [Test]
        public void CanGetStaticPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllStatic();

            Assert.AreEqual(1, posts.Count());
        }

        [Test]
        public void CanGetStaticPublishedPosts()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllStaticPublished();

            Assert.AreEqual(1, posts.Count());
        }


        
        /*
        [Test]
        public void GetImages()
        {
            PostRepo repo = new PostRepo();

            List<Image> images = repo.GetImagesByPost(1);

            Assert.AreEqual(2, images.Count());
            Assert.AreEqual("SeriousSelfie.jpg", images[0].ImageName);
        }*/

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
            Assert.AreEqual("#excited,#swimforyourlife!,#monsterofthemonth", post.HashtagInput.ToLower().Trim());
        }

        [Test]
        public void CangetbyHashtag()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostbyHashtag(1);
            Assert.AreEqual(4, posts.Count());
            List<Post> posts2 = repo.GetPostbyHashtag(8);
            Assert.AreEqual(posts2.Count, 1);
        }
        [Test]
        public void CangetPublishedbyHashtag()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPostbyHashtag(1);
            Assert.AreEqual(3, posts.Count());
            List<Post> posts2 = repo.GetPublishedPostbyHashtag(8);
            Assert.AreEqual(posts2.Count, 0);
        }
        [Test]
        public void CanGetPostByCat()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostByCategory(1);
            Assert.AreEqual(6, posts.Count());
            List<Post> posts2 = repo.GetPostByCategory(3);
            Assert.AreEqual(posts2.Count, 2);
        }
        [Test]
        public void CanGetPublishedPostByCat()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPostByCategory(1);
            Assert.AreEqual(2, posts.Count());
            List<Post> posts2 = repo.GetPublishedPostByCategory(3);
            Assert.AreEqual(posts2.Count, 2);
        }

        [Test]
        public void CanSavePost()
        {
            PostRepo repo = new PostRepo();
            repo.CreatePost(TestPost);
            List<Post> post = repo.GetAllPosts();
            Assert.AreEqual(10, post.Count);
            TestPost = post[9];
            TestPost.PostTitle = "ModifiedyTestTitle";
            TestPost.PostText = "Modified Modified";
            TestPost.ToPostDate = DateTime.Parse("2017-11-14");
            repo.SavePost(TestPost);
            List<Post> post1 = repo.GetAllPosts();
            Assert.AreEqual("ModifiedyTestTitle", post1[9].PostTitle);
            Assert.AreEqual("Modified Modified", post1[9].PostText);
            Assert.AreEqual(10, post.Count);
        }
        [Test]
        public void CanAddPostWithHashtags()
        {
            TestPost.HashtagInput = "#Test1,#Test2";
            PostRepo repo = new PostRepo();
            repo.CreatePost(TestPost);
            List<HashTag> hts = repo.GetHashtags();
            Assert.AreEqual(10, hts.Count);
            TestPost = repo.GetAllPosts()[7];
            repo.SetPostLists(TestPost);
            Assert.AreEqual(2, TestPost.Hashtags.Count);
        }
        [Test]
        public void CanAddPostWithCats()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllPosts();
            List<Category> Cats = repo.GetAllCategories();
            TestPost.PostCategories = Cats;
            repo.CreatePost(TestPost);
            TestPost = repo.GetAllPosts()[9];
            List<Post> posts2 = repo.GetAllPosts();
            List<Category> Cats2 = repo.GetCategoryByPost(10);
            Assert.AreEqual(3, Cats2.Count);
        }
        [Test]
        [TestCase(1,2)]
        [TestCase(4,4)]
     
        public void CanFindNextPublished(int postid, int x)
        {
            PostRepo repo = new PostRepo();

            int next = repo.FindNextPublishedPost(postid);
            Assert.AreEqual(x, next);
        }
        [Test]
        [TestCase(2, 1)]
        [TestCase(1, 1)]
        [TestCase(4, 3)]
        public void CanFindPreviousPublishedPost(int postid, int x)
        {
            PostRepo repo = new PostRepo();
            int prev = repo.FindPreviousPublishedPost(postid);
            Assert.AreEqual(x, prev);
        }
        [Test]
        public void CanFindFirstPublishedpost()
        {
            PostRepo repo = new PostRepo();
            int first = repo.FindFirstPublishedPost();
            Assert.AreEqual(1, first);

        }
        [Test]
        public void CanFindLastPub()
        {
            PostRepo repo = new PostRepo();
            int last = repo.FindLastPublishedPost();
            Assert.AreEqual(4, last);
        }
        [Test]
        public void CanDeleteHashtag()
        {
            TestPost.HashtagInput = "#Test1,#Test2";
            PostRepo repo = new PostRepo();
            repo.CreatePost(TestPost);
            List<HashTag> hts = repo.GetHashtags();
            Assert.AreEqual(10, hts.Count);
            TestPost = repo.GetAllPosts()[7];
            repo.SetPostLists(TestPost);
            Assert.AreEqual(2, TestPost.Hashtags.Count);
            TestPost.HashtagInput = "#Test1";
            repo.SavePost(TestPost);
            TestPost = repo.GetAllPosts()[7];
            repo.SetPostLists(TestPost);
            Assert.AreEqual(1, TestPost.Hashtags.Count);

        }
        [Test]
        [TestCase("mo",3)]
        [TestCase("mont",1)]
        public void CanGetPostByTitleSearch(string input, int x)
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostsbyTitle(input);
            Assert.AreEqual(x, posts.Count);
        }
        [Test]
        [TestCase("mo", 2)]
        [TestCase("mont", 1)]
        public void CanGetPublishedPostByTitleSearch(string input, int x)
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPublishedPostByTitle(input);
            Assert.AreEqual(x, posts.Count);
        }
        [Test]
        public void CanGetAuthors()
        {
            PostRepo repo = new PostRepo();
            List<string> authors = repo.GetAllAuthors();
            Assert.AreEqual(4, authors.Count);
        }
        [Test]
        public void CanGetUnapprovedComments()
        {
            PostRepo repo = new PostRepo();
            List<Comment> comms = repo.GetUnapprovedComments();
            Assert.AreEqual(2, comms.Count);
        }
        [Test] 
        public void CanGetUnapprovedReplies()
        {
            PostRepo repo = new PostRepo();
            List<Reply> reps = repo.GetUnapprovedReplies();
            Assert.AreEqual(1, reps.Count);
        }
        [Test]
        public void CanGetPostForreview()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetPostForReview();
            Assert.AreEqual(1, posts.Count);
        }
        [Test]
        public void CanDeletePost()
        {
            PostRepo repo = new PostRepo();
            List<Post> posts = repo.GetAllPosts();
            Assert.AreEqual(9, posts.Count);
            repo.Deletepost(2);
            List<Post>posts2 = repo.GetAllPosts();
            Assert.AreEqual(3, posts2[1].PostId);
        }
        [Test]
        public void CanReviewPost()
        {
            PostRepo repo = new PostRepo();
            Post toreview = TestPost;
            repo.CreatePost(toreview);
            toreview.PostId = repo.GetAllPosts().Max(p => p.PostId);
            toreview.IsForReview = false;
            toreview.IsPublished = true;
            toreview.DisplayDate = DateTime.Parse("11/1/2017");
            repo.Review(toreview);
            int x = repo.GetAllPosts().Max(p => p.PostId);
            Post test = repo.GetPostDetails(x);
            Assert.AreEqual(true, repo.GetPostDetails(x).IsPublished);
            Assert.AreEqual(false, test.IsForReview);
            Assert.AreEqual("TestPost", test.PostTitle);
        }
        [Test]
        public void Expdateswork()
        {
            PostRepo repo = new PostRepo();
            List<Post> AllPost = repo.GetAllPosts();
            List<Post> NonExp = repo.GetPublishedPosts();
            Assert.AreEqual(9, AllPost.Count);
            Assert.IsTrue(AllPost.Count > NonExp.Count);
            Assert.AreEqual(5, NonExp.Count); //2 unpublished 1 expired 1 to pubublish on 12/1/2017
        }
    }
}

