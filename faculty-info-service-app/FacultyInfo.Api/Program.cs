using FacultyInfo.Api.Extensions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

// Swagger configuration
builder.Services.AddSwaggerServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(configureOptions =>
{
    configureOptions.SwaggerEndpoint("/swagger/FacultyInfoOpenAPISpecification/swagger.json", "Faculty Info WebAPI V1");
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
