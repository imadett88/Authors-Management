using Post.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post.Application.Common.Mappings;


namespace Post.Application.Authors.Queries.GetAuthors
{
    public class AuthorFake : IMapFrom<Author>
    {

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Post { get; set; }
        
    }
}
