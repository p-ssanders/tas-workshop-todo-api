using Steeltoe.Connector.EFCore;
using Steeltoe.Connector.MySql.EFCore;
using Steeltoe.Management.TaskCore;

using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(options => options.UseMySql(builder.Configuration));
builder.Services.AddTask<MigrateDbContextTask<TodoContext>>(ServiceLifetime.Scoped);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.RunWithTasks();
