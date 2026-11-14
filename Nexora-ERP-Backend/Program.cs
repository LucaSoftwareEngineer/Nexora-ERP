using Microsoft.EntityFrameworkCore;
using Nexora_ERP_Backend.Models;
using Nexora_ERP_Backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DevAziendaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<IClientiRepository, ClientiRepository>();
builder.Services.AddScoped<IDipendentiRepository, DipendentiRepository>();
builder.Services.AddScoped<IFattureRepository, FattureRepository>();
builder.Services.AddScoped<IFornitoriRepository, FornitoriRepository>();
builder.Services.AddScoped<IMovimentiMagazzinoRepository, MovimentiMagazzinoRepository>();
builder.Services.AddScoped<IOrdiniRepository, OrdiniRepository>();
builder.Services.AddScoped<IPagamentiRepository, PagamentiRepository>();
builder.Services.AddScoped<IProdottiRepository, ProdottiRepository>();
builder.Services.AddScoped<IRepartiRepository, RepartiRepository>();
builder.Services.AddScoped<IRigheOrdineRepository, RigheOrdineRepository>();
builder.Services.AddScoped<IStoricoPrezziRepository, StoricoPrezziRepository>();
builder.Services.AddScoped<IUtentiRepository, UtentiRepository>();
builder.Services.AddScoped<IVwFatturatoMensileRepository, VwFatturatoMensileRepository>();
builder.Services.AddScoped<IVwOrdiniRiepilogoRepository, VwOrdiniRiepilogoRepository>();
builder.Services.AddScoped<IVwProdottiSottoScortumRepository, VwProdottiSottoScortumRepository>();
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
