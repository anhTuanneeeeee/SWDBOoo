using BOs.Models;
using DAOs;
using Microsoft.EntityFrameworkCore;
using REPOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add


builder.Services.AddDbContext<BookroomContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<BookroomContext>();
builder.Services.AddScoped<AccountDAO>();
builder.Services.AddScoped<IAccountRepo, AccountRepository>();
builder.Services.AddScoped<RoomDAO>();
builder.Services.AddScoped<RoomRepository>();

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
