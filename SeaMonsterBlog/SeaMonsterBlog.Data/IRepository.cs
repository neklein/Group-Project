using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Data
{
    public interface IRepository
    {
        List<Category> GetAllCategories();
        List<Image> GetAllImages();
        List<Post> GetAllPosts();
        //Update the below with postId
        List<Comment> GetAllComments(int postId);
        List<Reply> GetAllReply(int commentId);
        Post GetPostByID(int postID);
        int CreateNewPost(Post post);
        void SavePost(Post post);
        void SaveNewImage(string fileName);
    }
}
