using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyRoomBooking.DataAccess.Configuration
{
    public static class DataAccessServiceInstaller
    {
        public static IServiceCollection RegisterDataAccessServiceDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region[In case of multitenant application, this can be move to Middleware or UnitOfWork]

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            #endregion

            // Register dependency of StudyRoomBooking.DataAccess

            return services;
        }
    }
}
