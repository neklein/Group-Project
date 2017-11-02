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
        List<Comment> GetAllComments();
        List<Reply> GetAllReply();
        Post GetPostByID(int postID);
        int CreateNewPost(Post post);
        void SavePost(Post post);
        void SaveNewImage(string fileName);
    }
}
