using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace NyHotelManagementDesktop
{
    public partial class Form1 : Form
    {
        private List<Room> rooms = new();
        private List<Reservation> reservations = new();
        private DatabaseService dbService;

        public Form1()
        {
            InitializeComponent();
            dbService = new DatabaseService();

        }
    
        private async Task LoadDataAsync()
        {
            rooms = await dbService.GetAllRoomsAsync();
            reservations = await dbService.GetAllReservationsAsync();

            lstRooms.Items.Clear();
            foreach (var room in rooms)
            {
                lstRooms.Items.Add($"Room {room.Id} - {room.RoomType} - {(room.IsAvailable ? "Available" : "Occupied")}");
            }

            lstReservations.Items.Clear();
            foreach (var res in reservations)
            {
                lstReservations.Items.Add(res);
            }
        }
     
    


        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        private async void AddReservation(Reservation reservation)
        {
            await dbService.AddReservationAsync(reservation);
            await LoadDataAsync();
        }

        private async void btnAddReservation_Click(object sender, EventArgs e)
        {
            /*var availableRooms = rooms.FindAll(r => r.IsAvailable); 
            var addForm = new AddReservationForm(availableRooms, AddReservation);
            addForm.ShowDialog();

            */
            var addForm = new AddReservationForm(dbService, AddReservation); //  ENDRING
            addForm.ShowDialog();
        }
    


        private async void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (lstReservations.SelectedItem is Reservation selected)
            {
                await dbService.DeleteReservationAsync(selected.Id);
                await LoadDataAsync();
                MessageBox.Show("Reservation deleted.");
            }
        
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            /*if (lstReservations.SelectedItem is Reservation selected)
            {
                selected.Room.IsAvailable = false;
                await dbService.DeleteReservationAsync(selected.Id); // For enkelhet – i praksis burde status oppdateres
                await LoadDataAsync();
                MessageBox.Show("Checked in.");
            }*/
            if (lstReservations.SelectedItem is Reservation selectedReservation)
            {
                await dbService.UpdateReservationStatusAsync(selectedReservation.Id, 1); // 1 = Innsjekket
                await LoadDataAsync(); // Refresh
            }
        }
        
        

        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            /*if (lstReservations.SelectedItem is Reservation selected)
            {
                selected.Room.IsAvailable = true;
                await dbService.DeleteReservationAsync(selected.Id); // For enkelhet – i praksis burde status oppdateres
                await LoadDataAsync();
                MessageBox.Show("Checked out.");
            }*/
            if (lstReservations.SelectedItem is Reservation selectedReservation)
            {
                await dbService.UpdateReservationStatusAsync(selectedReservation.Id, 2); // 2 = Utsjekket
                await LoadDataAsync(); // Refresh
            }
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}

