using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerrassenCalc
{
    public partial class SetReportPeriod : UserControl
    {
        readonly Form myParent;

        public SetReportPeriod(Form parent)
        {
            myParent = parent;
            InitializeComponent();
            LoadReportPeriods();
        }

        private void LoadReportPeriods()
        {
            Program.ReportPeriod x = new Program.ReportPeriod((DateTime)Program.iniFile.GetValueDt("bookings.reports.start"));

            while (x.Next < (DateTime)Program.iniFile.GetValueDt("bookings.reports.end"))
            {
                comboBoxReportPeriod.Items.Add(x);
                if (x.Start == (DateTime)Program.iniFile.GetValueDt("bookings.reports.selected")) comboBoxReportPeriod.SelectedIndex = comboBoxReportPeriod.Items.Count - 1;
                x = new Program.ReportPeriod(x.Next);
            }

        }
        private void ComboBoxReportPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.SuspendLayout();
            Program.currentReportPeriod.ReportPeriod = ((Program.ReportPeriod)comboBoxReportPeriod.SelectedItem);
            Program.iniFile.SetValueStr("bookings.reports.selected", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));

            String dbPath = Program.programPath + "\\" + Program.iniFile.GetValueStr("database.folder") + "\\" + Program.currentReportPeriod.ReportPeriod.DisplayName;
            labelDataLoadedLaundry.Text = "Nej";
            labelDataLoadedRelax.Text = "Nej";
            labelDataLoadedApartment.Text = "Nej";
            labelDataLoadedParking.Text = "Nej";
            labelDataLoadedCharging.Text = "Nej";
            
            if (File.Exists(dbPath + "\\" + "db.parameter"))
            {
                IniFile dbIniFile = new IniFile(dbPath + "\\" + "db.parameter", new System.Text.UTF8Encoding(false));
                labelDataLoadedLaundry.Text = dbIniFile.GetValueDt("dbfile.laundry.loaded") == null ? "Nej" : ((DateTime)dbIniFile.GetValueDt("dbfile.laundry.loaded")).ToString("yyyy-MM-dd HH:mm:ss");
                labelDataLoadedRelax.Text = dbIniFile.GetValueDt("dbfile.relax.loaded") == null ? "Nej" : ((DateTime)dbIniFile.GetValueDt("dbfile.relax.loaded")).ToString("yyyy-MM-dd HH:mm:ss");
                labelDataLoadedApartment.Text = dbIniFile.GetValueDt("dbfile.apartment.loaded") == null ? "Nej" : ((DateTime)dbIniFile.GetValueDt("dbfile.apartment.loaded")).ToString("yyyy-MM-dd HH:mm:ss"); 
                labelDataLoadedParking.Text = dbIniFile.GetValueDt("dbfile.parking.loaded") == null ? "Nej" : ((DateTime)dbIniFile.GetValueDt("dbfile.parking.loaded")).ToString("yyyy-MM-dd HH:mm:ss");
                labelDataLoadedCharging.Text = dbIniFile.GetValueDt("dbfile.charging.loaded") == null ? "Nej" : ((DateTime)dbIniFile.GetValueDt("dbfile.charging.loaded")).ToString("yyyy-MM-dd HH:mm:ss");
            }

            labelReportPeriod.Text = "Vald rapportperiod: " + Program.currentReportPeriod.ReportPeriod.DisplayName;

            ((MainForm)myParent).RecalculateReport();

            this.Enabled = true;
            this.ResumeLayout();
        }

         private void ButtonOpenReport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.programPath + "\\Debiteringsunderlag\\" + Program.currentReportPeriod.ReportPeriod.FilePrefix + ".pdf");
        }

        private void SetReportPeriod_Paint_1(object sender, PaintEventArgs e)
        {
            labelElPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", Program.GetPrice("charging", Program.currentReportPeriod.ReportPeriod.Stop).PriceDbl);
        }
    }


}
