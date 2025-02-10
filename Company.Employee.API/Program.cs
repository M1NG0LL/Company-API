using Company.Data;
using Company.Employee.API.Mappings;
using Company.Employee.API.Repositories;
using Company.Employee.API.Repositories.REmployee;
using Company.Employee.API.Repositories.RManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//builder.Services.AddOpenApi();


// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Company API", Version = "v1" });
});


// DbContexts
builder.Services.AddDbContext<EmployeeDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyEmployeeConnectionString")));


// Scopes
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
builder.Services.AddScoped<IManagerRepository, SQLManagerRepository>();


// Mapping Part
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
