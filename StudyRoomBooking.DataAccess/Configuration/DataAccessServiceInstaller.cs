using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.DataAccess.Repositories;

namespace StudyRoomBooking.DataAccess.Configuration
{
    public static class DataAccessServiceInstaller
    {
        public static IServiceCollection RegisterDataAccessServiceDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region[In case of multitenant application, this can be move to Middleware or UnitOfWork]

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
            );

            #endregion
      
            // Register dependency of StudyRoomBooking.DataAccess
            services.AddScoped<IBookingDetailsRepository,BookingDetailsRepository>();
            services.AddTransient<IStudyRoomRepository, StudyRoomRepository>();

            services.AddTransient<StudyRoomRepository>();
       
            return services;
        }
    }
}
