using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.Interfaces.Models
{
    public interface IRoomBookingRequest
    {
        DateTime StartDateTime { get; set; }

         DateTime EndDateTime { get; set; }

         string? Name { get; set; }

         string? Notes { get; set; }

         string? Organiser { get; set; }

        bool IsValid();

    }
}
