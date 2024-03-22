using Post.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
