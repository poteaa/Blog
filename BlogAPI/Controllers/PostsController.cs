using AutoMapper;
using BlogAPI.Auth;
using BlogData;
using BlogData.Entities;
using BlogData.Enums;
using BlogData.Repositories;
using BlogModel.DTO;
using Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Writer, Editor")]
        [HttpGet, Route("api/Posts/PendingApproval")]
        public async Task<IEnumerable<Post>> GetPendingApprovalPosts()
        {
            IEnumerable<Post> posts;
            using (var unitOfWork = _unitOfWork)
            {
                var allPosts = await unitOfWork.Posts.GetPendingAprrovalPosts();
                posts = MapperConfig<PostEntity, Post>.MapIEnumerable(allPosts);
            }

            return posts;
        }

        public async Task<IEnumerable<Post>> GetApprovedPosts()
        {
            IEnumerable<Post> posts;
            using (var unitOfWork = _unitOfWork)
            {
                var allPosts = await unitOfWork.Posts.GetAll();
                posts = MapperConfig<PostEntity, Post>.MapIEnumerable(allPosts);
            }

            return posts;
        }

        [HttpPut, Route("api/Posts/{id}")]
        public async Task<IHttpActionResult> GetApprovedPost(int id)
        {
            Post post = null;
            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = await unitOfWork.Posts.GetAprrovedPost(id);
                post = MapperConfig<PostEntity, Post>.Map(postEntity);
            }

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Writer")]
        [HttpPost]
        public async Task<IHttpActionResult> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var unitOfWork = _unitOfWork)
            {
                post.PostStatusId = PostStatus.New;
                var postEntity = MapperConfig<Post, PostEntity>.Map(post);
                unitOfWork.Posts.Insert(postEntity);
                await unitOfWork.Commit();
                post.PostId = postEntity.PostId;
            }

            return CreatedAtRoute("DefaultApi", new { id = post.PostId }, post);
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Writer")]
        [HttpPut]
        public async Task<IHttpActionResult> EditPost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = MapperConfig<Post, PostEntity>.Map(post);
                unitOfWork.Posts.Update(postEntity);
                await unitOfWork.Commit();
            }

            return Ok(post);
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Editor")]
        [HttpDelete, Route("api/Posts/{id}")]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid post id");
            }
            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = await unitOfWork.Posts.GetById(id);
                if (postEntity == null)
                {
                    return NotFound();
                }
                unitOfWork.Posts.Delete(postEntity);
                await unitOfWork.Commit();
            }

            return Ok();
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Writer")]
        [HttpPut, Route("api/Posts/Submit")]
        public async Task<IHttpActionResult> SubmitPost([FromBody]int id)
        {
            Post post = null;
            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = await unitOfWork.Posts.GetById(id);
                if (postEntity == null)
                {
                    return NotFound();
                }
                postEntity.PostStatusId = (int)PostStatus.Submitted;
                unitOfWork.Posts.Update(postEntity);
                post = MapperConfig<PostEntity, Post>.Map(postEntity);
                await unitOfWork.Commit();
            }

            return Ok(post);
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Editor")]
        [HttpPut, Route("api/Posts/Approve")]
        public async Task<IHttpActionResult> ApprovePost([FromBody]int id)
        {
            Post post = null;
            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = await unitOfWork.Posts.GetById(id);
                if (postEntity == null)
                {
                    return NotFound();
                }
                postEntity.PostStatusId = (int)PostStatus.Approved;
                unitOfWork.Posts.Update(postEntity);
                post = MapperConfig<PostEntity, Post>.Map(postEntity);
                await unitOfWork.Commit();
            }

            return Ok(post);
        }

        [CustomAuthentication]
        [CustomAuthorize(Roles = "Editor")]
        [HttpPut, Route("api/Posts/Reject")]
        public async Task<IHttpActionResult> RejectPost([FromBody]int id)
        {
            Post post = null;
            using (var unitOfWork = _unitOfWork)
            {
                var postEntity = await unitOfWork.Posts.GetById(id);
                if (postEntity == null)
                {
                    return NotFound();
                }
                postEntity.PostStatusId = (int)PostStatus.Rejected;
                unitOfWork.Posts.Update(postEntity);
                post = MapperConfig<PostEntity, Post>.Map(postEntity);
                await unitOfWork.Commit();
            }

            return Ok(post);
        }


    }
}
