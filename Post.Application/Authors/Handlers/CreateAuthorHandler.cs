using AutoMapper;
using MediatR;
using Post.Application.Authors.Commands.CreateAuthor;
using Post.Application.Authors.Queries.GetAuthors;
using Post.Domain.Entity;
using Post.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Handlers
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, AuthorFake>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public CreateAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorFake> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = new Author() { AuthorName = request.AuthorName, Description = request.Description, Post = request.Post };
            var result = await _authorRepository.CreateAsync(authorEntity);
             return _mapper.Map<AuthorFake>(result);

        }
    }
}
