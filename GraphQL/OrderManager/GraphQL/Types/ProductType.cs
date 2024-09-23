using HotChocolate.Types;
using OrderManager.Models;

namespace OrderManager.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Representa un producto en el sistema.");

            descriptor.Field(p => p.Id).Description("Identificador único del producto.");

            descriptor.Field(p => p.Name).Description("Nombre del producto.");
        }
    }
}
    