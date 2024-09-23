using HotChocolate;
using HotChocolate.Types;
using OrderManager.Models;

namespace OrderManager.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Order OnOrderCreated([EventMessage] Order order) => order;
    }
}