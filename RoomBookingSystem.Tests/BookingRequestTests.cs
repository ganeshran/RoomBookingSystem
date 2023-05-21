using RoomBookingSystem.Interfaces.Models;

namespace RoomBookingSystem.Tests
{
    public class BookingRequestTests
    {
        [Theory]
        [InlineData("Room 1", "Organiser 1", "", "17-5-2023 10:00:00", "17-5-2023 11:00:00")]
        [InlineData("Room 2", "Organiser 2", "", "18-5-2023 14:30:00", "18-5-2023 15:00:00")]
        [InlineData("Room 1", "Organiser 3", "", "19-5-2023 10:00:00", "19-5-2023 11:00:00")]
        [InlineData("Room 2", "Organiser 4", "", "21-5-2023 15:00:00", "21-5-2023 17:00:00")]
        [InlineData("Room 2", "Organiser 5", "", "22-5-2023 9:00:00", "22-5-2023 9:30:00")]
        [InlineData("Room 3", "Organiser 6", "", "23-5-2023 16:30:00", "23-5-2023 17:30:00")]
        [InlineData("Room 4", "Organiser 7", "", "25-5-2023 18:00:00", "25-5-2023 19:00:00")]

        public void should_create_valid_booking_request_object(string name, string organiser, string notes, string startDate, string endDate)
        {
            var request = new RoomBookingRequest()
            {
                StartDateTime = DateTime.Parse(startDate),
                EndDateTime = DateTime.Parse(endDate),
                Name = name,
                Organiser = organiser,
                Notes = notes,
            };

            Assert.NotNull(request);
        }

        [Theory]
        [InlineData("Room 1", "Organiser 1", "", "17-5-2023 10:00:00", "17-5-2023 11:00:00", true)]
        [InlineData("Room 2", "Organiser 2", "", "18-5-2023 14:30:00", "18-5-2023 15:00:00", true)]
        [InlineData("Room 1", "Organiser 3", "", "19-5-2023 10:00:00", "19-5-2023 09:00:00", false)]
        [InlineData("Room 2", "Organiser 4", "", "21-5-2023 15:00:00", "21-5-2023 17:00:00", true)]
        [InlineData("Room 2", "Organiser 5", "", "22-5-2023 9:00:00", "22-5-2023 9:30:00", true)]
        [InlineData(null, "Organiser 6", "", "23-5-2023 16:30:00", "23-5-2023 17:30:00", false)]
        [InlineData("Room 4", null, "", "25-5-2023 18:00:00", "25-5-2023 19:00:00", false)]
        public void should_validate_booking_request_object(string name, string organiser, string notes, string startDate, string endDate, bool expectedResult)
        {
            var request = new RoomBookingRequest()
            {
                StartDateTime = DateTime.Parse(startDate),
                EndDateTime = DateTime.Parse(endDate),
                Name = name,
                Organiser = organiser,
                Notes = notes,
            };

            Assert.NotNull(request);
            Assert.Equal(request.IsValid().Item1, expectedResult);
        }
    }
}