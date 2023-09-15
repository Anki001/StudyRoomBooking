using StudyRoomBooking.Core.FactoryService;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess.Configuration;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddTransient<IServiceFactory, ServiceFactory>();


#region [DI registration: Self containt dependency injection]            

builder.Services
    .RegisterDataAccessServiceDependencies(builder.Configuration);

#endregion

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
