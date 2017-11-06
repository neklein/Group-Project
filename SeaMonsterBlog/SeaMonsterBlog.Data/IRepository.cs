﻿using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Data
{
    public interface IRepository
    {
        void AddHashtags(string categoryinput, int PostID);
        void AddImage(string imageName);
        List<Hashtag> GetHashtags();
        void ApproveComment(int CommentID);
        void Approvepost(int postID);
        void ApproveReply(int ReplyID);
        void CreateComment(Comment comment);
        void CreateReply(Reply reply);
        List<Post> GetPublishedPostbyHashtag(int HashtagID);
        List<Post> GetPostbyHashtag(int HashtagID);
        List<Post> GetPostByCategory(int CatId);
        List<Post> GetPublishedPostByCategory(int CatId);
        List<Category> GetAllCategories();
        List<Image> GetAllImages();
        List<Post> GetAllPosts();
        List<Comment> GetAllComments(int postId);
        Comment GetCommentByCommentId(int commentId);
        List<Comment> GetPublishedComments(int PostID);
        List<Reply> GetAllReply(int commentId);
        List<Reply> GetPublishedReplies(int CommentID);
        Reply GetReplyByReplyId(int replyId);
        List<Hashtag> GetHashtagbyPost(int PostID);
        List<Category> GetCategoryByPost(int PostID);
        void SetPostLists(Post post);
        Post GetPostByID(int postID);
        List<Post> GetPublishedPosts();
        List<Post> GetAllStaticPublished();
        List<Post> GetAllStatic();
        void ADMINSetPostList(Post post); //May need the admin create method still
        int CreateNewPost(Post post);
        int CreatePostExpDate(Post post);
        int CreatePostDelayed(Post post);
        int CreatePostDelayedAndExp(Post post);
        void DeleteComment(int CommentID);
        void DeleteReply(int ReplyID);
        void SavePost(Post post);
        void ADMINSavePost(Post post);
        void SaveNewImage(string fileName);
        List<Post> GetAllPostByAuthor(string name);
        List<Post> GetPublishedPostbyAuthor(string name);
    }
}
