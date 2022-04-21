using Microsoft.AspNetCore.Mvc;
using BookApp.API.Middlewares;
using BookApp.Service;
using BookApp.Repository.Repositories;
using System.Data;
using Npgsql;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Özel Bir Exception Fýrlatmasý Ýçin Gerekli
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter=true;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// DI Container
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookCategoryRepository,BookCategoryRepository>();
builder.Services.AddScoped<IChapterRepository,ChapterRepository>();

builder.Services.AddScoped<IDbConnection>(sp =>new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreSql")));
builder.Services.AddScoped<IDbTransaction>(sp =>
{
    var connection = sp.GetRequiredService<IDbConnection>();
    connection.Open();
    return connection.BeginTransaction();
});
builder.Services.AddMediatR(typeof(ServiceAssembly));
builder.Services.AddAutoMapper(typeof(ServiceAssembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Özel Hatanýn Yapýsý

app.UseGlobalExceptionMiddleware();
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
