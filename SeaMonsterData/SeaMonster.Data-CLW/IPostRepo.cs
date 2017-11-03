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
        List<Post> GetPublishedPosts();
        List<Comment> GetAllComments(int PostID);
        List<Comment> GetPublishedComments(int PostID);
        List<Reply> GetReplies(int CommentID);
        List<Reply> GetPublishedReplies(int CommentID);
        void Approvepost(int postID);
        int CreatePost(string PostTitle, string posttext, string displayauthor, string displaydate);
        int CreatePost(string PostTitle, string posttext, string displayauthor, DateTime displaydate, DateTime expdate);
        int CreatePostDelayed(string PostTitle, string posttext, string displayauthor, DateTime displaydate, DateTime postdate);
        int CreatePostDelayed(string PostTitle, string posttext, DateTime postdate, string displayauthor, DateTime displaydate, DateTime expdate);
        void ApproveComment(int CommentID);
        void ApproveReply(int ReplyID);
        void CreateComment(int postId, string commenterName, string commentText);
        void CreateReply(int commentId, string replyName, string replyText);
        void DeleteComment(int CommmentID);
        void DeleteReply(int ReplyID);
        void AddHashtags(string catagoryinput, int PostID);
        List<HashTag> GetHashtags();
        List<Post> GetAllStaticPublished();
        List<Post> GetAllStatic();
        void SetPostLists(Post post);
        List<Category> GetAllCategories();
        List<HashTag> GetHashtagbyPost(int PostID);
        List<Category> GetCategoryByPost(int PostID);
        List<Comment> GetCommentsbyPost(int PostId);
        void ADMINSetPostList(Post post);
        List<Post> GetPublishedPostbyHashtag(int HashtagID);
        List<Post> GetPostbyHashtag(int HashtagID);
        List<Post> GetPostByCategory(int CatId);
        List<Post> GetPublishedPostByCategory(int CatId);
        void AddImage(string imageName);
        List<Image> GetImagesByPost(int postId);
        Comment GetCommentByCommentId(int commentId);
        Reply GetReplyByReplyId(int replyId);
        List<Post> GetAllPostByAuthor(string name);
        Category GetCategoryByCatID(int CatID);
        void SavePost();
        List<Post> GetPublishedPostbyAuthor(string name);
        Category GetCategoryByCatName(string name);


    }
}
