using GraphQLExcercise.API.Schema;
using GraphQLExcercise.API.Schema.Mutations;
using GraphQLExcercise.API.Schema.Queries;
using GraphQLExcercise.API.Schema.Subscriptions;

namespace GraphQLExcercise.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

            services.AddInMemorySubscriptions();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
