using Microsoft.EntityFrameworkCore;
using Nexora_ERP_Backend.Models;
using Nexora_ERP_Backend.Repositories;
using Nexora_ERP_Backend.Services.Implementations;
using Nexora_ERP_Backend.Services.Interfaces;

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

builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IClientiService, ClientiService>();
builder.Services.AddScoped<IDipendentiService, DipendentiService>();
builder.Services.AddScoped<IFattureService, FattureService>();
builder.Services.AddScoped<IFornitoriService, FornitoriService>();
builder.Services.AddScoped<IMovimentiMagazzinoService, MovimentiMagazzinoService>();
builder.Services.AddScoped<IOrdiniService, OrdiniService>();
builder.Services.AddScoped<IPagamentiService, PagamentiService>();
builder.Services.AddScoped<IProdottiService, ProdottiService>();
builder.Services.AddScoped<IRepartiService, RepartiService>();
builder.Services.AddScoped<IRigheOrdineService, RigheOrdineService>();
builder.Services.AddScoped<IStoricoPrezziService, StoricoPrezziService>();
builder.Services.AddScoped<IUtentiService, UtentiService>();
builder.Services.AddScoped<IVwFatturatoMensileService, VwFatturatoMensileService>();
builder.Services.AddScoped<IVwOrdiniRiepilogoService, VwOrdiniRiepilogoService>();
builder.Services.AddScoped<IVwProdottiSottoScortumService, VwProdottiSottoScortumService>();

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
