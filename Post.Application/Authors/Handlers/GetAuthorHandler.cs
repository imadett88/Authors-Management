using AutoMapper;
using MediatR;
using Post.Application.Authors.Queries.GetAuthors;
using Post.Application.Posts.Queries.GetAuthor;
using Post.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Handlers
{
    // <request, response>  => <GetAuthorQuery,  List<AuthorFake>>
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuerys, List<AuthorFake>>
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        // Définition de la méthode Handle qui est une méthode asynchrone qui retourne une liste d'objets AuthorFake
        public async Task<List<AuthorFake>> Handle(GetAuthorQuerys request, CancellationToken cancellationToken)
        {
            // Appel asynchrone à la méthode GetAllAuthorAsync de l'objet _authorRepository
            // Cette méthode récupère tous les auteurs de la base de données
            var authors = await _authorRepository.GetAllAuthorAsync();

            // Utilisation de la méthode Select de LINQ pour transformer chaque auteur dans 'authors' en un nouvel objet AuthorFake
            // La méthode ToList est ensuite utilisée pour convertir le résultat en une liste
            //var listAuthor = authors.Select(x => new AuthorFake
            //{
            //    Id = x.Id,
            //    AuthorName = x.AuthorName,
            //    Description = x.Description,
            //    Post = x.Post
            //}).ToList();

            //// Retourne la liste d'objets AuthorFake
            //return listAuthor;

            // avec mapper :
            var listAuthor = _mapper.Map<List<AuthorFake>>(authors);
            return listAuthor;
        }

    }
}
