namespace SomerenUI
{
    partial class EditDrink
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
            lblVat = new System.Windows.Forms.Label();
            tbxVat = new System.Windows.Forms.TextBox();
            btnUpdateDrink = new System.Windows.Forms.Button();
            rbtnSoftDrink = new System.Windows.Forms.RadioButton();
            rbtnAlcoholic = new System.Windows.Forms.RadioButton();
            lblTypeDrink = new System.Windows.Forms.Label();
            lblStock = new System.Windows.Forms.Label();
            tbxStock = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            tbxPrice = new System.Windows.Forms.TextBox();
            lblDrinkId = new System.Windows.Forms.Label();
            tbxDrinkId = new System.Windows.Forms.TextBox();
            lblDrinkName = new System.Windows.Forms.Label();
            tbxDrinkName = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // lblVat
            // 
            lblVat.AutoSize = true;
            lblVat.Location = new System.Drawing.Point(47, 123);
            lblVat.Name = "lblVat";
            lblVat.Size = new System.Drawing.Size(26, 15);
            lblVat.TabIndex = 31;
            lblVat.Text = "VAT";
            // 
            // tbxVat
            // 
            tbxVat.Location = new System.Drawing.Point(161, 120);
            tbxVat.Name = "tbxVat";
            tbxVat.Size = new System.Drawing.Size(171, 23);
            tbxVat.TabIndex = 4;
            // 
            // btnUpdateDrink
            // 
            btnUpdateDrink.Location = new System.Drawing.Point(95, 257);
            btnUpdateDrink.Name = "btnUpdateDrink";
            btnUpdateDrink.Size = new System.Drawing.Size(193, 43);
            btnUpdateDrink.TabIndex = 8;
            btnUpdateDrink.Text = "Update Drink";
            btnUpdateDrink.UseVisualStyleBackColor = true;
            btnUpdateDrink.Click += btnAddDrink_Click;
            // 
            // rbtnSoftDrink
            // 
            rbtnSoftDrink.AutoSize = true;
            rbtnSoftDrink.Location = new System.Drawing.Point(161, 206);
            rbtnSoftDrink.Name = "rbtnSoftDrink";
            rbtnSoftDrink.Size = new System.Drawing.Size(77, 19);
            rbtnSoftDrink.TabIndex = 7;
            rbtnSoftDrink.TabStop = true;
            rbtnSoftDrink.Text = "Soft Drink";
            rbtnSoftDrink.UseVisualStyleBackColor = true;
            // 
            // rbtnAlcoholic
            // 
            rbtnAlcoholic.AutoSize = true;
            rbtnAlcoholic.Location = new System.Drawing.Point(161, 181);
            rbtnAlcoholic.Name = "rbtnAlcoholic";
            rbtnAlcoholic.Size = new System.Drawing.Size(75, 19);
            rbtnAlcoholic.TabIndex = 6;
            rbtnAlcoholic.TabStop = true;
            rbtnAlcoholic.Text = "Alcoholic";
            rbtnAlcoholic.UseVisualStyleBackColor = true;
            // 
            // lblTypeDrink
            // 
            lblTypeDrink.AutoSize = true;
            lblTypeDrink.Location = new System.Drawing.Point(47, 181);
            lblTypeDrink.Name = "lblTypeDrink";
            lblTypeDrink.Size = new System.Drawing.Size(62, 15);
            lblTypeDrink.TabIndex = 26;
            lblTypeDrink.Text = "Type Drink";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new System.Drawing.Point(47, 152);
            lblStock.Name = "lblStock";
            lblStock.Size = new System.Drawing.Size(36, 15);
            lblStock.TabIndex = 25;
            lblStock.Text = "Stock";
            // 
            // tbxStock
            // 
            tbxStock.Location = new System.Drawing.Point(161, 149);
            tbxStock.Name = "tbxStock";
            tbxStock.Size = new System.Drawing.Size(171, 23);
            tbxStock.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(47, 94);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(33, 15);
            lblPrice.TabIndex = 23;
            lblPrice.Text = "Price";
            // 
            // tbxPrice
            // 
            tbxPrice.Location = new System.Drawing.Point(161, 91);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.Size = new System.Drawing.Size(171, 23);
            tbxPrice.TabIndex = 3;
            // 
            // lblDrinkId
            // 
            lblDrinkId.AutoSize = true;
            lblDrinkId.Location = new System.Drawing.Point(47, 36);
            lblDrinkId.Name = "lblDrinkId";
            lblDrinkId.Size = new System.Drawing.Size(49, 15);
            lblDrinkId.TabIndex = 21;
            lblDrinkId.Text = "Drink ID";
            // 
            // tbxDrinkId
            // 
            tbxDrinkId.Location = new System.Drawing.Point(161, 33);
            tbxDrinkId.Name = "tbxDrinkId";
            tbxDrinkId.Size = new System.Drawing.Size(171, 23);
            tbxDrinkId.TabIndex = 1;
            // 
            // lblDrinkName
            // 
            lblDrinkName.AutoSize = true;
            lblDrinkName.Location = new System.Drawing.Point(47, 65);
            lblDrinkName.Name = "lblDrinkName";
            lblDrinkName.Size = new System.Drawing.Size(68, 15);
            lblDrinkName.TabIndex = 19;
            lblDrinkName.Text = "Drink name";
            // 
            // tbxDrinkName
            // 
            tbxDrinkName.Location = new System.Drawing.Point(161, 62);
            tbxDrinkName.Name = "tbxDrinkName";
            tbxDrinkName.Size = new System.Drawing.Size(171, 23);
            tbxDrinkName.TabIndex = 2;
            // 
            // EditDrink
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(388, 350);
            Controls.Add(lblVat);
            Controls.Add(tbxVat);
            Controls.Add(btnUpdateDrink);
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
            Name = "EditDrink";
            Text = "EditDrink";
            Load += EditDrink_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.TextBox tbxVat;
        private System.Windows.Forms.Button btnUpdateDrink;
        private System.Windows.Forms.RadioButton rbtnSoftDrink;
        private System.Windows.Forms.RadioButton rbtnAlcoholic;
        private System.Windows.Forms.Label lblTypeDrink;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox tbxStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.Label lblDrinkId;
        private System.Windows.Forms.TextBox tbxDrinkId;
        private System.Windows.Forms.Label lblDrinkName;
        private System.Windows.Forms.TextBox tbxDrinkName;
    }
}