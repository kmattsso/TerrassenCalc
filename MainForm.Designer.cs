
namespace TerrassenCalc
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelCurrentAction = new System.Windows.Forms.Panel();
            this.radioButtonActionPrices = new System.Windows.Forms.RadioButton();
            this.radioButtonActionLoadBaseData = new System.Windows.Forms.RadioButton();
            this.radioButtonActionAnalyseBaseData = new System.Windows.Forms.RadioButton();
            this.radioButtonActionReportPeriod = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonOpenReportFolder = new System.Windows.Forms.Button();
            this.radioButtonAdditionalData = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonInstallLatestVersion = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCurrentAction
            // 
            this.panelCurrentAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCurrentAction.BackColor = System.Drawing.Color.White;
            this.panelCurrentAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCurrentAction.Location = new System.Drawing.Point(237, 6);
            this.panelCurrentAction.Name = "panelCurrentAction";
            this.panelCurrentAction.Size = new System.Drawing.Size(1181, 623);
            this.panelCurrentAction.TabIndex = 21;
            this.panelCurrentAction.Resize += new System.EventHandler(this.PanelCurrentAction_Resize_1);
            // 
            // radioButtonActionPrices
            // 
            this.radioButtonActionPrices.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonActionPrices.Checked = true;
            this.radioButtonActionPrices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActionPrices.Location = new System.Drawing.Point(81, 5);
            this.radioButtonActionPrices.Name = "radioButtonActionPrices";
            this.radioButtonActionPrices.Size = new System.Drawing.Size(150, 50);
            this.radioButtonActionPrices.TabIndex = 25;
            this.radioButtonActionPrices.TabStop = true;
            this.radioButtonActionPrices.Text = "Justera priser";
            this.radioButtonActionPrices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonActionPrices.UseVisualStyleBackColor = true;
            this.radioButtonActionPrices.CheckedChanged += new System.EventHandler(this.RadioButtonActionPrices_CheckedChanged);
            // 
            // radioButtonActionLoadBaseData
            // 
            this.radioButtonActionLoadBaseData.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonActionLoadBaseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActionLoadBaseData.Location = new System.Drawing.Point(81, 117);
            this.radioButtonActionLoadBaseData.Name = "radioButtonActionLoadBaseData";
            this.radioButtonActionLoadBaseData.Size = new System.Drawing.Size(150, 50);
            this.radioButtonActionLoadBaseData.TabIndex = 27;
            this.radioButtonActionLoadBaseData.Text = "Importera bokningar";
            this.radioButtonActionLoadBaseData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonActionLoadBaseData.UseVisualStyleBackColor = true;
            this.radioButtonActionLoadBaseData.CheckedChanged += new System.EventHandler(this.RadioButtonActionLoadBaseData_CheckedChanged);
            // 
            // radioButtonActionAnalyseBaseData
            // 
            this.radioButtonActionAnalyseBaseData.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonActionAnalyseBaseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActionAnalyseBaseData.Location = new System.Drawing.Point(81, 173);
            this.radioButtonActionAnalyseBaseData.Name = "radioButtonActionAnalyseBaseData";
            this.radioButtonActionAnalyseBaseData.Size = new System.Drawing.Size(150, 50);
            this.radioButtonActionAnalyseBaseData.TabIndex = 29;
            this.radioButtonActionAnalyseBaseData.Text = "Analysera bokningar";
            this.radioButtonActionAnalyseBaseData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonActionAnalyseBaseData.UseVisualStyleBackColor = true;
            this.radioButtonActionAnalyseBaseData.CheckedChanged += new System.EventHandler(this.RadioButtonActionAnalyseBaseData_CheckedChanged);
            // 
            // radioButtonActionReportPeriod
            // 
            this.radioButtonActionReportPeriod.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonActionReportPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActionReportPeriod.Location = new System.Drawing.Point(81, 61);
            this.radioButtonActionReportPeriod.Name = "radioButtonActionReportPeriod";
            this.radioButtonActionReportPeriod.Size = new System.Drawing.Size(150, 50);
            this.radioButtonActionReportPeriod.TabIndex = 26;
            this.radioButtonActionReportPeriod.Text = "Välj rapportperiod";
            this.radioButtonActionReportPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonActionReportPeriod.UseVisualStyleBackColor = true;
            this.radioButtonActionReportPeriod.CheckedChanged += new System.EventHandler(this.ActionReportPeriod_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Steg 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Steg 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Steg 3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Steg 4:";
            // 
            // ButtonOpenReportFolder
            // 
            this.ButtonOpenReportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonOpenReportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOpenReportFolder.Location = new System.Drawing.Point(6, 579);
            this.ButtonOpenReportFolder.Name = "ButtonOpenReportFolder";
            this.ButtonOpenReportFolder.Size = new System.Drawing.Size(225, 50);
            this.ButtonOpenReportFolder.TabIndex = 35;
            this.ButtonOpenReportFolder.Text = "Visa historiska debiteringsunderlag";
            this.ButtonOpenReportFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenReportFolder.Click += new System.EventHandler(this.ButtonOpenReportFolder_Click);
            // 
            // radioButtonAdditionalData
            // 
            this.radioButtonAdditionalData.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAdditionalData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAdditionalData.Location = new System.Drawing.Point(81, 229);
            this.radioButtonAdditionalData.Name = "radioButtonAdditionalData";
            this.radioButtonAdditionalData.Size = new System.Drawing.Size(150, 50);
            this.radioButtonAdditionalData.TabIndex = 28;
            this.radioButtonAdditionalData.Text = "Extra debiteringar";
            this.radioButtonAdditionalData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAdditionalData.UseVisualStyleBackColor = true;
            this.radioButtonAdditionalData.CheckedChanged += new System.EventHandler(this.RadioButtonAdditionalData_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Steg 5:";
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateReport.Location = new System.Drawing.Point(81, 285);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(150, 50);
            this.buttonCreateReport.TabIndex = 38;
            this.buttonCreateReport.Text = "Skapa debiteringsunderlag";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.ButtonCreateReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Steg 6:";
            // 
            // buttonInstallLatestVersion
            // 
            this.buttonInstallLatestVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonInstallLatestVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstallLatestVersion.Location = new System.Drawing.Point(6, 6);
            this.buttonInstallLatestVersion.Name = "buttonInstallLatestVersion";
            this.buttonInstallLatestVersion.Size = new System.Drawing.Size(225, 567);
            this.buttonInstallLatestVersion.TabIndex = 40;
            this.buttonInstallLatestVersion.Text = "Det finns en uppdatering av programmet\r\n\r\nKlicka här för att installera\r\n\r\nAlla f" +
    "unktioner är avstängds till uppdatering gjorts";
            this.buttonInstallLatestVersion.UseVisualStyleBackColor = false;
            this.buttonInstallLatestVersion.Visible = false;
            this.buttonInstallLatestVersion.Click += new System.EventHandler(this.ButtonInstallLatestVersion_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1434, 670);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.buttonInstallLatestVersion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ButtonOpenReportFolder);
            this.tabPage1.Controls.Add(this.panelCurrentAction);
            this.tabPage1.Controls.Add(this.radioButtonActionPrices);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.radioButtonActionReportPeriod);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonCreateReport);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.radioButtonActionLoadBaseData);
            this.tabPage1.Controls.Add(this.radioButtonAdditionalData);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.radioButtonActionAnalyseBaseData);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1426, 637);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "    Debitering gemensamma utrymmen    ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1442, 684);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Skapa debiteringsunderlag för Brf Gröndalsterrassen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCurrentAction;
        private System.Windows.Forms.RadioButton radioButtonActionPrices;
        private System.Windows.Forms.RadioButton radioButtonActionLoadBaseData;
        private System.Windows.Forms.RadioButton radioButtonActionAnalyseBaseData;
        private System.Windows.Forms.RadioButton radioButtonActionReportPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonOpenReportFolder;
        private System.Windows.Forms.RadioButton radioButtonAdditionalData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonInstallLatestVersion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

