using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingSystem.Interfaces.Models;

namespace RoomBookingSystem.Services.Models
{
    public class RoomBookingRequest : IRoomBookingRequest
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Organiser { get; set; }
    }
}
