using GraphQLExcercise.API;
using GraphQLExcercise.API.Schema;
using GraphQLExcercise.API.Schema.Mutations;
using GraphQLExcercise.API.Schema.Queries;
using GraphQLExcercise.API.Schema.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();

builder.Services.AddGraphQLServer().AddMutationType<Mutation>();

builder.Services.AddGraphQLServer().AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();
app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();


