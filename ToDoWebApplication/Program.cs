using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ToDoWebApplication.Data;
using ToDoWebApplication.Extensions;
using ToDoWebApplication.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  
builder.Services.AddCustomExtension();
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"),
          builder =>
          {
              builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null);
              builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
          })
    );
             
builder.Services.AddAutoMapper(typeof(MappingProFile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
