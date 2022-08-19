using Adochat.Application;
using Adochat.Persistence;
using Adochat.WebApi.ServicesExtentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.SetupWebApi(builder.Configuration);
builder.Services.SetupCore(builder.Configuration);
builder.Services.SetupPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
