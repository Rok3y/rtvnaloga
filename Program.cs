using Microsoft.EntityFrameworkCore;
using rtvnaloga.Data;
using rtvnaloga.Services;

var builder = WebApplication.CreateBuilder(args);

// Connect to the database
var usedConnectionKey = builder.Configuration["ConnectionStrings:UsedDbConnection"];
if (usedConnectionKey == null )
{
    throw new ArgumentException("Connection string not found!");
}
var usedConnectionString = builder.Configuration.GetConnectionString(usedConnectionKey);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(usedConnectionString));


// Add services to the container.

builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddScoped<IAccountHeaderRepository, AccountHeaderRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost55522", policy =>
    {
        policy.WithOrigins("http://localhost:55522")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost55522");

app.UseAuthorization();

app.MapControllers();

app.Run();
