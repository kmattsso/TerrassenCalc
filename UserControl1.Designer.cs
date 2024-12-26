
namespace TerrassenCalc
{
    partial class UserControl1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewElectricity = new System.Windows.Forms.DataGridView();
            this.ElectricityCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnergyTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCostPerUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElectricityCostPerUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCostPerUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElectricity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewElectricity
            // 
            this.dataGridViewElectricity.AllowUserToAddRows = false;
            this.dataGridViewElectricity.AllowUserToDeleteRows = false;
            this.dataGridViewElectricity.AllowUserToResizeColumns = false;
            this.dataGridViewElectricity.AllowUserToResizeRows = false;
            this.dataGridViewElectricity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewElectricity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewElectricity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewElectricity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewElectricity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewElectricity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElectricityCost,
            this.GridCost,
            this.EnergyTax,
            this.Usage,
            this.TotalCost,
            this.TotalCostPerUsage,
            this.ElectricityCostPerUsage,
            this.GridCostPerUsage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewElectricity.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewElectricity.EnableHeadersVisualStyles = false;
            this.dataGridViewElectricity.Location = new System.Drawing.Point(150, 179);
            this.dataGridViewElectricity.MultiSelect = false;
            this.dataGridViewElectricity.Name = "dataGridViewElectricity";
            this.dataGridViewElectricity.ReadOnly = true;
            this.dataGridViewElectricity.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewElectricity.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewElectricity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewElectricity.Size = new System.Drawing.Size(848, 456);
            this.dataGridViewElectricity.TabIndex = 1;
            // 
            // ElectricityCost
            // 
            this.ElectricityCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ElectricityCost.HeaderText = "Elhandel";
            this.ElectricityCost.Name = "ElectricityCost";
            this.ElectricityCost.ReadOnly = true;
            this.ElectricityCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ElectricityCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ElectricityCost.ToolTipText = "Elhandelskostnad, totalbelopp SEK";
            // 
            // GridCost
            // 
            this.GridCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GridCost.HeaderText = "Elnät";
            this.GridCost.Name = "GridCost";
            this.GridCost.ReadOnly = true;
            this.GridCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GridCost.ToolTipText = "Elnätskostnad, totalbelopp SEK";
            // 
            // EnergyTax
            // 
            this.EnergyTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnergyTax.HeaderText = "Energiskatt";
            this.EnergyTax.Name = "EnergyTax";
            this.EnergyTax.ReadOnly = true;
            this.EnergyTax.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EnergyTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EnergyTax.ToolTipText = "Energiskatt, totalbelopp SEK";
            // 
            // Usage
            // 
            this.Usage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Usage.HeaderText = "Förbrukning";
            this.Usage.Name = "Usage";
            this.Usage.ReadOnly = true;
            this.Usage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Usage.ToolTipText = "Totalförbrukning kWh";
            // 
            // TotalCost
            // 
            this.TotalCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalCost.HeaderText = "Totalpris";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TotalCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalCost.ToolTipText = "Summa av Elhandel+Elnät+Energiskatt";
            // 
            // TotalCostPerUsage
            // 
            this.TotalCostPerUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalCostPerUsage.HeaderText = "Totalpris per kWh";
            this.TotalCostPerUsage.Name = "TotalCostPerUsage";
            this.TotalCostPerUsage.ReadOnly = true;
            this.TotalCostPerUsage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TotalCostPerUsage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalCostPerUsage.ToolTipText = "Totalpris/Förbrukning";
            // 
            // ElectricityCostPerUsage
            // 
            this.ElectricityCostPerUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ElectricityCostPerUsage.HeaderText = "Elhandel per kWh";
            this.ElectricityCostPerUsage.Name = "ElectricityCostPerUsage";
            this.ElectricityCostPerUsage.ReadOnly = true;
            this.ElectricityCostPerUsage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ElectricityCostPerUsage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ElectricityCostPerUsage.ToolTipText = "Elhandel/Förbrukning";
            // 
            // GridCostPerUsage
            // 
            this.GridCostPerUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GridCostPerUsage.HeaderText = "Elnät per kWh";
            this.GridCostPerUsage.Name = "GridCostPerUsage";
            this.GridCostPerUsage.ReadOnly = true;
            this.GridCostPerUsage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridCostPerUsage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GridCostPerUsage.ToolTipText = "Elnät/Förbrukning";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewElectricity);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1290, 681);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElectricity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewElectricity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElectricityCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnergyTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCostPerUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElectricityCostPerUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCostPerUsage;
    }
}
