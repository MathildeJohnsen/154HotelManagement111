namespace NyHotelManagementDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstRooms = new ListBox();
            lstReservations = new ListBox();
            btnAddReservation = new Button();
            btnDeleteReservation = new Button();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lstRooms
            // 
            lstRooms.FormattingEnabled = true;
            lstRooms.Location = new Point(12, 98);
            lstRooms.Name = "lstRooms";
            lstRooms.Size = new Size(323, 196);
            lstRooms.TabIndex = 0;
            // 
            // lstReservations
            // 
            lstReservations.FormattingEnabled = true;
            lstReservations.Location = new Point(341, 98);
            lstReservations.Name = "lstReservations";
            lstReservations.Size = new Size(447, 196);
            lstReservations.TabIndex = 1;
            // 
            // btnAddReservation
            // 
            btnAddReservation.Location = new Point(12, 376);
            btnAddReservation.Name = "btnAddReservation";
            btnAddReservation.Size = new Size(214, 46);
            btnAddReservation.TabIndex = 2;
            btnAddReservation.Text = "Add Reservation";
            btnAddReservation.UseVisualStyleBackColor = true;
            btnAddReservation.Click += btnAddReservation_Click;
            // 
            // btnDeleteReservation
            // 
            btnDeleteReservation.Location = new Point(232, 376);
            btnDeleteReservation.Name = "btnDeleteReservation";
            btnDeleteReservation.Size = new Size(234, 46);
            btnDeleteReservation.TabIndex = 3;
            btnDeleteReservation.Text = "Delete Reservation";
            btnDeleteReservation.UseVisualStyleBackColor = true;
            btnDeleteReservation.Click += btnDeleteReservation_Click;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(475, 316);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(150, 46);
            btnCheckIn.TabIndex = 4;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(475, 376);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(150, 46);
            btnCheckOut.TabIndex = 5;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(638, 376);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 46);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 48);
            label1.Name = "label1";
            label1.Size = new Size(100, 32);
            label1.TabIndex = 7;
            label1.Text = "Vis Rom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(513, 48);
            label2.Name = "label2";
            label2.Size = new Size(198, 32);
            label2.TabIndex = 8;
            label2.Text = "Vis Reservasjoner";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(btnCheckOut);
            Controls.Add(btnCheckIn);
            Controls.Add(btnDeleteReservation);
            Controls.Add(btnAddReservation);
            Controls.Add(lstReservations);
            Controls.Add(lstRooms);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstRooms;
        private ListBox lstReservations;
        private Button btnAddReservation;
        private Button btnDeleteReservation;
        private Button btnCheckIn;
        private Button btnCheckOut;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
    }
}
