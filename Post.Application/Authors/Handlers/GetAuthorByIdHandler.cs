using AutoMapper;
using MediatR;
using Post.Application.Authors.Queries.GetAuthorById;
using Post.Application.Authors.Queries.GetAuthors;
using Post.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorFake>
    {

        private readonly IAuthorRepository _authorRepository; 
        private readonly IMapper _mapper;
        public GetAuthorByIdHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorFake> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
           var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            return _mapper.Map<AuthorFake>(author);

        }
    }
}
