using MediatR;
using Post.Application.Authors.Queries.GetAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorFake>
    {
        public int AuthorId { get; set; }
    }
}
