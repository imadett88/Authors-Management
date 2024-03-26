using MediatR;
using Post.Application.Authors.Queries.GetAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<AuthorFake>
    {
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Post { get; set; }
    }
}
