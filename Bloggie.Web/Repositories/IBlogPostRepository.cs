using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostRepository
    {

        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost?> GetByUrlHAndleAsync(string urlHandle);
        Task<BlogPost>AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);  

        Task<BlogPost?> DeleteAsync(Guid id);
        //Task<string?> GetAllAsync();
    }
}
