using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyHotelManagementDesktop
{
    public enum ReservationStatus
    {
        Active,
        Cancelled,
        Completed
    }
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Room Room { get; set; }
        public int RoomID { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;



        public override string ToString()
        {

            // return $"{UserId} (Room {Room.Id}) - {FromDate.ToShortDateString()} to {ToDate.ToShortDateString()}";
            string shortenedUserId = UserId.Length > 5 ? UserId.Substring(0, 5) + "..." : UserId;
            return $"{shortenedUserId} (Room {Room.Id}) - {FromDate.ToShortDateString()} to {ToDate.ToShortDateString()}";
        }
    }
}
