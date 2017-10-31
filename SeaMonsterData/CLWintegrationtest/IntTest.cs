﻿using NUnit.Framework;
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

      [Test]
      public void CanLoadCategories()
        {
            PostRepo repo = new PostRepo();
            List<Category> Cats = repo.GetCategories();
            Assert.IsNotNull(Cats);
            Assert.AreEqual(8, Cats.Count());
        }

        [Test]
        [TestCase("#Excited,#Scared",5,8)]
        [TestCase("#Excited,  #Scared", 5, 8)]
        public void CanResuseCategory(string test, int postID, int expected)
        {
            PostRepo repo = new PostRepo();
            repo.AddCategoryTags(test, postID);
            List<Category> Cats = repo.GetCategories();
            Assert.AreEqual(expected, Cats.Count());
        }

        [Test]
        [TestCase("#New #ShouldWork",5,10)]
        public void CanAddNewCat(string test, int postID, int expected)
        {
            PostRepo repo = new PostRepo();
            repo.AddCategoryTags(test, postID);
            List<Category> Cats = repo.GetCategories();
            Assert.AreEqual(expected, Cats.Count());
        }



    }
}
