using StudyRoomBooking.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.DataAccess.Repositories.Interfaces
{
    public interface IRoomDetailsRepository
    {
        Task<StudyRoom> GetRoomDetailsById(int Id);
    }
}
