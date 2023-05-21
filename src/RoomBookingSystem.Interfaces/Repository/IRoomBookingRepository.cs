using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Models;

namespace RoomBookingSystem.Interfaces.Repository
{
    public interface IRoomBookingRepository
    {
        Task<IEnumerable<IRoomBookingRequest>> GetRoomBookingRequests();
    }
}
