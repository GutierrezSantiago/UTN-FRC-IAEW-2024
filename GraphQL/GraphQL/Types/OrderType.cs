using HotChocolate.Types;
using OrderManager.Models;

namespace OrderManager.GraphQL.Types
{
    public class ProductType : ObjetctType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Description("Representa una orden en el sistema.");

            descriptor.Field(o => o.Id).Description("Identificador único de la orden.");

            descriptor.Field(o => o.Customer).Description("Cliente que realizó la orden.").Type<CustomerType>();

            descriptor.Field(o => o.Products).Description("Lista de productos incluidos en la orden.").Type<ListType<ProductType>>();

        }
    }
}