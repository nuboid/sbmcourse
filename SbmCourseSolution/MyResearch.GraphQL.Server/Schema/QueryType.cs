using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.GraphQL.Server.Schema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetAuthors(default))
            .Type<NonNullType<ListType<NonNullType<AuthorType>>>>();

            descriptor.Field(q => q.GetAuthor(default,default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

        }
    }
}
