using BlogData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest
{
    public class RepositoryMock
    {
        public static List<CommentEntity> Comments => new List<CommentEntity>
        {
            new CommentEntity
            {
                CommentId = 1,
                Content = "Good post man!!!"
            },
            new CommentEntity
            {
                CommentId = 2,
                Content = "Hello"
            }
        };

        public static List<PostEntity> Posts => new List<PostEntity>
        {
            new PostEntity
            {
                PostId = 1,
                Title = "My first post",
                PostStatusId = 1,
                Comments = Comments
            },
            new PostEntity
            {
                PostId = 2,
                Title = "The best post",
                PostStatusId = 0
            }
        };
    }
}
