namespace SomerenUI
{
    partial class AddDrink
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
            lblDrinkName = new System.Windows.Forms.Label();
            tbxDrinkName = new System.Windows.Forms.TextBox();
            lblDrinkId = new System.Windows.Forms.Label();
            tbxDrinkId = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            tbxPrice = new System.Windows.Forms.TextBox();
            lblStock = new System.Windows.Forms.Label();
            tbxStock = new System.Windows.Forms.TextBox();
            lblTypeDrink = new System.Windows.Forms.Label();
            rbtnAlcoholic = new System.Windows.Forms.RadioButton();
            rbtnSoftDrink = new System.Windows.Forms.RadioButton();
            btnAddDrink = new System.Windows.Forms.Button();
            lblVat = new System.Windows.Forms.Label();
            tbxVat = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // lblDrinkName
            // 
            lblDrinkName.AutoSize = true;
            lblDrinkName.Location = new System.Drawing.Point(51, 71);
            lblDrinkName.Name = "lblDrinkName";
            lblDrinkName.Size = new System.Drawing.Size(68, 15);
            lblDrinkName.TabIndex = 4;
            lblDrinkName.Text = "Drink name";
            // 
            // tbxDrinkName
            // 
            tbxDrinkName.Location = new System.Drawing.Point(165, 68);
            tbxDrinkName.Name = "tbxDrinkName";
            tbxDrinkName.Size = new System.Drawing.Size(171, 23);
            tbxDrinkName.TabIndex = 2;
            // 
            // lblDrinkId
            // 
            lblDrinkId.AutoSize = true;
            lblDrinkId.Location = new System.Drawing.Point(51, 42);
            lblDrinkId.Name = "lblDrinkId";
            lblDrinkId.Size = new System.Drawing.Size(49, 15);
            lblDrinkId.TabIndex = 6;
            lblDrinkId.Text = "Drink ID";
            // 
            // tbxDrinkId
            // 
            tbxDrinkId.Location = new System.Drawing.Point(165, 39);
            tbxDrinkId.Name = "tbxDrinkId";
            tbxDrinkId.Size = new System.Drawing.Size(171, 23);
            tbxDrinkId.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(51, 100);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(33, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price";
            // 
            // tbxPrice
            // 
            tbxPrice.Location = new System.Drawing.Point(165, 97);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.Size = new System.Drawing.Size(171, 23);
            tbxPrice.TabIndex = 3;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new System.Drawing.Point(51, 158);
            lblStock.Name = "lblStock";
            lblStock.Size = new System.Drawing.Size(36, 15);
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock";
            // 
            // tbxStock
            // 
            tbxStock.Location = new System.Drawing.Point(165, 155);
            tbxStock.Name = "tbxStock";
            tbxStock.Size = new System.Drawing.Size(171, 23);
            tbxStock.TabIndex = 5;
            // 
            // lblTypeDrink
            // 
            lblTypeDrink.AutoSize = true;
            lblTypeDrink.Location = new System.Drawing.Point(51, 187);
            lblTypeDrink.Name = "lblTypeDrink";
            lblTypeDrink.Size = new System.Drawing.Size(62, 15);
            lblTypeDrink.TabIndex = 12;
            lblTypeDrink.Text = "Type Drink";
            // 
            // rbtnAlcoholic
            // 
            rbtnAlcoholic.AutoSize = true;
            rbtnAlcoholic.Location = new System.Drawing.Point(165, 187);
            rbtnAlcoholic.Name = "rbtnAlcoholic";
            rbtnAlcoholic.Size = new System.Drawing.Size(75, 19);
            rbtnAlcoholic.TabIndex = 6;
            rbtnAlcoholic.TabStop = true;
            rbtnAlcoholic.Text = "Alcoholic";
            rbtnAlcoholic.UseVisualStyleBackColor = true;
            // 
            // rbtnSoftDrink
            // 
            rbtnSoftDrink.AutoSize = true;
            rbtnSoftDrink.Location = new System.Drawing.Point(165, 212);
            rbtnSoftDrink.Name = "rbtnSoftDrink";
            rbtnSoftDrink.Size = new System.Drawing.Size(77, 19);
            rbtnSoftDrink.TabIndex = 7;
            rbtnSoftDrink.TabStop = true;
            rbtnSoftDrink.Text = "Soft Drink";
            rbtnSoftDrink.UseVisualStyleBackColor = true;
            // 
            // btnAddDrink
            // 
            btnAddDrink.Location = new System.Drawing.Point(99, 263);
            btnAddDrink.Name = "btnAddDrink";
            btnAddDrink.Size = new System.Drawing.Size(193, 43);
            btnAddDrink.TabIndex = 8;
            btnAddDrink.Text = "Add Drink";
            btnAddDrink.UseVisualStyleBackColor = true;
            btnAddDrink.Click += btnAddDrink_Click;
            // 
            // lblVat
            // 
            lblVat.AutoSize = true;
            lblVat.Location = new System.Drawing.Point(51, 129);
            lblVat.Name = "lblVat";
            lblVat.Size = new System.Drawing.Size(26, 15);
            lblVat.TabIndex = 17;
            lblVat.Text = "VAT";
            // 
            // tbxVat
            // 
            tbxVat.Location = new System.Drawing.Point(165, 126);
            tbxVat.Name = "tbxVat";
            tbxVat.Size = new System.Drawing.Size(171, 23);
            tbxVat.TabIndex = 4;
            // 
            // AddDrink
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(387, 345);
            Controls.Add(lblVat);
            Controls.Add(tbxVat);
            Controls.Add(btnAddDrink);
            Controls.Add(rbtnSoftDrink);
            Controls.Add(rbtnAlcoholic);
            Controls.Add(lblTypeDrink);
            Controls.Add(lblStock);
            Controls.Add(tbxStock);
            Controls.Add(lblPrice);
            Controls.Add(tbxPrice);
            Controls.Add(lblDrinkId);
            Controls.Add(tbxDrinkId);
            Controls.Add(lblDrinkName);
            Controls.Add(tbxDrinkName);
            Name = "AddDrink";
            Text = "AddDrink";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDrinkName;
        private System.Windows.Forms.TextBox tbxDrinkName;
        private System.Windows.Forms.Label lblDrinkId;
        private System.Windows.Forms.TextBox tbxDrinkId;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox tbxStock;
        private System.Windows.Forms.Label lblTypeDrink;
        private System.Windows.Forms.RadioButton rbtnAlcoholic;
        private System.Windows.Forms.RadioButton rbtnSoftDrink;
        private System.Windows.Forms.Button btnAddDrink;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.TextBox tbxVat;
    }
}