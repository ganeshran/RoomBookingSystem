using CsvHelper;
using RoomBookingSystem.Interfaces.Models;
using RoomBookingSystem.Interfaces.Repository;
using System.Globalization;

namespace RoomBookingSystem.Repositories
{
    public class CsvRoomBookingRepository: IRoomBookingRepository
    {
        public async Task<IEnumerable<IRoomBookingRequest>> GetRoomBookingRequests()
        {
            var res = new List<IRoomBookingRequest>();
            using var reader = new StreamReader("DummyData.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<RoomBookingRequestMap>();
            var records = csv.GetRecordsAsync<RoomBookingRequest>();
            await foreach (var item in records)
            {
                res.Add(item);
            }

            return res;
        }
    }

    public sealed class RoomBookingRequestMap : CsvHelper.Configuration.ClassMap<RoomBookingRequest>
    {
        public RoomBookingRequestMap()
        {
            string format = "dd/MM/yyyy HH:mm:ss";
            var cultureInfo = CultureInfo.GetCultureInfo("en-GB");

            Map(m => m.StartDateTime).TypeConverterOption.Format(format)
                .TypeConverterOption.CultureInfo(cultureInfo);

            Map(m => m.EndDateTime).TypeConverterOption.Format(format)
                .TypeConverterOption.CultureInfo(cultureInfo);

            Map(m => m.Name);
            Map(m => m.Organiser);
            Map(m => m.Notes);
        }
    }
}
