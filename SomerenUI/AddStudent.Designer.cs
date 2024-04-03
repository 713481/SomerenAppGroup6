namespace SomerenUI
{
    partial class AddStudent
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
            tbxStudentFirstName = new System.Windows.Forms.TextBox();
            lblStudentFirstName = new System.Windows.Forms.Label();
            lblStudentLastName = new System.Windows.Forms.Label();
            tbxStudentLastName = new System.Windows.Forms.TextBox();
            lblStudentPhoneNumber = new System.Windows.Forms.Label();
            tbxStudentPhoneNumber = new System.Windows.Forms.TextBox();
            lblStudentAge = new System.Windows.Forms.Label();
            tbxStudentAge = new System.Windows.Forms.TextBox();
            lblStudentClass = new System.Windows.Forms.Label();
            tbxStudentClass = new System.Windows.Forms.TextBox();
            lblStudentRoomId = new System.Windows.Forms.Label();
            tbxStudentRoomId = new System.Windows.Forms.TextBox();
            btnStudentAddStudent = new System.Windows.Forms.Button();
            lblStudentID = new System.Windows.Forms.Label();
            tbxStudentID = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // tbxStudentFirstName
            // 
            tbxStudentFirstName.Location = new System.Drawing.Point(138, 75);
            tbxStudentFirstName.Name = "tbxStudentFirstName";
            tbxStudentFirstName.Size = new System.Drawing.Size(209, 23);
            tbxStudentFirstName.TabIndex = 0;
            // 
            // lblStudentFirstName
            // 
            lblStudentFirstName.AutoSize = true;
            lblStudentFirstName.Location = new System.Drawing.Point(68, 78);
            lblStudentFirstName.Name = "lblStudentFirstName";
            lblStudentFirstName.Size = new System.Drawing.Size(64, 15);
            lblStudentFirstName.TabIndex = 1;
            lblStudentFirstName.Text = "First Name";
            // 
            // lblStudentLastName
            // 
            lblStudentLastName.AutoSize = true;
            lblStudentLastName.Location = new System.Drawing.Point(68, 107);
            lblStudentLastName.Name = "lblStudentLastName";
            lblStudentLastName.Size = new System.Drawing.Size(63, 15);
            lblStudentLastName.TabIndex = 3;
            lblStudentLastName.Text = "Last Name";
            // 
            // tbxStudentLastName
            // 
            tbxStudentLastName.Location = new System.Drawing.Point(138, 104);
            tbxStudentLastName.Name = "tbxStudentLastName";
            tbxStudentLastName.Size = new System.Drawing.Size(209, 23);
            tbxStudentLastName.TabIndex = 2;
            // 
            // lblStudentPhoneNumber
            // 
            lblStudentPhoneNumber.AutoSize = true;
            lblStudentPhoneNumber.Location = new System.Drawing.Point(45, 136);
            lblStudentPhoneNumber.Name = "lblStudentPhoneNumber";
            lblStudentPhoneNumber.Size = new System.Drawing.Size(86, 15);
            lblStudentPhoneNumber.TabIndex = 5;
            lblStudentPhoneNumber.Text = "Phone number";
            // 
            // tbxStudentPhoneNumber
            // 
            tbxStudentPhoneNumber.Location = new System.Drawing.Point(138, 133);
            tbxStudentPhoneNumber.Name = "tbxStudentPhoneNumber";
            tbxStudentPhoneNumber.Size = new System.Drawing.Size(209, 23);
            tbxStudentPhoneNumber.TabIndex = 4;
            // 
            // lblStudentAge
            // 
            lblStudentAge.AutoSize = true;
            lblStudentAge.Location = new System.Drawing.Point(103, 165);
            lblStudentAge.Name = "lblStudentAge";
            lblStudentAge.Size = new System.Drawing.Size(28, 15);
            lblStudentAge.TabIndex = 7;
            lblStudentAge.Text = "Age";
            lblStudentAge.Click += lblStudentAge_Click;
            // 
            // tbxStudentAge
            // 
            tbxStudentAge.Location = new System.Drawing.Point(138, 162);
            tbxStudentAge.Name = "tbxStudentAge";
            tbxStudentAge.Size = new System.Drawing.Size(209, 23);
            tbxStudentAge.TabIndex = 6;
            // 
            // lblStudentClass
            // 
            lblStudentClass.AutoSize = true;
            lblStudentClass.Location = new System.Drawing.Point(103, 194);
            lblStudentClass.Name = "lblStudentClass";
            lblStudentClass.Size = new System.Drawing.Size(34, 15);
            lblStudentClass.TabIndex = 9;
            lblStudentClass.Text = "Class";
            // 
            // tbxStudentClass
            // 
            tbxStudentClass.Location = new System.Drawing.Point(138, 191);
            tbxStudentClass.Name = "tbxStudentClass";
            tbxStudentClass.Size = new System.Drawing.Size(209, 23);
            tbxStudentClass.TabIndex = 8;
            // 
            // lblStudentRoomId
            // 
            lblStudentRoomId.AutoSize = true;
            lblStudentRoomId.Location = new System.Drawing.Point(79, 223);
            lblStudentRoomId.Name = "lblStudentRoomId";
            lblStudentRoomId.Size = new System.Drawing.Size(53, 15);
            lblStudentRoomId.TabIndex = 11;
            lblStudentRoomId.Text = "Room ID";
            lblStudentRoomId.Click += lblStudentRoomId_Click;
            // 
            // tbxStudentRoomId
            // 
            tbxStudentRoomId.Location = new System.Drawing.Point(138, 220);
            tbxStudentRoomId.Name = "tbxStudentRoomId";
            tbxStudentRoomId.Size = new System.Drawing.Size(209, 23);
            tbxStudentRoomId.TabIndex = 10;
            // 
            // btnStudentAddStudent
            // 
            btnStudentAddStudent.Location = new System.Drawing.Point(103, 275);
            btnStudentAddStudent.Name = "btnStudentAddStudent";
            btnStudentAddStudent.Size = new System.Drawing.Size(192, 53);
            btnStudentAddStudent.TabIndex = 12;
            btnStudentAddStudent.Text = "Add student";
            btnStudentAddStudent.UseVisualStyleBackColor = true;
            btnStudentAddStudent.Click += btnStudentAddStudent_Click;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new System.Drawing.Point(68, 49);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new System.Drawing.Size(62, 15);
            lblStudentID.TabIndex = 14;
            lblStudentID.Text = "Student ID";
            // 
            // tbxStudentID
            // 
            tbxStudentID.Location = new System.Drawing.Point(138, 46);
            tbxStudentID.Name = "tbxStudentID";
            tbxStudentID.Size = new System.Drawing.Size(209, 23);
            tbxStudentID.TabIndex = 13;
            // 
            // AddStudent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(418, 361);
            Controls.Add(lblStudentID);
            Controls.Add(tbxStudentID);
            Controls.Add(btnStudentAddStudent);
            Controls.Add(lblStudentRoomId);
            Controls.Add(tbxStudentRoomId);
            Controls.Add(lblStudentClass);
            Controls.Add(tbxStudentClass);
            Controls.Add(lblStudentAge);
            Controls.Add(tbxStudentAge);
            Controls.Add(lblStudentPhoneNumber);
            Controls.Add(tbxStudentPhoneNumber);
            Controls.Add(lblStudentLastName);
            Controls.Add(tbxStudentLastName);
            Controls.Add(lblStudentFirstName);
            Controls.Add(tbxStudentFirstName);
            Name = "AddStudent";
            Text = "Add Student";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbxStudentFirstName;
        private System.Windows.Forms.Label lblStudentFirstName;
        private System.Windows.Forms.Label lblStudentLastName;
        private System.Windows.Forms.TextBox tbxStudentLastName;
        private System.Windows.Forms.Label lblStudentPhoneNumber;
        private System.Windows.Forms.TextBox tbxStudentPhoneNumber;
        private System.Windows.Forms.Label lblStudentAge;
        private System.Windows.Forms.TextBox tbxStudentAge;
        private System.Windows.Forms.Label lblStudentClass;
        private System.Windows.Forms.TextBox tbxStudentClass;
        private System.Windows.Forms.Label lblStudentRoomId;
        private System.Windows.Forms.TextBox tbxStudentRoomId;
        private System.Windows.Forms.Button btnStudentAddStudent;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox tbxStudentID;
    }
}