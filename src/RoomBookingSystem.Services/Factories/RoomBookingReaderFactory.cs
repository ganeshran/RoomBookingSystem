using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Repository;

namespace RoomBookingSystem.Services.Factories
{
    public class RoomBookingRepositoryFactory
    {
        public IRoomBookingRepository GetRoomBookingDataReader()
        {
            return new CsvRoomBookingRepository();
        }
    }
}
