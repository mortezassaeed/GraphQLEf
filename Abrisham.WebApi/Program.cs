using Abrisham.Database;
using Abrisham.Graphql.Types;
using Abrisham.Graphql.Types.Platform;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Abrisham.DataAccess.Interface;
using Abrisham.Common.Models;
using Abrisham.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Abrisham.WebApi", Version = "v1" });
});
builder.Services.AddControllers();
//builder.Services.AddEntityFrameworkSqlServer();

builder.Services.AddPooledDbContextFactory<AbrishamDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Abrisham")));
//builder.Services.AddPooledDbContextFactory<AbrishamDbContext>((serviceProvider, optionsBuilder) =>
//{
//    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Abrisham"));
//    optionsBuilder.UseInternalServiceProvider(serviceProvider);
//});

builder.Services.AddScoped<IRepository<Platform>, PlatformRepository>();
builder.Services.AddScoped<IRepository<Command>, CommandRepository>();
builder.Services.AddScoped<IRepository<Result>, ResultRepository>();
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddType<ResultType>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Abrisham.WebApi v1"));
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.MapGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"

});

app.Run();
