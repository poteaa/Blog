using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogData.Entities;

namespace BlogData.Repositories
{
    internal class CommentRepository : Repository<CommentEntity>, ICommentRepository
    {
        private IBlogContext _context;
        public CommentRepository(IBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
