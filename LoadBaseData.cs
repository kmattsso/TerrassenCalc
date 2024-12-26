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
    public partial class LoadBaseData : UserControl, IObserver<Program.ReportPeriod>
    {
        public Form myParent;
        private IniFile dbIniFile;
        private String dbPath;

        

        //private readonly IDisposable unsubscriber;

        public LoadBaseData(Form parent)
        {
            myParent = parent;
            InitializeComponent();
            _ = Program.currentReportPeriod.Subscribe(this);
        }

        private void ButtonOpenDatafileCharging_Click(object sender, EventArgs e)
        {


            String dbFile = dbPath + "\\laddning.csv";
            String filePath = Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder charging", "").ToString();
            openFileDialog.InitialDirectory = filePath;
            openFileDialog.FileName = "*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Microsoft.Win32.Registry.SetValue(Program.keyName, "BaseData Folder charging", filePath);
                Directory.CreateDirectory(dbPath);
                File.Copy(openFileDialog.FileName, dbFile + ".org", true);

                LoadFileCharging(dbFile, true);
                ((MainForm)myParent).RecalculateReport();

                dbIniFile.SetValueDt("dbfile.charging.loaded", DateTime.Now);

            }
        }
        private void LoadFileCharging(String dbFile, bool copyNewfile)
        {
            int colCnt = 5;
            Program.dtCharging = new DataTable();
            Program.dtCharging.Columns.Add("Name", typeof(string));
            Program.dtCharging.Columns.Add("Export ID", typeof(string));
            Program.dtCharging.Columns.Add("Date start", typeof(string));
            Program.dtCharging.Columns.Add("Date end", typeof(string));
            Program.dtCharging.Columns.Add("Consumption (KWh)", typeof(string));
            //Program.dtCharging.Columns.Add("Total", typeof(string));
            //Program.dtCharging.Columns.Add("Cost per KWh", typeof(string));

            LoadFile("charging", colCnt, dbFile, copyNewfile, Program.dtCharging);

            dataGridViewCharging.Columns.Clear();
            dataGridViewCharging.Refresh();

            dataGridViewCharging.DataSource = Program.dtCharging;
        }

        private void ButtonOpenDatafileRelax_Click(object sender, EventArgs e)
        {

            String dbFile = dbPath + "\\relax.csv";
            String filePath = Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder relax", "").ToString();
            openFileDialog.InitialDirectory = filePath;
            openFileDialog.FileName = "*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Microsoft.Win32.Registry.SetValue(Program.keyName, "BaseData Folder relax", filePath);
                Directory.CreateDirectory(dbPath);
                File.Copy(openFileDialog.FileName, dbFile + ".org", true);

                LoadFileRelax(dbFile, true);
                ((MainForm)myParent).RecalculateReport();

                dbIniFile.SetValueDt("dbfile.relax.loaded", DateTime.Now);

            }
        }
        private void LoadFileRelax(String dbFile, bool copyNewfile)
        {

            int colCnt = 10;
            Program.dtRelax = new DataTable();
            Program.dtRelax.Columns.Add("Boknings-ID", typeof(string));
            Program.dtRelax.Columns.Add("Bokningsobjekt", typeof(string));
            Program.dtRelax.Columns.Add("Datum", typeof(string));
            Program.dtRelax.Columns.Add("Intervall", typeof(string));
            Program.dtRelax.Columns.Add("Lägenhetsnummer (3 siffror)", typeof(string));
            Program.dtRelax.Columns.Add("Egen kommentar om bokningsnummer", typeof(string));
            Program.dtRelax.Columns.Add("Datum när bokning gjordes", typeof(string));
            Program.dtRelax.Columns.Add("E-postadress", typeof(string));
            Program.dtRelax.Columns.Add("Telefonnummer", typeof(string));
            Program.dtRelax.Columns.Add("Hyr du gästrummet det datum som du bokar relaxen (ja/nej)?", typeof(string));
            //Program.dtRelax.Columns.Add("Extra 1", typeof(string));
            //Program.dtRelax.Columns.Add("Extra 2", typeof(string));
            //Program.dtRelax.Columns.Add("Intern notering", typeof(string));

            LoadFile("relax", colCnt, dbFile, copyNewfile, Program.dtRelax);

            dataGridViewRelax.Columns.Clear();
            dataGridViewRelax.Refresh();

            dataGridViewRelax.DataSource = Program.dtRelax;
        }

        private void ButtonOpenDatafileParking_Click(object sender, EventArgs e)
        {
            String dbFile = dbPath + "\\gästparkering.csv";
            String filePath = Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder parking", "").ToString();
            openFileDialog.InitialDirectory = filePath;
            openFileDialog.FileName = "*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Microsoft.Win32.Registry.SetValue(Program.keyName, "BaseData Folder parking", filePath);
                Directory.CreateDirectory(dbPath);
                File.Copy(openFileDialog.FileName, dbFile + ".org", true);

                LoadFileParking(dbFile, true);
                ((MainForm)myParent).RecalculateReport();

                dbIniFile.SetValueDt("dbfile.parking.loaded", DateTime.Now);

            }
        }
        private void LoadFileParking(string dbFile, bool copyNewfile)
        {

            int colCnt = 9;
            Program.dtParking = new DataTable();
            Program.dtParking.Columns.Add("Boknings-ID", typeof(string));
            Program.dtParking.Columns.Add("Bokningsobjekt", typeof(string));
            Program.dtParking.Columns.Add("Datum", typeof(string));
            Program.dtParking.Columns.Add("Intervall", typeof(string));
            Program.dtParking.Columns.Add("Lägenhetsnummer (3 siffror)", typeof(string));
            Program.dtParking.Columns.Add("Egen kommentar om bokningsnummer", typeof(string));
            Program.dtParking.Columns.Add("Datum när bokning gjordes", typeof(string));
            Program.dtParking.Columns.Add("E-postadress", typeof(string));
            Program.dtParking.Columns.Add("Telefonnummer", typeof(string));
            //Program.dtParking.Columns.Add("Extra 1", typeof(string));
            //Program.dtParking.Columns.Add("Extra 2", typeof(string));
            //Program.dtParking.Columns.Add("Extra 3", typeof(string));
            //Program.dtParking.Columns.Add("Intern notering", typeof(string));
            //Program.dtParking.Columns.Add("Extra 5", typeof(string));

            LoadFile("parking", colCnt, dbFile, copyNewfile, Program.dtParking);

            dataGridViewParking.Columns.Clear();
            dataGridViewParking.Refresh();

            dataGridViewParking.DataSource = Program.dtParking;
        }

        private void ButtonOpenDatafileApartment_Click(object sender, EventArgs e)
        {
            String dbFile = dbPath + "\\gästlägenhet.csv";
            String filePath = Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder apartment", "").ToString();
            openFileDialog.InitialDirectory = filePath;
            openFileDialog.FileName = "*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Microsoft.Win32.Registry.SetValue(Program.keyName, "BaseData Folder apartment", filePath);
                Directory.CreateDirectory(dbPath);
                File.Copy(openFileDialog.FileName, dbFile + ".org", true);

                LoadFileApartment(dbFile, true);
                ((MainForm)myParent).RecalculateReport();

                dbIniFile.SetValueDt("dbfile.apartment.loaded", DateTime.Now);

            }
        }
        private void LoadFileApartment(string dbFile, bool copyNewfile)
        {

            int colCnt = 9;
            Program.dtApartment = new DataTable();
            Program.dtApartment.Columns.Add("Boknings-ID", typeof(string));
            Program.dtApartment.Columns.Add("Bokningsobjekt", typeof(string));
            Program.dtApartment.Columns.Add("Datum", typeof(string));
            Program.dtApartment.Columns.Add("Intervall", typeof(string));
            Program.dtApartment.Columns.Add("Lägenhetsnummer (3 siffror)", typeof(string));
            Program.dtApartment.Columns.Add("Egen kommentar om bokningsnummer", typeof(string));
            Program.dtApartment.Columns.Add("Datum när bokning gjordes", typeof(string));
            Program.dtApartment.Columns.Add("E-postadress", typeof(string));
            Program.dtApartment.Columns.Add("Telefonnummer", typeof(string));
            //Program.dtApartment.Columns.Add("Extra 1", typeof(string));
            //Program.dtApartment.Columns.Add("Extra 2", typeof(string));
            //Program.dtApartment.Columns.Add("Extra 3", typeof(string));
            //Program.dtApartment.Columns.Add("Intern notering", typeof(string));
            //Program.dtApartment.Columns.Add("Extra 5", typeof(string));

            LoadFile("apartment", colCnt, dbFile, copyNewfile, Program.dtApartment);

            dataGridViewApartment.Columns.Clear();
            dataGridViewApartment.Refresh();

            dataGridViewApartment.DataSource = Program.dtApartment;

        }

        private void ButtonOpenDatafileLaundry_Click(object sender, EventArgs e)
        {

            String dbFile = dbPath + "\\tvättstuga.csv";

            String filePath = Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder laundry", "").ToString();
            openFileDialog.InitialDirectory = filePath;
            openFileDialog.FileName = "*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Microsoft.Win32.Registry.SetValue(Program.keyName, "BaseData Folder laundry", filePath);
                Directory.CreateDirectory(dbPath);
                File.Copy(openFileDialog.FileName, dbFile + ".org", true);

                LoadFileLaundry(dbFile, true);
                ((MainForm)myParent).RecalculateReport();

                dbIniFile.SetValueDt("dbfile.laundry.loaded", DateTime.Now);

            }
        }
        private void LoadFileLaundry(String dbFile, bool copyNewfile)
        {
            int colCnt = 9;
            Program.dtLaundry = new DataTable();
            Program.dtLaundry.Columns.Add("Boknings-ID", typeof(string));
            Program.dtLaundry.Columns.Add("Bokningsobjekt", typeof(string));
            Program.dtLaundry.Columns.Add("Datum", typeof(string));
            Program.dtLaundry.Columns.Add("Intervall", typeof(string));
            Program.dtLaundry.Columns.Add("Lägenhetsnummer (3 siffror)", typeof(string));
            Program.dtLaundry.Columns.Add("Egen kommentar om bokningsnummer", typeof(string));
            Program.dtLaundry.Columns.Add("Datum när bokning gjordes", typeof(string));
            Program.dtLaundry.Columns.Add("E-postadress", typeof(string));
            Program.dtLaundry.Columns.Add("Telefonnummer", typeof(string));
            //Program.dtLaundry.Columns.Add("Extra 1", typeof(string));
            //Program.dtLaundry.Columns.Add("Extra 2", typeof(string));
            //Program.dtLaundry.Columns.Add("Extra 3", typeof(string));
            //Program.dtLaundry.Columns.Add("Intern notering", typeof(string));
            //Program.dtLaundry.Columns.Add("Extra 5", typeof(string));

            LoadFile("laundry", colCnt, dbFile, copyNewfile, Program.dtLaundry);

            dataGridViewLaundry.Columns.Clear();
            dataGridViewLaundry.Refresh();

            dataGridViewLaundry.DataSource = Program.dtLaundry;
        }

        private void LoadFile(string tag, int colCnt, string dbFile, bool copyNewfile, DataTable dataTable)
        {
            String readFileName = (copyNewfile ? dbFile + ".org" : dbFile);
            String record;
            int early = 0, late = 0, n;
            DateTime tmp = DateTime.Now;

            if (File.Exists(readFileName))
            {
                string[] lines = System.IO.File.ReadAllLines(readFileName);

                if (copyNewfile && File.Exists(dbFile)) File.Delete(dbFile);
                using (StreamWriter newFile = File.AppendText((copyNewfile ? dbFile : dbFile + ".lock")))
                {
                    n = 0;
                    foreach (string line in lines)
                    {
                        n++;
                        if (n > Program.iniFile.GetValueInt("bookings." + tag + ".dataload.headers"))
                        {
                            String fileLine = line + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;";
                            var cols = fileLine.Split(';');

                            DataRow dr = dataTable.NewRow();
                            for (int cIndex = 0; cIndex < colCnt; cIndex++)
                            {
                                dr[cIndex] = cols[cIndex].Replace("�", "ä");
                            }
                            if (tag != "charging")
                            {
                                tmp = DateTime.ParseExact(dr["Datum"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("se-SV"));
                                if (tmp < Program.currentReportPeriod.ReportPeriod.Start)
                                    early++;
                                if (tmp > Program.currentReportPeriod.ReportPeriod.Stop)
                                    late++;
                            }
                            if (tag.Equals("charging") || (tmp >= Program.currentReportPeriod.ReportPeriod.Start && tmp <= Program.currentReportPeriod.ReportPeriod.Stop))
                            {
                                dataTable.Rows.Add(dr);
                                if (copyNewfile)
                                {
                                    record = "";
                                    for (int cIndex = 0; cIndex < colCnt; cIndex++)
                                    {
                                        record = record + dr[cIndex] + ";";
                                    }
                                    newFile.WriteLine(record);
                                }
                            }
                        }
                        else newFile.WriteLine("header");
                    }
                }
                if (File.Exists(dbFile + ".lock")) File.Delete(dbFile + ".lock");
            }

            if (early > 0 || late > 0)
                Dialog.ShowMessage("Vissa bokningar lästes inte in",
                        (early > 0 ? early.ToString() + " bokningar uteslöts pga att de infaller före denna periods startdatum\n" : "") +
                        (late > 0 ? late.ToString() + " bokningar uteslöts pga att de infaller efter denna periods slutdatum\n" : ""),
                         Dialog.Buttons.Ok, myParent);
        }


        private void ButtonOpenWebCharging_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.iniFile.GetValueStr("bookings.charging.website"));
        }

        private void ButtonOpenWebLaundry_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.iniFile.GetValueStr("bookings.laundry.website"));
        }

        private void ButtonOpenWebApartment_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.iniFile.GetValueStr("bookings.apartment.website"));
        }

        private void ButtonOpenWebParking_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.iniFile.GetValueStr("bookings.parking.website"));
        }

        private void ButtonOpenWebRelax_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.iniFile.GetValueStr("bookings.relax.website"));
        }

        void IObserver<Program.ReportPeriod>.OnNext(Program.ReportPeriod value)
        {

            String msg;

            labelReportPeriod.Text = "Vald rapportperiod: " + Program.currentReportPeriod.ReportPeriod.DisplayName;

            labelChargingCreateReportLabel.Text = "Skapa en rapport på websidan, med data från och med " + Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd") + " till och med " + Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd");
            labelLaundryCreateReportLabel.Text = labelChargingCreateReportLabel.Text;
            labelApartmentCreateReportLabel.Text = labelChargingCreateReportLabel.Text;
            labelParkingCreateReportLabel.Text = labelChargingCreateReportLabel.Text;
            labelRelaxCreateReportLabel.Text = labelChargingCreateReportLabel.Text;

            msg = Program.iniFile.GetValueStr("bookings.laundry.website.instructions");
            msg = msg.Replace("<start>", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<stop>", Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<program_folder>", Program.programPath);
            msg = msg.Replace("<sub_folder>", Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder laundry", "").ToString());
            msg = msg.Replace("\\n", Environment.NewLine);
            labelInstructionsLaundry.Text = msg;

            dataGridViewLaundry.Top = 171 + labelInstructionsLaundry.Height;
            dataGridViewLaundry.Height = tabPage2.Height - dataGridViewLaundry.Top - 16;
            labelLaundry41.Top = 142 + labelInstructionsLaundry.Height;
            labelLaundry42.Top = 142 + labelInstructionsLaundry.Height;
            labelLaundry31.Top = 102 + labelInstructionsLaundry.Height;
            labelLaundry32.Top = 102 + labelInstructionsLaundry.Height;
            buttonOpenDatafileLaundry.Top = 96 + labelInstructionsLaundry.Height;

            msg = Program.iniFile.GetValueStr("bookings.relax.website.instructions");
            msg = msg.Replace("<start>", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<stop>", Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<program_folder>", Program.programPath);
            msg = msg.Replace("<sub_folder>", Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder relax", "").ToString());
            msg = msg.Replace("\\n", Environment.NewLine);
            labelInstructionsRelax.Text = msg;

            dataGridViewRelax.Top = 171 + labelInstructionsRelax.Height;
            dataGridViewRelax.Height = tabPage5.Height - dataGridViewRelax.Top - 16;
            labelRelax41.Top = 142 + labelInstructionsRelax.Height;
            labelRelax42.Top = 142 + labelInstructionsRelax.Height;
            labelRelax31.Top = 102 + labelInstructionsRelax.Height;
            labelRelax32.Top = 102 + labelInstructionsRelax.Height;
            buttonOpenDatafileRelax.Top = 96 + labelInstructionsRelax.Height;

            msg = Program.iniFile.GetValueStr("bookings.apartment.website.instructions");
            msg = msg.Replace("<start>", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<stop>", Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<program_folder>", Program.programPath);
            msg = msg.Replace("<sub_folder>", Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder apartment", "").ToString());
            msg = msg.Replace("\\n", Environment.NewLine);
            labelInstructionsApartment.Text = msg;

            dataGridViewApartment.Top = 171 + labelInstructionsApartment.Height;
            dataGridViewApartment.Height = tabPage3.Height - dataGridViewApartment.Top - 16;
            labelApartment41.Top = 142 + labelInstructionsApartment.Height;
            labelApartment42.Top = 142 + labelInstructionsApartment.Height;
            labelApartment31.Top = 102 + labelInstructionsApartment.Height;
            labelApartment32.Top = 102 + labelInstructionsApartment.Height;
            buttonOpenDatafileApartment.Top = 96 + labelInstructionsApartment.Height;

            msg = Program.iniFile.GetValueStr("bookings.parking.website.instructions");
            msg = msg.Replace("<start>", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<stop>", Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<program_folder>", Program.programPath);
            msg = msg.Replace("<sub_folder>", Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder parking", "").ToString());
            msg = msg.Replace("\\n", Environment.NewLine);
            labelInstructionsParking.Text = msg;

            dataGridViewParking.Top = 171 + labelInstructionsParking.Height;
            dataGridViewParking.Height = tabPage3.Height - dataGridViewParking.Top - 16;
            labelParking41.Top = 142 + labelInstructionsParking.Height;
            labelParking42.Top = 142 + labelInstructionsParking.Height;
            labelParking31.Top = 102 + labelInstructionsParking.Height;
            labelParking32.Top = 102 + labelInstructionsParking.Height;
            buttonOpenDatafileParking.Top = 96 + labelInstructionsParking.Height;

            msg = Program.iniFile.GetValueStr("bookings.charging.website.instructions");
            msg = msg.Replace("<start>", Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<stop>", Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));
            msg = msg.Replace("<program_folder>", Program.programPath);
            msg = msg.Replace("<sub_folder>", Microsoft.Win32.Registry.GetValue(Program.keyName, "BaseData Folder charging", "").ToString());
            msg = msg.Replace("\\n", Environment.NewLine);
            labelInstructionsCharging.Text = msg;

            dataGridViewCharging.Top = 130 + labelInstructionsCharging.Height;
            dataGridViewCharging.Height = tabPage6.Height - dataGridViewCharging.Top - 16;
            //labelCharging41.Top = 142 + labelInstructionsCharging.Height;
            //labelCharging42.Top = 142 + labelInstructionsCharging.Height;
            labelCharging31.Top = 102 + labelInstructionsCharging.Height;
            labelCharging32.Top = 102 + labelInstructionsCharging.Height;
            buttonOpenDatafileCharging.Top = 96 + labelInstructionsCharging.Height;

            dbPath = Program.programPath + "\\" + Program.iniFile.GetValueStr("database.folder") + "\\" + Program.currentReportPeriod.ReportPeriod.DisplayName;
            dbIniFile = new IniFile(dbPath + "\\" + "db.parameter", new System.Text.UTF8Encoding(false));

            LoadFileLaundry(dbPath + "\\tvättstuga.csv", false);
            LoadFileApartment(dbPath + "\\gästlägenhet.csv", false);
            LoadFileParking(dbPath + "\\gästparkering.csv", false);
            LoadFileRelax(dbPath + "\\relax.csv", false);
            LoadFileCharging(dbPath + "\\laddning.csv", false);
        }

        void IObserver<Program.ReportPeriod>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<Program.ReportPeriod>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        private void DataGridViewLaundry_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String tmpPath = Path.GetTempPath();
                if (File.Exists(tmpPath + "\\tvättstuga.csv"))
                {
                    File.SetAttributes(tmpPath + "\\tvättstuga.csv", FileAttributes.Normal);
                    File.Delete(tmpPath + "\\tvättstuga.csv");
                }
                File.Copy(dbPath + "\\tvättstuga.csv", tmpPath + "\\tvättstuga.csv");
                File.SetAttributes(tmpPath + "\\tvättstuga.csv", FileAttributes.Temporary);
                File.SetAttributes(tmpPath + "\\tvättstuga.csv", FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(tmpPath + "\\tvättstuga.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        private void DataGridViewRelax_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String tmpPath = Path.GetTempPath();
                if (File.Exists(tmpPath + "\\relax.csv"))
                {
                    File.SetAttributes(tmpPath + "\\relax.csv", FileAttributes.Normal);
                    File.Delete(tmpPath + "\\relax.csv");
                }
                File.Copy(dbPath + "\\relax.csv", tmpPath + "\\relax.csv");
                File.SetAttributes(tmpPath + "\\relax.csv", FileAttributes.Temporary);
                File.SetAttributes(tmpPath + "\\relax.csv", FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(tmpPath + "\\relax.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        private void DataGridViewApartment_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String tmpPath = Path.GetTempPath();
                if (File.Exists(tmpPath + "\\gästlägenhet.csv"))
                {
                    File.SetAttributes(tmpPath + "\\gästlägenhet.csv", FileAttributes.Normal);
                    File.Delete(tmpPath + "\\gästlägenhet.csv");
                }
                File.Copy(dbPath + "\\gästlägenhet.csv", tmpPath + "\\gästlägenhet.csv");
                File.SetAttributes(tmpPath + "\\gästlägenhet.csv", FileAttributes.Temporary);
                File.SetAttributes(tmpPath + "\\gästlägenhet.csv", FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(tmpPath + "\\gästlägenhet.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void DataGridViewParking_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String tmpPath = Path.GetTempPath();
                if (File.Exists(tmpPath + "\\gästparkering.csv"))
                {
                    File.SetAttributes(tmpPath + "\\gästparkering.csv", FileAttributes.Normal);
                    File.Delete(tmpPath + "\\gästparkering.csv");
                }
                File.Copy(dbPath + "\\gästparkering.csv", tmpPath + "\\gästparkering.csv");
                File.SetAttributes(tmpPath + "\\gästparkering.csv", FileAttributes.Temporary);
                File.SetAttributes(tmpPath + "\\gästparkering.csv", FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(tmpPath + "\\gästparkering.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void DataGridViewCharging_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String tmpPath = Path.GetTempPath();
                if (File.Exists(tmpPath + "\\laddning.csv"))
                {
                    File.SetAttributes(tmpPath + "\\laddning.csv", FileAttributes.Normal);
                    File.Delete(tmpPath + "\\laddning.csv");
                }
                File.Copy(dbPath + "\\laddning.csv", tmpPath + "\\laddning.csv");
                File.SetAttributes(tmpPath + "\\laddning.csv", FileAttributes.Temporary);
                File.SetAttributes(tmpPath + "\\laddning.csv", FileAttributes.ReadOnly);
                System.Diagnostics.Process.Start(tmpPath + "\\laddning.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }
}
