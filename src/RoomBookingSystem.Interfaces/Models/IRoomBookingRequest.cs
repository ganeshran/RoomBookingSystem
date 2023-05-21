using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.Interfaces.Models
{
    public interface IRoomBookingRequest
    {
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public string Organiser { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Organiser))
                throw new InvalidDataException("Organiser cannot be null");

            if (string.IsNullOrWhiteSpace(Name))
                throw new InvalidDataException("Room Name cannot be null");

            if (StartDateTime >= EndDateTime)
                throw new InvalidDataException("Start Date cannot be later or the same as end date");

            return true;
        }
    }
}
