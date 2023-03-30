using Steeltoe.Connector.EFCore;
using Steeltoe.Connector.MySql.EFCore;
using Steeltoe.Common.Hosting;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.TaskCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddAllActuators();
builder.UseCloudHosting();
builder.AddCloudFoundryConfiguration();

var services = builder.Services;
services.AddDbContext<TodoContext>(options => options.UseMySql(builder.Configuration));
services.AddTask<MigrateDbContextTask<TodoContext>>(ServiceLifetime.Scoped);
services.ConfigureCloudFoundryOptions(builder.Configuration);
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.RunWithTasks();
