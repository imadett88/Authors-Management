using Microsoft.EntityFrameworkCore;
using Post.Domain.Entity;
using Post.Domain.Repository;
using Post.Infrastructure.Data;


namespace Post.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDbContext _authorDbContext;

        public AuthorRepository(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _authorDbContext.Authors.AddAsync(author);
            await _authorDbContext.SaveChangesAsync();
            return author;
        }

        public async Task<int> DeleteAsync(int id)
        {  // author => model id the code not work
            return await _authorDbContext.Authors
                .Where(author => author.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Author>> GetAllAuthorAsync()
        {
            return await _authorDbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _authorDbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Author author)
        {
            return await _authorDbContext.Authors
                .Where(author => author.Id == id)
                .ExecuteUpdateAsync(setr => setr
                  .SetProperty(a => a.Id, author.Id)
                  .SetProperty(a => a.AuthorName, author.AuthorName)
                  .SetProperty(a => a.Description, author.Description)
                  .SetProperty(a => a.Post, author.Post)
                  );
        }
    }
}
