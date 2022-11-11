 using GraphQLExcercise.API;
 using GraphQLExcercise.API.Schema;
 using GraphQLExcercise.API.Schema.Mutations;
 using GraphQLExcercise.API.Schema.Queries;
 using GraphQLExcercise.API.Schema.Subscriptions;
 using GraphQLExcercise.API.Services;
 using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();



builder.Services.AddGraphQLServer().AddQueryType<Query>();

builder.Services.AddGraphQLServer().AddMutationType<Mutation>();

builder.Services.AddGraphQLServer().AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

/*
builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();







/*
builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(configuration.GetConnectionString("SqlServer")));
*/







