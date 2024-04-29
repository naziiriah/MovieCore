var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
    build => {
        build.AllowAnyOrigin() 
             .AllowAnyMethod() 
             .AllowAnyHeader();
    }
);

app.UseAuthorization();

app.MapControllers();

app.Run();
