using AutoMapper;
using MediatR;
using Post.Application.Authors.Commands.UpdateAuthor;
using Post.Domain.Entity;
using Post.Domain.Repository;


namespace Post.Application.Authors.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = new Author()
            {
                Id = request.Id,
                AuthorName = request.AuthorName,
                Description = request.Description,
                Post = request.Post,
            };
            return await _authorRepository.UpdateAsync(request.Id, authorEntity);
        }
    }
}
