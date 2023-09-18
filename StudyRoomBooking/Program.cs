using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterDataAccessServiceDependencies(builder.Configuration);

builder.Services.AddTransient<IServiceFactory, ServiceHandlerFactory>();

Assembly.GetAssembly(typeof(ServiceHandlerFactory))
                       .GetTypes()
                       .Where(a => a.Name.EndsWith("ServiceHandler"))
                       .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                       .ToList()
                       .ForEach(typesToRegister =>
                       {
                           typesToRegister.serviceTypes.ForEach(typeToRegister => builder.Services.AddScoped(typeToRegister, typesToRegister.assignedType));
                       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
