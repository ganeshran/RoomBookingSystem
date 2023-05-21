using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Factories;
using RoomBookingSystem.Interfaces.Models;
using RoomBookingSystem.Interfaces.Services;

namespace RoomBookingSystem.Services.Services
{
    public class RoomBookingService: IRoomBookingService
    {
        private readonly IRoomBookingRepositoryFactory _bookingRepositoryFactory;
        public RoomBookingService(IRoomBookingRepositoryFactory repositoryFactory)
        {
            this._bookingRepositoryFactory = repositoryFactory;
        }
        public async Task<IEnumerable<IRoomBookingRequest>> RetrieveBookings(DateTime? startDate, DateTime? endDate)
        {
            var allBookings = await _bookingRepositoryFactory.GetRoomBookingDataReader().GetRoomBookingRequests();
            if (!allBookings.Any())
                return allBookings;
            var resultBookings = allBookings;
            if (startDate.HasValue)
            {
                resultBookings = resultBookings.Where(x => x.StartDateTime >= startDate);
            }

            if (endDate.HasValue)
            {
                resultBookings = resultBookings.Where(x => x.EndDateTime <= endDate);
            }

            return resultBookings;
        }
    }
}
