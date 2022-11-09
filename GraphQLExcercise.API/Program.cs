using GraphQLExcercise.API;
using GraphQLExcercise.API.Schema;
using GraphQLExcercise.API.Schema.Mutations;
using GraphQLExcercise.API.Schema.Queries;
using GraphQLExcercise.API.Schema.Subscriptions;
using GraphQLExcercise.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();

builder.Services.AddGraphQLServer().AddMutationType<Mutation>();

builder.Services.AddGraphQLServer().AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

/*
builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

/*
builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(configuration.GetConnectionString("SqlServer")));
*/

/*
string connectionString = _configuration.GetConnectionString("default");
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));
*/

var app = builder.Build();
app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();


