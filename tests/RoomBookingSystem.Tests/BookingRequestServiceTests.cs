using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RoomBookingSystem.Interfaces.Factories;
using RoomBookingSystem.Interfaces.Models;
using RoomBookingSystem.Interfaces.Repository;
using RoomBookingSystem.Interfaces.Services;
using RoomBookingSystem.Services.Services;

namespace RoomBookingSystem.Tests
{
    public class BookingRequestServiceTests
    {

        [Fact]
        public async void should_detect_no_conflicts()
        {
            var factory = GetMockRepoFactory(GetNonConflictedRequests);
            var _roomBookingService = new RoomBookingService(factory.Object);
            Assert.Empty(await _roomBookingService.RetrieveConflictedBookings());

        }

        [Fact]
        public async void should_detect_conflicts()
        {
            var factory = GetMockRepoFactory(GetConflictedRequests);
            var _roomBookingService = new RoomBookingService(factory.Object);
            Assert.NotEmpty(await _roomBookingService.RetrieveConflictedBookings());

        }

        private Mock<IRoomBookingRepositoryFactory> GetMockRepoFactory(Func<List<IRoomBookingRequest>> getTestRequests)
        {
            var inMemoryBookingRepo = new Mock<IRoomBookingRepository>();
            inMemoryBookingRepo.Setup(_ => _.GetRoomBookingRequests()).ReturnsAsync(getTestRequests());
            var factory = new Mock<IRoomBookingRepositoryFactory>();
            factory.Setup(_ => _.GetRoomBookingRepository()).Returns(inMemoryBookingRepo.Object);
            return factory;
        }

        private List<IRoomBookingRequest> GetConflictedRequests() =>
            new()
            {
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 21, 13, 0, 0),
                    endDateTime: new DateTime(2023, 5, 21, 14, 0, 0), name: "Booker 1", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 21, 13, 30, 0),
                    endDateTime: new DateTime(2023, 5, 21, 14, 30, 0), name: "Booker 2", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 21, 13, 30, 0),
                    endDateTime: new DateTime(2023, 5, 21, 14, 30, 0), name: "Booker 1", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 15, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 16, 0, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 9, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 9, 30, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 15, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 17, 0, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 15, 30, 0),
                    endDateTime: new DateTime(2023, 5, 23, 16, 30, 0), name: "Booker 2", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 25, 16, 30, 0),
                    endDateTime: new DateTime(2023, 5, 25, 17, 30, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "Hi"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 25, 16, 30, 0),
                    endDateTime: new DateTime(2023, 5, 25, 17, 30, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "Hi"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 25, 16, 45, 0),
                    endDateTime: new DateTime(2023, 5, 25, 17, 45, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "Hi"),

            };

        private List<IRoomBookingRequest> GetNonConflictedRequests() =>
            new()
            {
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 21, 13, 0, 0),
                    endDateTime: new DateTime(2023, 5, 21, 14, 0, 0), name: "Booker 1", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 22, 13, 30, 0),
                    endDateTime: new DateTime(2023, 5, 22, 14, 30, 0), name: "Booker 1", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 15, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 16, 0, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 9, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 9, 30, 0), name: "Booker 2", notes: "Test Booking 1",
                    organiser: "hello"),
                new RoomBookingRequest(startDateTime: new DateTime(2023, 5, 23, 13, 0, 0),
                    endDateTime: new DateTime(2023, 5, 23, 14, 0, 0), name: "Booker 3", notes: "Test Booking 1",
                    organiser: "hello"),

            };
    }
}
