using SeaMonsterBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaMonsterBlog.UI.Controllers
{
    public class CommentController : ApiController
    {
        [Route("comment/{commentId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteComment(int commentId)
        {
            var repo = RepositoryFactory.GetRepository();
           repo.DeleteComment(commentId);
            return Ok();
        }

        [Route("reply/{replyId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteReply(int replyId)
        {
            var repo = RepositoryFactory.GetRepository();
           repo.DeleteReply(replyId);
            return Ok();
        }

        [Route("approveComment/{commentId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult ApproveComment(int commentId)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.ApproveComment(commentId);
            return Ok();
        }
        [Route("approveReply/{replyId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult ApproveReply(int replyId)
        {
            var repo = RepositoryFactory.GetRepository();
            repo.ApproveReply(replyId);
            return Ok();
        }

    }
}
