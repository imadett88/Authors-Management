using MediatR;
using Post.Application.Authors.Queries.GetAuthors;


namespace Post.Application.Posts.Queries.GetAuthor
{
    public class GetAuthorQuerys : IRequest<List<AuthorFake>>
    {
        
    }

    //  public record GetAuthorQuery : IRequest<List<Author>>;
}
