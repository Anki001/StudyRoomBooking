using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRoomBooking.Core.FactoryService
{
    public interface IServiceHandler<TRequest, TResponse> 
        where TRequest : class
        where TResponse : class
    {
       TResponse ExcecuteService(TRequest request);
    }
}
