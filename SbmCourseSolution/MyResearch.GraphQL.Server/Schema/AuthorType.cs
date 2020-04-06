using HotChocolate.Types;
using MyResearch.GraphQL.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResearch.GraphQL.Server.Schema
{
    public class AuthorType : ObjectType<Author>
    {

        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(a => a.Name)
                .Type<NonNullType<StringType>>();

        }
    }
}
