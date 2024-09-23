using HotChocolate.Types;
using OrderManager.Models;

namespace OrderManager.GraphQL.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Description("Representa un cliente en el sistema.");

            descriptor.Field(c => c.Id).Description("Identificador único del cliente.");

            descriptor.Field(c => c.FullName).Description("Nombre completo del cliente.");
        }
    }
}