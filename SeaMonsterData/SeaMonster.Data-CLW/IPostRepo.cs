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
        List<Post> GetAllPost();
        List<Post> GetPublishefPost();
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
        void Createcomment();
        void CreateReply();
        void DeleteComment(int CommmentID);
        void DeleteReply(int ReplyID);
        List<string> GetCategoryTags();
    }
}
