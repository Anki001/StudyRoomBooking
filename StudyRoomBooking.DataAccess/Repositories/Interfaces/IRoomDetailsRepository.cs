using StudyRoomBooking.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositorys.Interfaces
{
    public interface IRoomDetailsRepository
    {
        Task<Room> GetRoomDetailsById(int Id);
    }
}
