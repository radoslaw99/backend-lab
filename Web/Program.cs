using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Generators;
using Infrastructure.Memory.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IGenericRepository<Quiz, int>>(provider => 
    new MemoryGenericRepository<Quiz, int>(new IntGenerator()));
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>>(provider => 
    new MemoryGenericRepository<QuizItem, int>(new IntGenerator()));
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>>(provider => 
    new MemoryGenericRepository<QuizItemUserAnswer, string>());
builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Seed();
app.Run();