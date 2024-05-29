using FruitHub.Api.Config;
using FruitHub.Infra.Data;
using FruitHub.Infra.Data.Context;
using FruitHub.Infra.Data.Repository;
using FruitHub.Service.Interface;
using FruitHub.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Conection Database
 builder.Services.AddDbContext<MySqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
/*builder.Services.AddDbContext<MySqlContext>(options =>
            options.UseSqlServer("Data Source=PC-THIAGO; Initial Catalog=DbFruitHub; User Id=FruitHuUser;Integrated Security=False ;Password=123456; Connect Timeout=15; Encrypt=False; TrustServerCertificate=False"));
*/

//Mapper
var mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configuração Repository
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<IEstadoService, EstadoService>();

builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
builder.Services.AddTransient<ICidadeService, CidadeService>();


builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddTransient<IBaseRepository, BaseRepository>();




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
