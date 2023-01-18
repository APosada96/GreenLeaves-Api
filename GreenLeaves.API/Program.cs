using GreenLeaves.Domain.Models;
using GreenLeaves.Domain.Services;
using GreenLeaves.Domain.Services.Contracts;
using GreenLeaves.Infrastructure.GenericRepository;
using GreenLeaves.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericUnitOfWork), typeof(GenericUnitOfWork));
builder.Services.AddScoped(typeof(DbContext), typeof(GreenLeavesContext));
builder.Services.AddDbContext<GreenLeavesContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("GreenLeavesConnection")));
builder.Services.AddControllers();
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
app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("*"));
app.UseAuthorization();

app.MapControllers();

app.Run();
