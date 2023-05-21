using RoomBookingSystem.Interfaces.Repository;

namespace RoomBookingSystem.Interfaces.Factories
{
    public interface IRoomBookingRepositoryFactory
    {
        IRoomBookingRepository GetRoomBookingDataReader();
    }

}
