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

        TResponse ProcessService<TRequest, TResponse>(TRequest request) //roomservice .
             where TRequest : class
             where TResponse : class;
    }
}
