using System;
using System.Collections.Generic;

namespace StudyRoomBooking.Core.FactoryService
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;



        public ServiceFactory( IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResponse ProcessService<TRequest,TResponse>(TRequest request) 
            where TRequest : class
            where TResponse : class
        {
            var service = (IServiceHandler<TRequest, TResponse>) _serviceProvider.GetService(typeof(IServiceHandler<TRequest,TResponse>));

            if(service == null)
            {
                throw new NotImplementedException($"No service register for this type : {nameof(TRequest)}");
            }
            return service.ExcecuteService(request); //iservice
        }

        
    }
}
