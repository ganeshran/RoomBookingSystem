using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Factories;
using RoomBookingSystem.Interfaces.Repository;
using RoomBookingSystem.Repositories;

namespace RoomBookingSystem.Services.Factories
{

    public class RoomBookingRepositoryFactory : IRoomBookingRepositoryFactory
    {
        public IRoomBookingRepository GetRoomBookingRepository()
        {
            return new CsvRoomBookingRepository();
        }
    }
}
