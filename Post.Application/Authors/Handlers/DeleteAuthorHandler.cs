using AutoMapper;
using MediatR;
using Post.Application.Authors.Commands.DeleteAuthor;
using Post.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Handlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<int> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorRepository.DeleteAsync(request.Id);

        }
    }
}
