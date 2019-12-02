using BlogData;
using BlogData.Entities;
using BlogData.Repositories;
using BlogModel.DTO;
using Helper;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlogAPI.Controllers
{
    public class CommentsController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> AddComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var unitOfWork = new UnitOfWork(new BlogContext()))
            {
                var commentEntity = MapperConfig<Comment, CommentEntity>.Map(comment);
                unitOfWork.Comments.Insert(commentEntity);
                comment.CommentId = commentEntity.CommentId;
                await unitOfWork.Commit();
            }

            return CreatedAtRoute("DefaultApi", new { id = comment.CommentId }, comment);
        }
    }
}
