using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Models;
using RoomBookingSystem.Interfaces.Repository;

namespace RoomBookingSystem.Services
{
    public class CsvRoomBookingRepository: IRoomBookingRepository
    {
        public IEnumerable<IRoomBookingRequest> GetRoomBookingRequests()
        {
            return new List<IRoomBookingRequest>()
            {
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,21, 13,0,0),
                EndDateTime =  new DateTime(2023,5,21, 14,0,0),
                Name = "Booker 1", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,21, 13,30,0),
                    EndDateTime =  new DateTime(2023,5,21, 14,30,0),
                    Name = "Booker 2", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,22, 10,0,0),
                    EndDateTime =  new DateTime(2023,5,22, 11,0,0),
                    Name = "Booker 1", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,23, 15,0,0),
                    EndDateTime =  new DateTime(2023,5,23, 16,0,0),
                    Name = "Booker 3", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,23, 9,0,0),
                    EndDateTime =  new DateTime(2023,5,23, 9,30,0),
                    Name = "Booker 3", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,23, 15,0,0),
                    EndDateTime =  new DateTime(2023,5,23, 17,0,0),
                    Name = "Booker 3", Notes = "Test Booking 1", Organiser = "hello"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,23, 15,30,0),
                    EndDateTime =  new DateTime(2023,5,23, 16,30,0),
                    Name = "Booker 2", Notes = "Test Booking 1", Organiser = "hello"
                }
            };
        }
    }
}
