using BlogData.Entities;
using System.Data.Entity;

namespace BlogData
{
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext() : base("BlogContext")
        {
            Database.SetInitializer<BlogContext>(new BlogDBInitializer());
        }

        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<PostStatusEntity> PostStatus { get; set; }
    }
}
