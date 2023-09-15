using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyRoomBooking.Core.Services;

namespace StudyRoomBooking.Core.FactoryService
{
    public interface IServiceFactory
    {
        IRoomService CreateRoomService();
    }
}
