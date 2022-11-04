using GraphQLExcercise.API.Schema;
using GraphQLExcercise.API.Schema.Mutations;
using GraphQLExcercise.API.Schema.Queries;

namespace GraphQLExcercise.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
