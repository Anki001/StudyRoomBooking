namespace StudyRoomBooking.Core.Services.Interfaces
{
    public interface IServiceHandler<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        TResponse ExcecuteService(TRequest request); //now we know type of service
    }
}
