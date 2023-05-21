using RoomBookingSystem.Services.Factories;
using RoomBookingSystem.Services.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var roomBookingService = new RoomBookingService(new RoomBookingRepositoryFactory());
        var conflicts = roomBookingService.RetrieveConflictedBookings().Result;
        if (!conflicts.Any())
        {
            Console.WriteLine("No Conflicts were detected");
        }

        foreach (var conflictedBookingRoom in conflicts)
        {
            Console.WriteLine($"Room:{conflictedBookingRoom.Key}");
            foreach (var meeting in conflictedBookingRoom.Value)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"{meeting.Item1.ToString()}");
                Console.WriteLine($"{meeting.Item2.ToString()}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }

            Console.WriteLine(
                "\n==============================================================================================\n");
        }
    }
}