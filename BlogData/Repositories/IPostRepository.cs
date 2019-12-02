using BlogData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogData.Repositories
{
    public interface IPostRepository : IRepository<PostEntity>
    {
        Task<IEnumerable<PostEntity>> GetAprrovedPosts();
        Task<IEnumerable<PostEntity>> GetPendingAprrovalPosts();
        Task<PostEntity> GetAprrovedPost(int id);
    }
}
