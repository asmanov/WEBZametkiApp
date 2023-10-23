using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WEBZametkiApp.BLL.Interfaces;
using WEBZametkiApp.BLL.Services;
using WEBZametkiApp.DAL.EF;
using WEBZametkiApp.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<NoteDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"), 
    x => x.MigrationsAssembly("WEBZametkiApp.WEB")));
//builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddScoped<IUnitOfWork, WEBZametkiApp.DAL.Repositories.EFUnitOfWork>();



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

app.Run();
