using System.Collections.Generic;
using System.Threading.Tasks;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.Core.Services
{
    public interface IRoomService 
    {
       Task<IEnumerable<Room>> ExecuteService();
    }
}
