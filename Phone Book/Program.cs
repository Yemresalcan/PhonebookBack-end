using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy(name: "MyPolicy", policy =>
//    {
//        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();


//    });


//});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors( builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod() );

app.Run();





