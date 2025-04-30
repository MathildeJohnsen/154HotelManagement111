using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NyHotelManagementDesktop
{
    public class Room
    {
        public int Id { get; set; }

        public int NumberOfBeds { get; set; }

        public string RoomType { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return $"Room {Id} - {RoomType} - {NumberOfBeds} beds - {PricePerNight} NOK";
        }
    }
}