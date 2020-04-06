using HotChocolate;
using Microsoft.EntityFrameworkCore;
using MyResearch.GraphQL.Server.Data;
using MyResearch.GraphQL.Server.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.GraphQL.Server.Schema
{
    public class Query
    {
        public async Task<IReadOnlyList<Author>> GetAuthors([Service] DomainDbContext dbContext)
        {
            //return await dbContext.Authors.ToListAsync();
            var data = new List<Author>
            {
                new Author {id= "1",Name="X"},
                new Author {id= "2",Name="Y"} };

            return data.ToList();
        }

        public async Task<Author> GetAuthor([Service] DomainDbContext dbContext, string id)
        {
            return new Author
            {
                id = id,
                Name = "Z"

            };
        }
    }
}
