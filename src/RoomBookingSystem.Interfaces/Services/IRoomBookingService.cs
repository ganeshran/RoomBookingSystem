using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Models;

namespace RoomBookingSystem.Interfaces.Services
{
    public interface IRoomBookingService
    {
        Task<IEnumerable<IRoomBookingRequest>> RetrieveBookings(DateTime? startDate , DateTime? endDate);

        Task<Dictionary<string, List<Tuple<IRoomBookingRequest,IRoomBookingRequest>>>> RetrieveConflictedBookings(DateTime? startDate , DateTime? endDate);
    }
}
