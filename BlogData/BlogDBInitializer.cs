using BlogData.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogData
{
    public class BlogDBInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var writerRole = new RoleEntity
            {
                Name = "Writer",
            };
            var editorRole = new RoleEntity
            {
                Name = "Editor",
            };
            var roles = new List<RoleEntity>
            {
                writerRole,
                editorRole
            };

            var users = new List<UserEntity>
            {
                new UserEntity
                {
                    FirstName = "Writer",
                    LastName = "User",
                    Username = "Writer",
                    Password = "12345",
                    Role = writerRole
                },
                new UserEntity
                {
                    FirstName = "Editor",
                    LastName = "User",
                    Username = "Editor",
                    Password = "12345",
                    Role =  editorRole
                }
            };

            var status = new List<PostStatusEntity>
            {
                new PostStatusEntity
                {
                    PostStatusId = 0,
                    Name = "New"
                },
                new PostStatusEntity
                {
                    PostStatusId = 1,
                    Name = "Submitted"
                },
                new PostStatusEntity
                {
                    PostStatusId = 2,
                    Name = "Approved"
                },
                new PostStatusEntity
                {
                    PostStatusId = 1,
                    Name = "Rejected"
                }
            };

            context.Roles.AddRange(roles);
            context.Users.AddRange(users);
            context.PostStatus.AddRange(status);

            base.Seed(context);
        }
    }
}
