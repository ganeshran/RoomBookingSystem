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
                //TODO: Display the messages due to which validity is false
                throw new ArgumentException("One of the retrieved bookings isn't valid");
            if (!allBookings.Any() || (!startDate.HasValue && !endDate.HasValue))
                // No point in filtering any further if there are no elements in collection or start and end date both are null
                return allBookings;

            var resultBookings = allBookings;
            if (startDate.HasValue)
            {
                //TODO: This should all be done on the enumerables and not list for performance reasons.  
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
            //Retrieve all bookings from the current method. 
            var resultBookings = await this.RetrieveBookings(startDate, endDate);
            var roomBookingRequests = new Dictionary<string, List<IRoomBookingRequest>>();

            var conflicts = new Dictionary<string, List<Tuple<IRoomBookingRequest,IRoomBookingRequest>>>();

            //First we need to order all our requests which makes conflict detection easy
            foreach (var request in resultBookings.OrderBy(x => x.StartDateTime))
            {
                if (!roomBookingRequests.ContainsKey(request.Name))
                    roomBookingRequests.Add(request.Name, new List<IRoomBookingRequest>());
                //Add each room's booking to its own dictionary entry as bookings for different rooms wont create conflicts
                roomBookingRequests[request.Name].Add(request);
            }
            
            //Iterate through each room in our dictionary. Since our input was sorted the individual values for each room will be sorted too
            foreach (var room in  roomBookingRequests)
            {
                //Store previous meeting request for comparison
                IRoomBookingRequest prevMeetingReq = null;
                foreach (var request in room.Value)
                {
                    //If the meeting's start time is less than previous meeting's end time then its a conflict. This is only possible because our bookings are sorted
                    if (request.StartDateTime < (prevMeetingReq?.EndDateTime ?? DateTime.MinValue))
                    {
                        if (!conflicts.ContainsKey(room.Key))
                            conflicts.Add(room.Key, new List<Tuple<IRoomBookingRequest, IRoomBookingRequest>>());
                        //The Value here is a tuple so I can display both sides of the conflicts. There is a more elegant solution
                        //possible here but I went for a tuple to complete the exercise within the allotted time
                        conflicts[room.Key]
                            .Add(new Tuple<IRoomBookingRequest, IRoomBookingRequest>(prevMeetingReq, request));
                    }
                    //Assign current requests prev variable for next iteration
                    prevMeetingReq = request;
                }
            }

            return conflicts;
        }
    }
}
