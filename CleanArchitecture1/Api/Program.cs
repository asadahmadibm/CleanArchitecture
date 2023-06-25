using Application.IRepository;
using Application.IService;
using Application.MediatR;
using Application.MediatR.Member;
using Application.Service;
using Infrastructure.DbContexts;
using Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(typeof(EmptyClassForAssemblyMediatr).GetTypeInfo().Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(TracingBehaviour<,>));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
