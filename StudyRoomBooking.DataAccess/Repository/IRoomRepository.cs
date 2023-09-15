using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyRoomBooking.Models;

namespace StudyRoomBooking.DataAccess.Repository
{
    public interface IRoomRepository
    {
     Task<IEnumerable<Room>> GetRoomsAsyncData();
    }
}
