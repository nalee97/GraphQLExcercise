using GraphQLExcercise.API;
using GraphQLExcercise.API.Schema;
using GraphQLExcercise.API.Schema.Queries;
using GraphQLExcercise.API.Schema.Mutations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();


