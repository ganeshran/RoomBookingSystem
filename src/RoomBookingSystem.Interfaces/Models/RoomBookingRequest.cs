using System.Text;

namespace RoomBookingSystem.Interfaces.Models
{
    public class RoomBookingRequest : IRoomBookingRequest
    {
        public RoomBookingRequest()
        {
        }

        public RoomBookingRequest(DateTime startDateTime, DateTime endDateTime, string? name, string? notes, string? organiser)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Name = name;
            Notes = notes;
            Organiser = organiser;
        }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Organiser { get; set; }

        public Tuple<bool, string> IsValid()
        {

            var errorMessages = new StringBuilder();
            var validity = true;
            void checkValidity(string prop, string error)
            {
                if (!string.IsNullOrWhiteSpace(prop)) return;
                validity = false;
                errorMessages.Append($"{error} cannot be null, empty of whitespace");
            }
         
            checkValidity(this.Organiser, "Organiser Name");
            checkValidity(this.Name, "Room Name");

            if (StartDateTime >= EndDateTime)
            {
                validity = false;
                errorMessages.Append("Start Date cannot be earlier than end Date");
            }
               

            return new Tuple<bool, string>(validity, errorMessages.ToString());

        }

        public override string ToString() => $"Room: {this.Name}, Organiser: {this.Organiser}, Start Date: {this.StartDateTime}, End Date: {this.EndDateTime}";
        
    }
}
