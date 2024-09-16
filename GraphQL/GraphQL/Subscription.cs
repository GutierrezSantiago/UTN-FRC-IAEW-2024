using HotChocolate;
using HotChocolate.Types;
using OrderManager.Models;

namespace OrderManager.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public OrderManager OnOrderCreated([EventMessage] OrderManager order) => order;
    }
}