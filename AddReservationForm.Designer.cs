namespace NyHotelManagementDesktop
{
    partial class AddReservationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtGuestName = new TextBox();
            dtpCheckInDate = new DateTimePicker();
            dtpCheckOutDate = new DateTimePicker();
            cmbRoomSelection = new ComboBox();
            btnAddReservation = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtGuestName
            // 
            txtGuestName.Location = new Point(229, 56);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(200, 39);
            txtGuestName.TabIndex = 0;
            // 
            // dtpCheckInDate
            // 
            dtpCheckInDate.Location = new Point(225, 124);
            dtpCheckInDate.Name = "dtpCheckInDate";
            dtpCheckInDate.Size = new Size(400, 39);
            dtpCheckInDate.TabIndex = 1;
            // 
            // dtpCheckOutDate
            // 
            dtpCheckOutDate.Location = new Point(225, 182);
            dtpCheckOutDate.Name = "dtpCheckOutDate";
            dtpCheckOutDate.Size = new Size(400, 39);
            dtpCheckOutDate.TabIndex = 2;
            // 
            // cmbRoomSelection
            // 
            cmbRoomSelection.FormattingEnabled = true;
            cmbRoomSelection.Location = new Point(225, 286);
            cmbRoomSelection.Name = "cmbRoomSelection";
            cmbRoomSelection.Size = new Size(563, 40);
            cmbRoomSelection.TabIndex = 3;
            // 
            // btnAddReservation
            // 
            btnAddReservation.Location = new Point(225, 392);
            btnAddReservation.Name = "btnAddReservation";
            btnAddReservation.Size = new Size(204, 46);
            btnAddReservation.TabIndex = 4;
            btnAddReservation.Text = "Add Reservation";
            btnAddReservation.UseVisualStyleBackColor = true;
            btnAddReservation.Click += btnAddReservation_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 63);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 5;
            label1.Text = "Guest ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 289);
            label2.Name = "label2";
            label2.Size = new Size(181, 32);
            label2.TabIndex = 6;
            label2.Text = "Room Selection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 131);
            label3.Name = "label3";
            label3.Size = new Size(163, 32);
            label3.TabIndex = 7;
            label3.Text = "Check In Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 189);
            label4.Name = "label4";
            label4.Size = new Size(183, 32);
            label4.TabIndex = 8;
            label4.Text = "Check Out Date";
            // 
            // AddReservationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddReservation);
            Controls.Add(cmbRoomSelection);
            Controls.Add(dtpCheckOutDate);
            Controls.Add(dtpCheckInDate);
            Controls.Add(txtGuestName);
            Name = "AddReservationForm";
            Text = "AddReservationForm";
            Load += AddReservationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGuestName;
        private DateTimePicker dtpCheckInDate;
        private DateTimePicker dtpCheckOutDate;
        private ComboBox cmbRoomSelection;
        private Button btnAddReservation;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}