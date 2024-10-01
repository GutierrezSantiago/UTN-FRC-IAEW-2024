using HotChocolate.Types;
using SpotifyGraphQLBFF.Models;

namespace SpotifyGraphQLBFF.GraphQL.Types
{
    public class ImageType : ObjectType<Image>
    {
        protected override void Configure(IObjectTypeDescriptor<Image> descriptor)
        {
            descriptor.Field(i => i.Height).Type<NonNullType<IntType>>();
            descriptor.Field(i => i.Url).Type<NonNullType<StringType>>();
            descriptor.Field(i => i.Width).Type<NonNullType<IntType>>();
        }
    }
}