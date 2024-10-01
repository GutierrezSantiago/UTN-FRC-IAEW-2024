using HotChocolate.Types;
using SpotifyGraphQLBFF.Models;

namespace SpotifyGraphQLBFF.GraphQL.Types
{
    public class ArtistType : ObjectType<Artist>
    {
        protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
        {
            descriptor.Field(a => a.Id).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Genres).Type<ListType<StringType>>();
            descriptor.Field(a => a.Images).Type<ListType<ImageType>>();
        }
    }
}