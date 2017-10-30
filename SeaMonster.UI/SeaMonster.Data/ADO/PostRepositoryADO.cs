using SeaMonster.Data.Interfaces;
using SeaMonster.Models.Tables;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Data.ADO
{
    public class PostRepositoryADO : IPostsRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            string cn = new

           return posts;
        }

    }
}
