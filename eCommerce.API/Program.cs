using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.DTO;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controller to service collection
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(
    typeof(ApplicationUserMappingProfile).Assembly);

//To build web application
var app = builder.Build();

//Middlewares
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
