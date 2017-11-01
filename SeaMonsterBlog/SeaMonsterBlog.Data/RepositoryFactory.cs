using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Data
{
    public static class RepositoryFactory
    {
        static IRepository _mock = new MockRepository();
        public static IRepository GetRepository()
        {
            string repositoryType = ConfigurationManager.AppSettings["RepositoryType"].ToString();
            switch (repositoryType)
            {
                case "QA":
                    return _mock;
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
