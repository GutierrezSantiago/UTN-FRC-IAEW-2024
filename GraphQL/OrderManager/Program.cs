using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.GraphQL;
using OrderManager.GraphQL.Types;
using HotChocolate.AspNetCore.Voyager;
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<CustomerType>()
    .AddType<OrderType>()
    .AddType<ProductType>()
    .AddInMemorySubscriptions()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails =
    true);

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();

// Agregar Voyager para explorar el esquema
app.UseVoyager("/graphql", "/voyager");

app.Run();
