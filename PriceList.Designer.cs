
namespace TerrassenCalc
{
    partial class PriceList
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
            this.labelNewPriceHeader = new System.Windows.Forms.Label();
            this.checkBoxUseMaxDebit = new System.Windows.Forms.CheckBox();
            this.groupBoxUseMaxDebit = new System.Windows.Forms.GroupBox();
            this.labelPriceUnitsName = new System.Windows.Forms.Label();
            this.textBoxMaxDebitResetPeriod = new System.Windows.Forms.TextBox();
            this.labelUseMaxDebit2 = new System.Windows.Forms.Label();
            this.textBoxBulkPrice = new System.Windows.Forms.TextBox();
            this.labelUseMaxDebit1 = new System.Windows.Forms.Label();
            this.labelPriceUnitName = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerPriceDate = new System.Windows.Forms.DateTimePicker();
            this.listBoxPriceList = new System.Windows.Forms.ListBox();
            this.buttonSaveNewPrice = new System.Windows.Forms.Button();
            this.buttonRemovePrice = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxUseMaxDebit.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNewPriceHeader
            // 
            this.labelNewPriceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPriceHeader.Location = new System.Drawing.Point(15, 17);
            this.labelNewPriceHeader.Name = "labelNewPriceHeader";
            this.labelNewPriceHeader.Size = new System.Drawing.Size(333, 20);
            this.labelNewPriceHeader.TabIndex = 34;
            this.labelNewPriceHeader.Text = "Skapa nytt pris:";
            this.labelNewPriceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxUseMaxDebit
            // 
            this.checkBoxUseMaxDebit.AutoSize = true;
            this.checkBoxUseMaxDebit.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxUseMaxDebit.Location = new System.Drawing.Point(24, 75);
            this.checkBoxUseMaxDebit.Name = "checkBoxUseMaxDebit";
            this.checkBoxUseMaxDebit.Size = new System.Drawing.Size(133, 17);
            this.checkBoxUseMaxDebit.TabIndex = 26;
            this.checkBoxUseMaxDebit.Text = "Tillämpa maxdebitering";
            this.checkBoxUseMaxDebit.UseVisualStyleBackColor = false;
            this.checkBoxUseMaxDebit.CheckedChanged += new System.EventHandler(this.CheckBoxUseMaxDebit_CheckedChanged);
            // 
            // groupBoxUseMaxDebit
            // 
            this.groupBoxUseMaxDebit.Controls.Add(this.labelPriceUnitsName);
            this.groupBoxUseMaxDebit.Controls.Add(this.textBoxMaxDebitResetPeriod);
            this.groupBoxUseMaxDebit.Controls.Add(this.labelUseMaxDebit2);
            this.groupBoxUseMaxDebit.Controls.Add(this.textBoxBulkPrice);
            this.groupBoxUseMaxDebit.Controls.Add(this.labelUseMaxDebit1);
            this.groupBoxUseMaxDebit.Enabled = false;
            this.groupBoxUseMaxDebit.Location = new System.Drawing.Point(18, 75);
            this.groupBoxUseMaxDebit.Name = "groupBoxUseMaxDebit";
            this.groupBoxUseMaxDebit.Size = new System.Drawing.Size(408, 68);
            this.groupBoxUseMaxDebit.TabIndex = 27;
            this.groupBoxUseMaxDebit.TabStop = false;
            // 
            // labelPriceUnitsName
            // 
            this.labelPriceUnitsName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPriceUnitsName.Location = new System.Drawing.Point(257, 41);
            this.labelPriceUnitsName.Name = "labelPriceUnitsName";
            this.labelPriceUnitsName.Size = new System.Drawing.Size(125, 20);
            this.labelPriceUnitsName.TabIndex = 13;
            this.labelPriceUnitsName.Text = "timmar";
            this.labelPriceUnitsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMaxDebitResetPeriod
            // 
            this.textBoxMaxDebitResetPeriod.Location = new System.Drawing.Point(190, 42);
            this.textBoxMaxDebitResetPeriod.Name = "textBoxMaxDebitResetPeriod";
            this.textBoxMaxDebitResetPeriod.Size = new System.Drawing.Size(65, 20);
            this.textBoxMaxDebitResetPeriod.TabIndex = 12;
            this.textBoxMaxDebitResetPeriod.Leave += new System.EventHandler(this.TextBoxMaxDebitResetPeriod_Leave);
            // 
            // labelUseMaxDebit2
            // 
            this.labelUseMaxDebit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUseMaxDebit2.Location = new System.Drawing.Point(6, 41);
            this.labelUseMaxDebit2.Name = "labelUseMaxDebit2";
            this.labelUseMaxDebit2.Size = new System.Drawing.Size(195, 20);
            this.labelUseMaxDebit2.TabIndex = 11;
            this.labelUseMaxDebit2.Text = "för varje sammanhängande period om";
            this.labelUseMaxDebit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxBulkPrice
            // 
            this.textBoxBulkPrice.Location = new System.Drawing.Point(243, 20);
            this.textBoxBulkPrice.Name = "textBoxBulkPrice";
            this.textBoxBulkPrice.Size = new System.Drawing.Size(65, 20);
            this.textBoxBulkPrice.TabIndex = 10;
            this.textBoxBulkPrice.Leave += new System.EventHandler(this.TextBoxBulkPrice_Leave);
            // 
            // labelUseMaxDebit1
            // 
            this.labelUseMaxDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUseMaxDebit1.Location = new System.Drawing.Point(6, 20);
            this.labelUseMaxDebit1.Name = "labelUseMaxDebit1";
            this.labelUseMaxDebit1.Size = new System.Drawing.Size(234, 19);
            this.labelUseMaxDebit1.TabIndex = 5;
            this.labelUseMaxDebit1.Text = "Istället för det ovan angivna priset debiteras max";
            this.labelUseMaxDebit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPriceUnitName
            // 
            this.labelPriceUnitName.Location = new System.Drawing.Point(323, 40);
            this.labelPriceUnitName.Name = "labelPriceUnitName";
            this.labelPriceUnitName.Size = new System.Drawing.Size(126, 20);
            this.labelPriceUnitName.TabIndex = 25;
            this.labelPriceUnitName.Text = "per timme";
            this.labelPriceUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(255, 40);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(65, 20);
            this.textBoxPrice.TabIndex = 24;
            this.textBoxPrice.Leave += new System.EventHandler(this.TextBoxPrice_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(205, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "är priset";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Från och med";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerPriceDate
            // 
            this.dateTimePickerPriceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerPriceDate.Location = new System.Drawing.Point(93, 40);
            this.dateTimePickerPriceDate.Name = "dateTimePickerPriceDate";
            this.dateTimePickerPriceDate.Size = new System.Drawing.Size(106, 20);
            this.dateTimePickerPriceDate.TabIndex = 21;
            // 
            // listBoxPriceList
            // 
            this.listBoxPriceList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBoxPriceList.FormattingEnabled = true;
            this.listBoxPriceList.Location = new System.Drawing.Point(18, 219);
            this.listBoxPriceList.Name = "listBoxPriceList";
            this.listBoxPriceList.Size = new System.Drawing.Size(408, 134);
            this.listBoxPriceList.TabIndex = 18;
            // 
            // buttonSaveNewPrice
            // 
            this.buttonSaveNewPrice.Location = new System.Drawing.Point(18, 150);
            this.buttonSaveNewPrice.Name = "buttonSaveNewPrice";
            this.buttonSaveNewPrice.Size = new System.Drawing.Size(408, 22);
            this.buttonSaveNewPrice.TabIndex = 20;
            this.buttonSaveNewPrice.Text = "Lägg till det nya priset i prislistan";
            this.buttonSaveNewPrice.UseVisualStyleBackColor = true;
            this.buttonSaveNewPrice.Click += new System.EventHandler(this.ButtonSaveNewPrice_Click);
            // 
            // buttonRemovePrice
            // 
            this.buttonRemovePrice.Location = new System.Drawing.Point(18, 362);
            this.buttonRemovePrice.Name = "buttonRemovePrice";
            this.buttonRemovePrice.Size = new System.Drawing.Size(408, 22);
            this.buttonRemovePrice.TabIndex = 19;
            this.buttonRemovePrice.Text = "Radera det markerade priset från prislistan";
            this.buttonRemovePrice.UseVisualStyleBackColor = true;
            this.buttonRemovePrice.Click += new System.EventHandler(this.ButtonRemovePrice_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Gällande priser:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 36;
            // 
            // PriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNewPriceHeader);
            this.Controls.Add(this.buttonRemovePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSaveNewPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.checkBoxUseMaxDebit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPriceList);
            this.Controls.Add(this.labelPriceUnitName);
            this.Controls.Add(this.groupBoxUseMaxDebit);
            this.Controls.Add(this.dateTimePickerPriceDate);
            this.Name = "PriceList";
            this.Size = new System.Drawing.Size(452, 404);
            this.groupBoxUseMaxDebit.ResumeLayout(false);
            this.groupBoxUseMaxDebit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewPriceHeader;
        private System.Windows.Forms.CheckBox checkBoxUseMaxDebit;
        private System.Windows.Forms.GroupBox groupBoxUseMaxDebit;
        private System.Windows.Forms.Label labelPriceUnitsName;
        private System.Windows.Forms.TextBox textBoxMaxDebitResetPeriod;
        private System.Windows.Forms.Label labelUseMaxDebit2;
        private System.Windows.Forms.TextBox textBoxBulkPrice;
        private System.Windows.Forms.Label labelUseMaxDebit1;
        private System.Windows.Forms.Label labelPriceUnitName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerPriceDate;
        private System.Windows.Forms.ListBox listBoxPriceList;
        public System.Windows.Forms.Button buttonRemovePrice;
        public System.Windows.Forms.Button buttonSaveNewPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
