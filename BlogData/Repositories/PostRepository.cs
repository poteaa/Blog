using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogData.Entities;
using BlogData.Enums;

namespace BlogData.Repositories
{
    public class PostRepository : Repository<PostEntity>, IPostRepository
    {
        private IBlogContext _context;
        public PostRepository(IBlogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostEntity>> GetPendingAprrovalPosts()
        {
            return await _context.Posts
                .Where(p => p.PostStatusId == (int)PostStatus.New || p.PostStatusId == (int)PostStatus.Rejected)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAprrovedPosts()
        {
            return await _context.Posts.Where(p => p.PostStatusId == (int)PostStatus.Approved).ToListAsync();
        }

        public async Task<PostEntity> GetAprrovedPost(int id)
        {
            return await _context.Posts.Where(p => p.PostStatusId == (int)PostStatus.Approved).FirstOrDefaultAsync();
        }
    }
}
