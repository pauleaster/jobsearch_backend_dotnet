using Jobsearch_backend.Data;
using Jobsearch_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Configure DbContext
builder.Services.AddDbContext<JobsearchDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Set up CORS for http://localhost:3001 and https://localhost:3002
// Define CORS policies
builder.Services.AddCors(options =>
{
    // Development CORS policy
    options.AddPolicy("DevelopmentCorsPolicy",
        builder => builder //.WithOrigins("http://localhost:3001", "https://localhost:3002")
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
                          //.AllowCredentials());

    // Production CORS policy (more restrictive)
    options.AddPolicy("ProductionCorsPolicy",
        builder => builder.WithOrigins("https://yourproductiondomain.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Register your custom service
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ISearchTermService, SearchTermService>();
builder.Services.AddScoped<IJobSearchTermService, JobSearchTermService>();
builder.Services.AddScoped<IValidJobSearchTermsService, ValidJobSearchTermsService>();

// Make sure that JSON uses Netwonsoft.Json
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("DevelopmentCorsPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseCors("ProductionCorsPolicy");
    // Configure production-specific middleware, if any
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
