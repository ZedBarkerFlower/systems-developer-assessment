using NetC.DeveloperExam.WebCore.Models;
using NetC.DeveloperExam.WebCore.Models.Forms;
using Newtonsoft.Json;
using System.Linq;

namespace NetC.DeveloperExam.WebCore.Services
{
    public class BlogService
    {
        public BlogPost? GetBlog(int blogId)
        {
            if (blogId == default)
            {
                return null;
            }

            var blogs = GetAllBlogs();
            if (blogs?.BlogPosts?.Any() != true)
            {
                return null;
            }

            var ourBlog = blogs.BlogPosts.FirstOrDefault(x => x.Id == blogId);
            if (ourBlog == null)
            {
                return null;
            }

            return ourBlog;
        }

        public bool AddComment(CommentModel model)
        {
            if (model.BlogId == default)
            {
                return false;
            }

            var blogs = GetAllBlogs();
            if (blogs?.BlogPosts?.Any() != true)
            {
                return false;
            }

            var ourBlog = blogs.BlogPosts.FirstOrDefault(x => x.Id == model.BlogId);
            if (ourBlog == null)
            {
                return false;
            }

            ourBlog.Comments ??= [];
            ourBlog.Comments.Add(new Comment
            {
                Name = model.Name,
                EmailAddress = model.Email,
                Date = DateTime.Now,
                Message = model.Message
            });

            var test = JsonConvert.SerializeObject(blogs);
            using StreamWriter w = new("App_Data/Blog-Posts.json", false);
            w.Write(test);

            return true;
        }

        public bool AddCommentReply(ReplyCommentModel model)
        {
            if (model.BlogId == default 
                || model.CommentNumber == default)
            {
                return false;
            }

            var blogs = GetAllBlogs();
            if (blogs?.BlogPosts?.Any() != true)
            {
                return false;
            }

            var ourBlog = blogs.BlogPosts.FirstOrDefault(x => x.Id == model.BlogId);
            if (ourBlog == null)
            {
                return false;
            }

            var ourComment = ourBlog
                .Comments
                ?.Skip(model.CommentNumber - 1)
                .FirstOrDefault();
            if (ourComment == null)
            {
                return false;
            }

            ourComment.Replies ??= [];
            ourComment.Replies.Add(new BaseComment
            {
                Name = model.Name,
                EmailAddress = model.Email,
                Date = DateTime.Now,
                Message = model.Message
            });

            using StreamWriter w = new("App_Data/Blog-Posts.json", false);
            w.Write(JsonConvert.SerializeObject(blogs));

            return true;
        }

        private static BlogRoot? GetAllBlogs()
        {
            using StreamReader r = new("App_Data/Blog-Posts.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<BlogRoot>(json);
        }
    }
}
