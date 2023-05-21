using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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
        public async Task<IEnumerable<IRoomBookingRequest>> RetrieveBookings(DateTime? startDate = null, DateTime? endDate = null)
        {
            var allBookings = await _bookingRepositoryFactory.GetRoomBookingRepository().GetRoomBookingRequests();
            if (allBookings.Any(x => !x.IsValid().Item1))
                throw new ArgumentException("One of the retrieved bookings isn't valid");
            if (!allBookings.Any() || (!startDate.HasValue && !endDate.HasValue))
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

        public async Task<Dictionary<string, List<Tuple<IRoomBookingRequest,IRoomBookingRequest>>>> RetrieveConflictedBookings(DateTime? startDate = null, DateTime? endDate = null)
        {
            var resultBookings = await this.RetrieveBookings(startDate, endDate);
            var roomBookingRequests = new Dictionary<string, List<IRoomBookingRequest>>();
            var conflicts = new Dictionary<string, List<Tuple<IRoomBookingRequest,IRoomBookingRequest>>>();
            foreach (var request in resultBookings.OrderBy(x => x.StartDateTime))
            {
                if (!roomBookingRequests.ContainsKey(request.Name))
                    roomBookingRequests.Add(request.Name, new List<IRoomBookingRequest>());
                roomBookingRequests[request.Name].Add(request);
            }
            
            foreach (var room in  roomBookingRequests)
            {
                IRoomBookingRequest prevMeetingReq = null;
                foreach (var request in room.Value)
                {
                    if (request.StartDateTime < (prevMeetingReq?.EndDateTime ?? DateTime.MinValue))
                    {
                        if (!conflicts.ContainsKey(room.Key))
                            conflicts.Add(room.Key, new List<Tuple<IRoomBookingRequest, IRoomBookingRequest>>());
                        conflicts[room.Key]
                            .Add(new Tuple<IRoomBookingRequest, IRoomBookingRequest>(prevMeetingReq, request));
                    }

                    prevMeetingReq = request;
                }
            }

            return conflicts;
        }
    }
}
