using RoomBookingSystem.Interfaces.Models;
using RoomBookingSystem.Interfaces.Repository;

namespace RoomBookingSystem.Repositories
{
    public class CsvRoomBookingRepository: IRoomBookingRepository
    {
        public async Task<IEnumerable<IRoomBookingRequest>> GetRoomBookingRequests()
        {
            await Task.Delay(0);
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
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,21, 13,30,0),
                    EndDateTime =  new DateTime(2023,5,21, 14,30,0),
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
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,25, 16,30,0),
                EndDateTime =  new DateTime(2023,5,25, 17,30,0),
                Name = "Booker 3", Notes = "Test Booking 1", Organiser = "Hi"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,25, 16,30,0),
                    EndDateTime =  new DateTime(2023,5,25, 17,30,0),
                    Name = "Booker 3", Notes = "Test Booking 1", Organiser = "Hi"
                },
                new RoomBookingRequest() { StartDateTime =  new DateTime(2023,5,25, 16,45,0),
                    EndDateTime =  new DateTime(2023,5,25, 17,45,0),
                    Name = "Booker 3", Notes = "Test Booking 1", Organiser = "Hi"
                },

            };
        }
    }
}
