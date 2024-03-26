using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand :IRequest<int>
    {
        public int Id { get; set; }
    }
}
