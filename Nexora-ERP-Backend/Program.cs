using Microsoft.EntityFrameworkCore;
using Nexora_ERP_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DevAziendaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
