﻿using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Repository;
using StudyRoomBooking.Models.Messages.Request;
using StudyRoomBooking.Models.Messages.Response;

namespace StudyRoomBooking.Core.Services
{
    public class RoomServiceHandler : IServiceHandler<EmptyRequest, StudyRoomResponse>
    {
       public readonly IStudyRoomRepository _roomRepository;
        public RoomServiceHandler(IStudyRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public StudyRoomResponse ExcecuteService(EmptyRequest request)
        {
           return _roomRepository.GetRooms();
        }
    }
}
