using NUnit.Framework;
using SeaMonster.Data_CLW;
using SeaMonster.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NateTests
{
    [TestFixture]
    public class NateIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            using (SqlConnection cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("MosterDBRest", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void TestGetUnapprovedComments()
        {
            List<Comment> comm = new List<Comment>();
            using (var cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Comment where PostID = @PostId AND IsShown=0", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PostId", 2);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Comment comment = new Comment();

                        comment.PostId = (int)dr["PostID"];
                        comment.CommentId = (int)dr["CommentID"];
                        comment.CommenterName = dr["CommenterName"].ToString();
                        comment.CommentDate = DateTime.Parse(dr["CommentDate"].ToString());
                        comment.CommentText = dr["CommentText"].ToString();
                        comment.IsShown = (bool)dr["IsShown"];
                        comm.Add(comment);
                    }
                }

            }

            Assert.AreEqual(1, comm.Count());
            Assert.AreEqual(3, comm[0].CommentId);
            Assert.AreEqual("Skeptic-Hal", comm[0].CommenterName);
        }

        [Test]
        public void TestGetUnapprovedReplies()
        {
            List<Reply> reps = new List<Reply>();
            using (var cn = new SqlConnection("Server=localhost;Database=SeaMonster;User Id=SeamonsterSA; Password=ocean;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * " +
                    "FROM Reply r " +
                    "INNER JOIN Comment c ON r.CommentID = c. CommentID" +
                    " WHERE c.PostId = @PostId AND r.IsShown=0", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PostId", 1);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Reply reply = new Reply();
                        reply.ReplyID = (int)dr["ReplyId"];
                        reply.ReplyName = dr["ReplyName"].ToString();
                        reply.ReplyDate = DateTime.Parse(dr["ReplyDate"].ToString());
                        reply.ReplyText = dr["ReplyText"].ToString();
                        reply.IsShown = (bool)dr["IsShown"];

                        reps.Add(reply);
                    }
                }

            }

            Assert.AreEqual(0, reps.Count());
        }

    }
}
