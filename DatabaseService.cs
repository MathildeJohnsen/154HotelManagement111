using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace NyHotelManagementDesktop
{
    public class DatabaseService
    {
        private readonly string connectionString = "Server=tcp:hotelserver111.database.windows.net,1433;Initial Catalog=HotelDB;User ID=sqladmin;Password=Sterktpassord!;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var rooms = new List<Room>();

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var query = "SELECT * FROM Rooms";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            rooms.Add(new Room
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                NumberOfBeds = reader.GetInt32(reader.GetOrdinal("NumberOfBeds")),
                                RoomType = reader.GetString(reader.GetOrdinal("RoomType")),
                                PricePerNight = reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                                IsAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                            });
                        }
                    }
                }
            }

            return rooms;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = new List<Reservation>();

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var query = "SELECT r.*, rm.Id as RoomId, rm.RoomType, rm.NumberOfBeds, rm.PricePerNight, rm.IsAvailable " +
                            "FROM Reservations r JOIN Rooms rm ON r.RoomId = rm.Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var reservation = new Reservation
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetString(reader.GetOrdinal("UserId")),
                                FromDate = reader.GetDateTime(reader.GetOrdinal("FromDate")),
                                ToDate = reader.GetDateTime(reader.GetOrdinal("ToDate")),
                                Room = new Room
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("RoomId")),
                                    RoomType = reader.GetString(reader.GetOrdinal("RoomType")),
                                    NumberOfBeds = reader.GetInt32(reader.GetOrdinal("NumberOfBeds")),
                                    PricePerNight = reader.GetDecimal(reader.GetOrdinal("PricePerNight")),
                                    IsAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"))
                                },
                                Status = (ReservationStatus)reader.GetInt32(reader.GetOrdinal("Status"))
                            };

                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public async Task AddReservationAsync(Reservation res)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var insertQuery = @"INSERT INTO Reservations (UserId, FromDate, ToDate, RoomId, Status)
                                    VALUES (@UserId, @FromDate, @ToDate, @RoomId, @Status)";

                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", res.UserId);
                    cmd.Parameters.AddWithValue("@FromDate", res.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", res.ToDate);
                    cmd.Parameters.AddWithValue("@RoomId", res.RoomID);
                    cmd.Parameters.AddWithValue("@Status", (int)res.Status);

                    await cmd.ExecuteNonQueryAsync();
                }

                var updateRoomQuery = "UPDATE Rooms SET IsAvailable = 0 WHERE Id = @RoomId";
                using (var cmd = new SqlCommand(updateRoomQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", res.RoomID);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<bool> IsRoomAvailableAsync(int roomId, DateTime fromDate, DateTime toDate)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                
                var query = @"SELECT COUNT(*) FROM Reservations
                      WHERE RoomId = @RoomId
                      AND Status != 2 -- Ikke utsjekket
                      AND (
                            (@FromDate < ToDate AND @ToDate > FromDate)
                          )";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    int count = (int)await cmd.ExecuteScalarAsync();
                    return count == 0;
                }
            }
        }
        public async Task UpdateReservationStatusAsync(int reservationId, int newStatus)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                
                var updateStatusQuery = "UPDATE Reservations SET Status = @Status WHERE Id = @Id";
                using (var command = new SqlCommand(updateStatusQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@Id", reservationId);
                    await command.ExecuteNonQueryAsync();
                }

                
                if (newStatus == 2)
                {
                    
                    var getRoomIdQuery = "SELECT RoomId FROM Reservations WHERE Id = @Id";
                    int roomId;
                    using (var command = new SqlCommand(getRoomIdQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        roomId = (int)await command.ExecuteScalarAsync();
                    }

                   
                    var updateRoomQuery = "UPDATE Rooms SET IsAvailable = 1 WHERE Id = @RoomId";
                    using (var command = new SqlCommand(updateRoomQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RoomId", roomId);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        public async Task DeleteReservationAsync(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                
                var roomIdQuery = "SELECT RoomId FROM Reservations WHERE Id = @Id";
                int roomId;
                using (var cmd = new SqlCommand(roomIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    roomId = (int)await cmd.ExecuteScalarAsync();
                }

                var deleteQuery = "DELETE FROM Reservations WHERE Id = @Id";
                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    await cmd.ExecuteNonQueryAsync();
                }

                var updateRoomQuery = "UPDATE Rooms SET IsAvailable = 1 WHERE Id = @RoomId";
                using (var cmd = new SqlCommand(updateRoomQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }

}
