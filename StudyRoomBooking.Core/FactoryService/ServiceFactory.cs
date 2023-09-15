using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.DataAccess;
using StudyRoomBooking.DataAccess.Repository;

namespace StudyRoomBooking.Core.FactoryService
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory( IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRoomService CreateRoomService()
        {
            var roomRepository = _serviceProvider.GetService<IRoomRepository>();
            return new RoomServiceImpl(roomRepository);
        }
    }
}
