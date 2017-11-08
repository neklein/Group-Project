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
        [Route("comment/{postId}/{commentId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteComment(int postId, int commentId)
        {
            return Ok();
        }

        [Route("comment/{postId}/{commentId}/{replyId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteReply(int postId, int commentId, int replyId)
        {
            return Ok();
        }
    }
}
