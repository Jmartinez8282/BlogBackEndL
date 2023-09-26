using BlogBackEndL.Services;
using BlogBackEndL.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BlogitemService>();
builder.Services.AddScoped<PasswordService>();

var connectionString = builder.Configuration.GetConnectionString("MyblogString");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));


//CORS Policy

builder.Services.AddCors(options => {
    options.AddPolicy("BlogPolicy",
    builder => {
        builder.WithOrigins("http://127.0.0.1:5173/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("BlogPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
