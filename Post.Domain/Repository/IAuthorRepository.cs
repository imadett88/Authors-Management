using Post.Domain.Entity;


namespace Post.Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<int> UpdateAsync(int id, Author author);
        Task<int> DeleteAsync(int id);
    }
}
