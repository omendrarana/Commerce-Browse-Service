using commercetools.Base.Client;
using commercetools.Sdk.Api;
using System.Reflection;
using Commerce.Browse.Service.Domain.Configurations;
using Commerce.Browse.Service.WebApi.Registration;

var builder = WebApplication.CreateBuilder(args);


var configuration = ServiceRegistrar.GetConfiguration(args);

// Add services to the container.
ServiceRegistrar.AddMediatRClasses(builder.Services, configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
      $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

//$"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
//builder.Services.AddGraphQL(b => b.AddSystemTextJson());


builder.Services.UseCommercetoolsApi(configuration, "Client");
var clientConfiguration = configuration.GetSection("Client").Get<ClientConfiguration>();
//builder.Services.AddApplicationInsightsTelemetry();
// TODO : Call Kevault
//Keyvault keyvault = new Keyvault();
//Settings.SetCurrentProjectKey(keyvault.GetKeyVaultDetails("ProjectKey").Result);
Settings.SetCurrentProjectKey(clientConfiguration.ProjectKey);

var app = builder.Build();

// Configure the HTTP request pipeline.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGraphQL("/graphql");

app.Run();
