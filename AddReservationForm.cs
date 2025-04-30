using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyHotelManagementDesktop
{
    public partial class AddReservationForm : Form
    {
        private DatabaseService dbService;
        private Action<Reservation> onReservationAdded;

     


        public AddReservationForm(DatabaseService dbService, Action<Reservation> reservationAddedCallback) 
        {
            InitializeComponent();
            this.dbService = dbService; 
            this.onReservationAdded = reservationAddedCallback;

            dtpCheckInDate.ValueChanged += DateChanged; 
            dtpCheckOutDate.ValueChanged += DateChanged; 
        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
            DateChanged(null, null);
        }
        private async void DateChanged(object sender, EventArgs e)
        {
            DateTime from = dtpCheckInDate.Value.Date;
            DateTime to = dtpCheckOutDate.Value.Date;

            if (from >= to)
            {
                cmbRoomSelection.DataSource = null;
                return;
            }

            var allRooms = await dbService.GetAllRoomsAsync();
            var availableRooms = new List<Room>();

            foreach (var room in allRooms)
            {
                bool isAvailable = await dbService.IsRoomAvailableAsync(room.Id, from, to);
                if (isAvailable)
                    availableRooms.Add(room);
            }

            cmbRoomSelection.DataSource = availableRooms;
            cmbRoomSelection.DisplayMember = "RoomType";
        }

        private async void btnAddReservation_Click(object sender, EventArgs e)
        {
            string userId = txtGuestName.Text;
            DateTime fromDate = dtpCheckInDate.Value;
            DateTime toDate = dtpCheckOutDate.Value;
            Room selectedRoom = cmbRoomSelection.SelectedItem as Room;

            if (string.IsNullOrWhiteSpace(userId) || selectedRoom == null)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var dbService = new DatabaseService();  

            bool isAvailable = await dbService.IsRoomAvailableAsync(selectedRoom.Id, fromDate, toDate);
            if (!isAvailable)
            {
                MessageBox.Show("Room is not available for the selected dates.");
                return;
            }

            var newReservation = new Reservation
            {
                UserId = userId,
                RoomID = selectedRoom.Id,
                FromDate = fromDate,
                ToDate = toDate,
                Status = ReservationStatus.Active,
                Room = selectedRoom
            };

            onReservationAdded(newReservation);
            this.Close();
        }
    }
}

            
    
