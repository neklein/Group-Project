using SeaMonster.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Data_CLW
{
    public interface IPostRepo
    {
        List<Post> GetAllPosts();
        List<Post> GetPublishedPost();
        List<Comment> GetAllComments(int PostID);
        List<Comment> GetPublishedComments(int PostID);
        List<Reply> GetReplies(int CommentID);
        List<Reply> GetPublishedReplies(int CommentID);
        void Approvepost(int postID);
        void CreatePost(string PostTitle, string posttext);
        void CreatePost(string PostTitle, string posttext, DateTime expdate);
        void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate);
        void CreatePostDelayed(string PostTitle, string posttext, DateTime postdate, DateTime expdate);
        void ApproveComment(int CommentID);
        void ApproveReply(int ReplyID);
        void CreateComment(int postId, string commenterName, string commentText);
        void CreateReply(int commentId, string replyName, string replyText);
        void DeleteComment(int CommmentID);
        void DeleteReply(int ReplyID);
        void AddHashtags(string catagoryinput, int PostID);
        List<HashTag> GetHashtags();
        List<Post> GetPostsByCategory(int CategoryID);
        List<Post> GetPostByHashtag(int HashtagID);
        List<Post> GetAllStaticPublished();
        List<Post> GetAllStatic();
        void SetPostLists(Post post);
        List<Category> GetAllCategories();
        List<HashTag> GetHashtagbyPost(int PostID);
        List<Category> GetCategoryByPost(int PostID);
        List<Comment> GetCommentsbyPost(int PostId);
        void AddImage(string imageName);
        List<Image> GetImagesByPost(int postId);
    }
}
