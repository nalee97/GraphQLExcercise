global using GraphQLExcercise.API;
global using GraphQLExcercise.API.Schema;
global using GraphQLExcercise.API.Schema.Mutations;
global using GraphQLExcercise.API.Schema.Queries;
global using GraphQLExcercise.API.Schema.Subscriptions;
global using GraphQLExcercise.API.Services;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();



builder.Services.AddGraphQLServer().AddQueryType<Query>();

builder.Services.AddGraphQLServer().AddMutationType<Mutation>();

builder.Services.AddGraphQLServer().AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();


builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


/*
namespace GraphQLExcercise.API
{
    
   

   
    
    public class Program
    {
        public readonly IConfiguration _configuration;

        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer().AddQueryType<Query>();
            services.AddGraphQLServer().AddMutationType<Mutation>();
            services.AddGraphQLServer().AddSubscriptionType<Subscription>();

            services.AddInMemorySubscriptions();

            string connectionString = _configuration.GetConnectionString("default");
            services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));

        }
    }
    
}
*/





/*
builder.Services.AddDbContext<SchoolDbContext>(options =>
options.UseSqlite(configuration.GetConnectionString("SqlServer")));
*/

app.UseRouting();

app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();







