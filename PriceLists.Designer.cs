
namespace TerrassenCalc
{
    partial class PriceLists
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentLaundryPrice = new System.Windows.Forms.Label();
            this.labelCurrentRelaxPrice = new System.Windows.Forms.Label();
            this.labelCurrentApartmentPrice = new System.Windows.Forms.Label();
            this.labelCurrentParkingPrice = new System.Windows.Forms.Label();
            this.labelCurrentElectricityPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gällande priser just nu:";
            // 
            // labelCurrentLaundryPrice
            // 
            this.labelCurrentLaundryPrice.AutoSize = true;
            this.labelCurrentLaundryPrice.Location = new System.Drawing.Point(41, 39);
            this.labelCurrentLaundryPrice.Name = "labelCurrentLaundryPrice";
            this.labelCurrentLaundryPrice.Size = new System.Drawing.Size(58, 13);
            this.labelCurrentLaundryPrice.TabIndex = 2;
            this.labelCurrentLaundryPrice.Text = "Tvättstuga";
            // 
            // labelCurrentRelaxPrice
            // 
            this.labelCurrentRelaxPrice.AutoSize = true;
            this.labelCurrentRelaxPrice.Location = new System.Drawing.Point(41, 57);
            this.labelCurrentRelaxPrice.Name = "labelCurrentRelaxPrice";
            this.labelCurrentRelaxPrice.Size = new System.Drawing.Size(58, 13);
            this.labelCurrentRelaxPrice.TabIndex = 3;
            this.labelCurrentRelaxPrice.Text = "Tvättstuga";
            // 
            // labelCurrentApartmentPrice
            // 
            this.labelCurrentApartmentPrice.AutoSize = true;
            this.labelCurrentApartmentPrice.Location = new System.Drawing.Point(41, 75);
            this.labelCurrentApartmentPrice.Name = "labelCurrentApartmentPrice";
            this.labelCurrentApartmentPrice.Size = new System.Drawing.Size(58, 13);
            this.labelCurrentApartmentPrice.TabIndex = 4;
            this.labelCurrentApartmentPrice.Text = "Tvättstuga";
            // 
            // labelCurrentParkingPrice
            // 
            this.labelCurrentParkingPrice.AutoSize = true;
            this.labelCurrentParkingPrice.Location = new System.Drawing.Point(41, 93);
            this.labelCurrentParkingPrice.Name = "labelCurrentParkingPrice";
            this.labelCurrentParkingPrice.Size = new System.Drawing.Size(58, 13);
            this.labelCurrentParkingPrice.TabIndex = 5;
            this.labelCurrentParkingPrice.Text = "Tvättstuga";
            // 
            // labelCurrentElectricityPrice
            // 
            this.labelCurrentElectricityPrice.AutoSize = true;
            this.labelCurrentElectricityPrice.Location = new System.Drawing.Point(41, 111);
            this.labelCurrentElectricityPrice.Name = "labelCurrentElectricityPrice";
            this.labelCurrentElectricityPrice.Size = new System.Drawing.Size(58, 13);
            this.labelCurrentElectricityPrice.TabIndex = 6;
            this.labelCurrentElectricityPrice.Text = "Tvättstuga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Justera priser:";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(29, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 348);
            this.tabControl1.TabIndex = 15;
            // 
            // PriceLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentElectricityPrice);
            this.Controls.Add(this.labelCurrentParkingPrice);
            this.Controls.Add(this.labelCurrentApartmentPrice);
            this.Controls.Add(this.labelCurrentRelaxPrice);
            this.Controls.Add(this.labelCurrentLaundryPrice);
            this.Controls.Add(this.label1);
            this.Name = "PriceLists";
            this.Size = new System.Drawing.Size(494, 574);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentLaundryPrice;
        private System.Windows.Forms.Label labelCurrentRelaxPrice;
        private System.Windows.Forms.Label labelCurrentApartmentPrice;
        private System.Windows.Forms.Label labelCurrentParkingPrice;
        private System.Windows.Forms.Label labelCurrentElectricityPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
