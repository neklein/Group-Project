using SeaMonster.Models.Tables;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Comment> GetPublishedComments(int PostID)
        {
            throw new NotImplementedException();
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
        public List<string> GetCategoryTags()
        {

        }
    }
}
