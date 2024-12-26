using Helper;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Helper.StringExtensions;

namespace TerrassenCalc
{

    public partial class MainForm : Form
    {
        
        readonly LoadBaseData loadBaseData;
        readonly SetReportPeriod setReportPeriod;
        readonly PriceLists priceLists;
        readonly AdditionalData additionalData;
        readonly AnalyseBaseData analyseBaseData;

        public MainForm()
        {
            InitializeComponent();

            loadBaseData = new LoadBaseData(this);
            additionalData = new AdditionalData(this);
            analyseBaseData = new AnalyseBaseData();
            priceLists = new PriceLists(this);
            setReportPeriod = new SetReportPeriod(this);

            loadBaseData.Size = panelCurrentAction.Size;
            priceLists.Size = panelCurrentAction.Size;
            analyseBaseData.Size = panelCurrentAction.Size;

            radioButtonActionPrices.Checked = true;

            String version = (ApplicationDeployment.IsNetworkDeployed 
                                ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                                : Assembly.GetExecutingAssembly().GetName().Version.Major.ToString());

            Program.iniFile.SetValueStr("Installed.Version." + Environment.MachineName.ToLower(), version);
            //buttonInstallLatestVersion.Visible = Program.iniFile.GetValueBool("Show.installbutton." + Environment.MachineName.ToLower());
            if (Program.iniFile.GetValueBool("Show.installbutton." + Environment.MachineName.ToLower()))
            {
                buttonInstallLatestVersion.Visible = true;
                radioButtonActionPrices.Enabled = false;
                radioButtonActionAnalyseBaseData.Enabled = false;
                radioButtonActionReportPeriod.Enabled = false;
                radioButtonAdditionalData.Enabled = false;
                buttonCreateReport.Enabled = false;
                radioButtonActionLoadBaseData.Enabled = false;
            }
            else
            {
                LoadCurrentAction();
            }

        }
        
        public void LoadCurrentAction()
        {
            panelCurrentAction.Controls.Clear();
            if (radioButtonActionPrices.Checked) panelCurrentAction.Controls.Add(priceLists);
            else if (radioButtonActionReportPeriod.Checked) panelCurrentAction.Controls.Add(setReportPeriod);
            else if (radioButtonActionLoadBaseData.Checked) panelCurrentAction.Controls.Add(loadBaseData);
            else if (radioButtonAdditionalData.Checked) panelCurrentAction.Controls.Add(additionalData);
            else if (radioButtonActionAnalyseBaseData.Checked)
            {
                panelCurrentAction.Controls.Add(analyseBaseData);
                analyseBaseData.labelReportPeriod.Text = "Vald rapportperiod: " + Program.currentReportPeriod.ReportPeriod.DisplayName;
            }
        }

        private void PanelCurrentAction_Resize(object sender, EventArgs e)
        {
            loadBaseData.Size = panelCurrentAction.Size;
            priceLists.Size = panelCurrentAction.Size;
            additionalData.Size = panelCurrentAction.Size;
            analyseBaseData.Size = panelCurrentAction.Size;
        }

        private void RadioButtonActionPrices_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }

        private void RadioButtonActionLoadBaseData_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }
        private void RadioButtonAdditionalData_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }
        private void RadioButtonActionAnalyseBaseData_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }


        private void ActionReportPeriod_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAction();
        }

        private void ButtonOpenReportFolder_Click(object sender, EventArgs e)
        {
                String path = Program.programPath + "\\Debiteringsunderlag";
                System.Diagnostics.Process.Start(path);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int t, l, w, h;
            bool m;

            t = int.Parse(Microsoft.Win32.Registry.GetValue(Program.keyName, "Mainform Top", "").ToString().NVL("0"));
            l = int.Parse(Microsoft.Win32.Registry.GetValue(Program.keyName, "Mainform Left", "").ToString().NVL("0"));
            w = int.Parse(Microsoft.Win32.Registry.GetValue(Program.keyName, "Mainform Width", "").ToString().NVL("500"));
            h = int.Parse(Microsoft.Win32.Registry.GetValue(Program.keyName, "Mainform Height", "").ToString().NVL("400"));
            m = (bool) Microsoft.Win32.Registry.GetValue(Program.keyName, "Mainform Maximized", "True").ToString().Equals("True");

            if (m) this.WindowState = FormWindowState.Maximized;
            this.Top = t;
            this.Left = l;
            this.Width = w;
            this.Height = h;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(Program.keyName, "Mainform Maximized", (this.WindowState == FormWindowState.Maximized).ToString(), Microsoft.Win32.RegistryValueKind.String);
            Microsoft.Win32.Registry.SetValue(Program.keyName, "Mainform Top", this.Top, Microsoft.Win32.RegistryValueKind.String);
            Microsoft.Win32.Registry.SetValue(Program.keyName, "Mainform Left", this.Left, Microsoft.Win32.RegistryValueKind.String);
            Microsoft.Win32.Registry.SetValue(Program.keyName, "Mainform Width", this.Width, Microsoft.Win32.RegistryValueKind.String);
            Microsoft.Win32.Registry.SetValue(Program.keyName, "Mainform Height", this.Height, Microsoft.Win32.RegistryValueKind.String);
        }

        private void ButtonCreateReport_Click(object sender, EventArgs e)
        {
            String path = Program.programPath + "\\Debiteringsunderlag";
            String file = Program.currentReportPeriod.ReportPeriod.FilePrefix + ".pdf";



            if (File.Exists(path + "\\" + file))
            {
                File.SetAttributes(path + "\\" + file, FileAttributes.Normal);
                try
                {
                    File.Delete(path + "\\" + file);
                }
                catch
                {
                    Dialog.ShowMessage("Kan inte öppna filen", "Filen \"" + file + "\" kan inte öppnas, den är antagligen redan öppen i ett annat fönster.\\nStäng detta fönster och försök igen.", Dialog.Buttons.Ok, this);
                    return;
                }
            }

            String x = CreatePDFReport(path + "\\" + file, Program.report, Program.dtAdditional);
            if (x!= null) System.Diagnostics.Process.Start(x);
        }

        public void RecalculateReport()
        {
            String app;
            double runningCost, actualCost, adjustedCost, numberOfEventsActual, numberOfEventsAdjusted, highLightEvents, highLight1, highLight2;
            TotalCosts totalCosts = new TotalCosts();
            int bulkCnt, bulkInc, reportColumnCost, reportColumnAdjustedCost, dateFetchType, numberOfEventsType, w, h;
            DateTime timeSlotEnd = new DateTime(), timeSlotStart = new DateTime();
            String lghColumnName = null, dateColumnName = null, timeSlotColumnName = null, numberOfEventsColumnName = null;
            Program.PriceListEntry priceListEntry = null;
            DataTable dtCalculated;
            bool newApp, newTime, newBulkPeriod;
            Program.report = new DataTable();
            HashSet<TimeSlot> apartmentTimeSlots = new HashSet<TimeSlot>();


            //Create report
            Program.report.Columns.Add(new DataColumn("Lägenhet", typeof(string)));
            Program.report.Columns.Add(new DataColumn("Tvättstuga\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Tvättstuga", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Relax\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Relax", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Gästlägenhet\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Gästlägenhet", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Gästparkering\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Gästparkering", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Laddning\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Laddning", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Summa\n(ojusterad)", typeof(double)));
            Program.report.Columns.Add(new DataColumn("Summa", typeof(double)));
            Program.report.Rows.Add(new Object[] { "101" });
            Program.report.Rows.Add(new Object[] { "102" });
            Program.report.Rows.Add(new Object[] { "103" });
            Program.report.Rows.Add(new Object[] { "104" });
            Program.report.Rows.Add(new Object[] { "105" });
            Program.report.Rows.Add(new Object[] { "106" });
            Program.report.Rows.Add(new Object[] { "107" });
            Program.report.Rows.Add(new Object[] { "108" });
            Program.report.Rows.Add(new Object[] { "201" });
            Program.report.Rows.Add(new Object[] { "202" });
            Program.report.Rows.Add(new Object[] { "203" });
            Program.report.Rows.Add(new Object[] { "204" });
            Program.report.Rows.Add(new Object[] { "205" });
            Program.report.Rows.Add(new Object[] { "206" });
            Program.report.Rows.Add(new Object[] { "207" });
            Program.report.Rows.Add(new Object[] { "208" });
            Program.report.Rows.Add(new Object[] { "209" });
            Program.report.Rows.Add(new Object[] { "210" });
            Program.report.Rows.Add(new Object[] { "211" });
            Program.report.Rows.Add(new Object[] { "212" });
            Program.report.Rows.Add(new Object[] { "213" });
            Program.report.Rows.Add(new Object[] { "301" });
            Program.report.Rows.Add(new Object[] { "302" });

            // Analyse basadata
            analyseBaseData.reportTotal = new DataTable();
            analyseBaseData.reportTotal.Columns.Add(new DataColumn("Objekt", typeof(string)));
            analyseBaseData.reportTotal.Columns.Add(new DataColumn("Summa\n(ojusterad)", typeof(double)));
            analyseBaseData.reportTotal.Columns.Add(new DataColumn("Summa", typeof(double)));

            // NB relax must be processed after apartment for relax rebate logic to work
            foreach (string tag in new String[] { "parking", "laundry", "apartment", "charging", "relax" })
            {

                // Create costlist
                dtCalculated = new DataTable();
                dtCalculated.Columns.Add(new DataColumn("app", typeof(string)));
                dtCalculated.Columns.Add(new DataColumn("cost", typeof(string)));
                dtCalculated.Columns.Add(new DataColumn("adjustedCost", typeof(string)));

                DataRow[] rows = null;

                switch (tag)
                {
                    case "parking":
                        lghColumnName = "Lägenhetsnummer (3 siffror)";
                        dateColumnName = "Datum";
                        timeSlotColumnName = "Intervall";
                        numberOfEventsColumnName = "";
                        numberOfEventsType = 1;
                        dateFetchType = 1;
                        reportColumnCost = 7;
                        reportColumnAdjustedCost = 8;
                        rows = Program.dtParking.Select("[" + lghColumnName + "] NOT IN ('000')", "[" + lghColumnName + "] ASC, [" + dateColumnName + "] ASC, [" + timeSlotColumnName + "] ASC");
                        break;
                    case "laundry":
                        lghColumnName = "Lägenhetsnummer (3 siffror)";
                        dateColumnName = "Datum";
                        timeSlotColumnName = "Intervall";
                        numberOfEventsColumnName = "";
                        numberOfEventsType = 1;
                        dateFetchType = 1;
                        reportColumnCost = 1;
                        reportColumnAdjustedCost = 2;
                        rows = Program.dtLaundry.Select("[" + lghColumnName + "] NOT IN ('000')", "[" + lghColumnName + "] ASC, [" + dateColumnName + "] ASC, [" + timeSlotColumnName + "] ASC");
                        break;
                    case "relax":
                        lghColumnName = "Lägenhetsnummer (3 siffror)";
                        dateColumnName = "Datum";
                        timeSlotColumnName = "Intervall";
                        numberOfEventsColumnName = "";
                        numberOfEventsType = 3;
                        dateFetchType = 1;
                        reportColumnCost = 3;
                        reportColumnAdjustedCost = 4;
                        rows = Program.dtRelax.Select("[" + lghColumnName + "] NOT IN ('000')", "[" + lghColumnName + "] ASC, [" + dateColumnName + "] ASC, [" + timeSlotColumnName + "] ASC");
                        break;
                    case "apartment":
                        lghColumnName = "Lägenhetsnummer (3 siffror)";
                        dateColumnName = "Datum";
                        timeSlotColumnName = "Intervall";
                        numberOfEventsColumnName = "";
                        numberOfEventsType = 1;
                        dateFetchType = 3;
                        reportColumnCost = 5;
                        reportColumnAdjustedCost = 6;
                        rows = Program.dtApartment.Select("[" + lghColumnName + "] NOT IN ('000')", "[" + lghColumnName + "] ASC, [" + dateColumnName + "] ASC, [" + timeSlotColumnName + "] ASC");
                        break;
                    case "charging":
                        lghColumnName = "Export ID";
                        dateColumnName = "Date start";
                        timeSlotColumnName = "";
                        numberOfEventsColumnName = "Consumption (kWh)";
                        numberOfEventsType = 2;
                        dateFetchType = 2;
                        reportColumnCost = 9;
                        reportColumnAdjustedCost = 10;
                        rows = Program.dtCharging.Select("[" + lghColumnName + "] NOT IN ('000')", "[" + lghColumnName + "] ASC, [" + dateColumnName + "] ASC");
                        break;
                    default:
                        reportColumnCost = 0;
                        dateFetchType = 0;
                        reportColumnAdjustedCost = 0;
                        numberOfEventsType = 0;
                        break;
                }
                int rowCount = rows.Count();

                adjustedCost = 0d;
                runningCost = 0d;
                actualCost = 0d;
                bulkCnt = 0;
                newTime = false;
                bulkInc = Program.iniFile.GetValueInt("price." + tag + ".unitsize");

                highLightEvents = 0d;
                highLight1 = 0d;
                highLight2 = 0d;

                Boolean rounded = false;

                if (rowCount > 0)
                {

                    switch (dateFetchType)
                    {
                        case 1:
                            priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[0].Field<String>(dateColumnName) + rows[0].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture));
                            break;
                        case 2:
                            priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[0].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture));
                            break;
                        case 3:
                            priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[0].Field<String>(dateColumnName) + rows[0].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture));
                            break;
                    }


                    for (int i = 0; i < rowCount; i++)  // Loop over bookings
                    {

                        app = rows[i].Field<String>(lghColumnName);
                        switch (dateFetchType)
                        {
                            case 1:
                                timeSlotStart = DateTime.ParseExact(rows[i].Field<String>(dateColumnName) + rows[i].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture);
                                timeSlotEnd = DateTime.ParseExact(rows[i].Field<String>(dateColumnName) + rows[i].Field<String>(timeSlotColumnName).Substring(6, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture);
                                break;
                            case 2:
                                timeSlotStart = DateTime.ParseExact(rows[i].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                                timeSlotEnd = DateTime.ParseExact(rows[i].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                                break;
                            case 3:
                                timeSlotStart = DateTime.ParseExact(rows[i].Field<String>(dateColumnName) + rows[i].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture);
                                timeSlotEnd = timeSlotStart.AddDays(1);
                                break;
                        }


                        // Save the apartment booking to calculate relax rebate later
                        if (tag == "apartment")
                        {
                            apartmentTimeSlots.Add(new TimeSlot(app, timeSlotStart, timeSlotEnd));
                        }


                        bulkCnt += bulkInc;
                        if (bulkCnt == bulkInc)
                            switch (dateFetchType)
                            {
                                case 1:
                                    priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[i].Field<String>(dateColumnName) + rows[i].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture));
                                    break;
                                case 2:
                                    priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[i].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture));
                                    break;
                                case 3:
                                    priceListEntry = Program.GetPrice(tag, DateTime.ParseExact(rows[i].Field<String>(dateColumnName) + rows[i].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture));
                                    break;
                            }

                        numberOfEventsActual = 1d;
                        numberOfEventsAdjusted = 1d;
                        if (numberOfEventsType == 1)
                        {
                        }
                        else if (numberOfEventsType == 2)
                        {
                            numberOfEventsActual = Double.Parse(rows[i].Field<String>(numberOfEventsColumnName));
                            numberOfEventsAdjusted = numberOfEventsActual;
                        }
                        else if (numberOfEventsType == 3)  //Relax
                        {
                            if (Program.currentReportPeriod.ReportPeriod.Start >= Program.iniFile.GetValueDt("special.auto_calculate_relax+apartment_rebate_after"))
                            {   // Check if same booker also booked the apartment
                                foreach (TimeSlot t in apartmentTimeSlots)
                                {
                                    if (app.Equals(t.app) && timeSlotStart >= t.timeSlotStart && timeSlotStart <= t.timeSlotEnd)
                                    {
                                        numberOfEventsAdjusted = 0d;
                                        highLight2 += numberOfEventsActual;
                                        break;
                                    }
                                }
                            }
                            else
                            {   // Have the booker claimed they also use the appartment?
                                String x = rows[i].Field<String>("Hyr du gästrummet det datum som du bokar relaxen (ja/nej)?").ToLower().Trim();
                                if (x.Equals("ja") || x.Equals("j") || x.Equals("yes") || x.Equals("y") || x.Equals("1"))
                                {
                                    numberOfEventsAdjusted = 0d;
                                    highLight2 += numberOfEventsActual;
                                }
                            }
                        }

                        highLightEvents += numberOfEventsActual;

                        actualCost += priceListEntry.PriceDbl * numberOfEventsActual;
                        runningCost += priceListEntry.PriceDbl * numberOfEventsAdjusted;

                        if (runningCost > priceListEntry.BulkPriceDbl)
                        {
                            runningCost = priceListEntry.BulkPriceDbl;
                            highLight1 += 1;
                        }


                        //Reset point comming up?
                        if (i < rowCount - 1)
                        {
                            if (app != rows[i + 1].Field<String>(lghColumnName)) newApp = true;
                            else newApp = false;

                            switch (dateFetchType)
                            {
                                case 1:
                                    if (timeSlotEnd != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName) + rows[i + 1].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture)
                                        && timeSlotEnd.AddDays(1d) != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName) + rows[i + 1].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture))
                                        newTime = true;
                                    else newTime = false;
                                    break;
                                case 2:
                                    if (timeSlotEnd != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture)
                                        && timeSlotEnd.AddDays(1d) != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName), "yyyy-MM-dd", CultureInfo.CurrentCulture))
                                        newTime = true;
                                    else newTime = false;
                                    break;
                                case 3:
                                    if (timeSlotEnd != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName) + rows[i + 1].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture)
                                        && timeSlotEnd.AddDays(1d) != DateTime.ParseExact(rows[i + 1].Field<String>(dateColumnName) + rows[i + 1].Field<String>(timeSlotColumnName).Substring(0, 5).Replace("24:00", "00:00"), "yyyy-MM-ddHH:mm", CultureInfo.CurrentCulture))
                                        newTime = true;
                                    else newTime = false;
                                    break;
                            }

                            if (bulkCnt + 1 > priceListEntry.BulkResetPeriodInt) newBulkPeriod = true;
                            else newBulkPeriod = false;

                        }
                        else
                        {
                            newApp = true;
                            newTime = true;
                            newBulkPeriod = true;
                        }

                        if (newBulkPeriod)
                        {
                            adjustedCost += runningCost;
                            runningCost = 0d;
                            bulkCnt = 0;
                        }

                        if (newTime)
                        {
                            adjustedCost += runningCost;
                            runningCost = 0d;
                            bulkCnt = 0;
                        }

                        if (newApp)
                        {
                            adjustedCost += runningCost;
                            runningCost = 0d;
                            bulkCnt = 0;


                            //Console.WriteLine("{0}: {1} {2} {3}", app, timeSlotStart.Date, actualCost, adjustedCost);

                            HighLight x = new HighLight(app);

                            if (analyseBaseData.highLight[x.appcount] != null) x = analyseBaseData.highLight[x.appcount];


                            switch (tag)
                            {
                                case "laundry":
                                    if (adjustedCost != Math.Round(adjustedCost))
                                    {
                                        adjustedCost = Math.Round(adjustedCost);
                                        rounded = true;
                                    }
                                    x.Laundry = highLightEvents.ToString() + " " + Program.iniFile.GetValueStr("price.laundry.unitsname") + " för " + actualCost.ToString() + " SEK"
                                        + (actualCost != adjustedCost ? ", justerat till " + adjustedCost.ToString() + " SEK pga att "
                                            + (highLight1 != 0 ? "maxkostnaden överstegs vid " + highLight1.ToString() + " tillfällen " : "")
                                            + (highLight1 != 0 && rounded ? ", " : "")
                                            + (rounded ? "beloppet har avrundats" : "")
                                        : "");

                                    totalCosts.TotalActualLaundry = actualCost;
                                    totalCosts.TotalAdjustedLaundry = adjustedCost;

                                    break;
                                case "relax":
                                    if (adjustedCost != Math.Round(adjustedCost))
                                    {
                                        adjustedCost = Math.Round(adjustedCost);
                                        rounded = true;
                                    }
                                    x.Relax = highLightEvents.ToString() + " " + Program.iniFile.GetValueStr("price.relax.unitsname") + " för " + actualCost.ToString() + " SEK"
                                        + (actualCost != adjustedCost ? ", justerat till " + adjustedCost.ToString() + " SEK pga att " 
                                            + (highLight1 != 0 ? "maxkostnaden överstegs vid " + highLight1.ToString() + " tillfällen" : "") 
                                            + (highLight1 != 0 && highLight2 != 0 ? ", " : "") 
                                            + (highLight2 != 0 ? "gästlägenheten bokades samtidigt vid " + highLight2.ToString() + " tillfällen" : "")
                                            + (highLight1 + highLight2 != 0 && rounded ? ", " : "")
                                            + (rounded ? "beloppet har avrundats" : "")
                                        : "");

                                    totalCosts.TotalActualRelax = actualCost;
                                    totalCosts.TotalAdjustedRelax = adjustedCost;

                                    break;
                                case "parking":
                                    if (adjustedCost != Math.Round(adjustedCost))
                                    {
                                        adjustedCost = Math.Round(adjustedCost);
                                        rounded = true;
                                    }
                                    x.Parking = highLightEvents.ToString() + " " + Program.iniFile.GetValueStr("price.parking.unitsname") + " för " + actualCost.ToString() + " SEK"
                                        + (actualCost != adjustedCost ? ", justerat till " + adjustedCost.ToString() + " SEK pga att " 
                                            + (highLight1 != 0 ? "maxkostnaden överstegs vid " + highLight1.ToString() + " tillfällen" : "")
                                            + (highLight1 != 0 && rounded ? ", " : "")
                                            + (rounded ? "beloppet har avrundats" : "")
                                        : "");

                                    totalCosts.TotalActualParking = actualCost;
                                    totalCosts.TotalAdjustedParking = adjustedCost;

                                    break;
                                case "apartment":
                                    rounded = false;
                                    if (adjustedCost != Math.Round(adjustedCost))
                                    {
                                        adjustedCost = Math.Round(adjustedCost);
                                        rounded = true;
                                    }
                                    x.Appartment = highLightEvents.ToString() + " " + Program.iniFile.GetValueStr("price.apartment.unitsname") + " för " + actualCost.ToString() + " SEK"
                                        + (actualCost != adjustedCost ? ", justerat till " + adjustedCost.ToString() + " SEK pga att " 
                                            + (highLight1 != 0 ? "maxkostnaden överstegs vid " + highLight1.ToString() + " tillfällen" : "")
                                            + (highLight1 != 0 && rounded ? ", " : "")
                                            + (rounded ? "beloppet har avrundats" : "")
                                        : "");

                                    totalCosts.TotalActualApartment = actualCost;
                                    totalCosts.TotalAdjustedApartment = adjustedCost;

                                    break;
                                case "charging":
                                    rounded = false;
                                    if (adjustedCost != Math.Round(adjustedCost))
                                    {
                                        adjustedCost = Math.Round(adjustedCost);
                                        rounded = true;
                                    } 
                                    x.Charging = highLightEvents.ToString() + " " + Program.iniFile.GetValueStr("price.charging.unitsname") + " för " + actualCost.ToString() + " SEK"
                                        + (actualCost != adjustedCost ? ", justerat till " + adjustedCost.ToString() + " SEK pga att " 
                                            + (highLight1 != 0 ? "maxkostnaden överstegs vid " + highLight1.ToString() + " tillfällen" : "")
                                            + (highLight1 != 0 && rounded ? ", " :"")
                                            + (rounded ? "beloppet har avrundats" : "")
                                        : "");

                                    totalCosts.TotalActualCharging = actualCost;
                                    totalCosts.TotalAdjustedCharging = adjustedCost;

                                    break;
                            }

                            analyseBaseData.highLight[x.appcount] = x;
                            dtCalculated.Rows.Add(new Object[] { app, actualCost, adjustedCost });

                            highLightEvents = 0d;
                            highLight1 = 0d;
                            highLight2 = 0d;

                            actualCost = 0d;
                            adjustedCost = 0d;
                        }
                    }
                }

                foreach (DataRow rowDt in dtCalculated.Rows)
                {
                    foreach (DataRow rowReport in Program.report.Rows)
                    {
                        if (rowDt[0].Equals(rowReport[0]))
                        {
                            rowReport[reportColumnCost] = rowDt[1];
                            rowReport[reportColumnAdjustedCost] = rowDt[2];

                            rowReport[11] = double.Parse(rowReport[11].ToString().NVL("0").Replace(".", ",")) + double.Parse(rowDt[1].ToString().Replace(".", ","));
                            rowReport[12] = double.Parse(rowReport[12].ToString().NVL("0").Replace(".", ",")) + double.Parse(rowDt[2].ToString().Replace(".", ","));

                            rowReport.EndEdit();
                            rowReport.AcceptChanges();
                            break;
                        }
                    }
                }

            }

            analyseBaseData.dataGridViewAnalyseBaseData.SuspendLayout();
            analyseBaseData.dataGridViewAnalyseBaseData.Columns.Clear();
            analyseBaseData.dataGridViewAnalyseBaseData.DataSource = Program.report;

            analyseBaseData.dataGridViewAnalyseBaseData.ColumnHeadersHeight = analyseBaseData.dataGridViewAnalyseBaseData.Rows[0].Height * 2;
            analyseBaseData.dataGridViewAnalyseBaseData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            analyseBaseData.dataGridViewAnalyseBaseData.ClearSelection();
            analyseBaseData.richTextBox1.Rtf = null;
            analyseBaseData.dataGridViewAnalyseBaseData.ResumeLayout();

            analyseBaseData.dataGridViewAnalyseTotal.SuspendLayout();
            analyseBaseData.dataGridViewAnalyseTotal.Columns.Clear();
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Tvättstuga", totalCosts.TotalActualLaundry, totalCosts.TotalAdjustedLaundry });
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Relax", totalCosts.TotalActualRelax, totalCosts.TotalAdjustedRelax });
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Gästlägenhet", totalCosts.TotalActualApartment, totalCosts.TotalAdjustedApartment });
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Gästparkering", totalCosts.TotalActualParking, totalCosts.TotalAdjustedParking });
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Laddning", totalCosts.TotalActualCharging, totalCosts.TotalAdjustedCharging });
            analyseBaseData.reportTotal.Rows.Add(new Object[] { "Totalt", totalCosts.TotalActual, totalCosts.TotalAdjusted });
            analyseBaseData.dataGridViewAnalyseTotal.DataSource = analyseBaseData.reportTotal;
            analyseBaseData.dataGridViewAnalyseTotal.ColumnHeadersHeight = analyseBaseData.dataGridViewAnalyseBaseData.ColumnHeadersHeight;
            analyseBaseData.dataGridViewAnalyseTotal.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            analyseBaseData.dataGridViewAnalyseTotal.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            analyseBaseData.dataGridViewAnalyseTotal.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            analyseBaseData.dataGridViewAnalyseTotal.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            analyseBaseData.dataGridViewAnalyseTotal.ResumeLayout();

            analyseBaseData.dataGridViewAnalyseTotal.Rows[analyseBaseData.dataGridViewAnalyseTotal.Rows.Count - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            
            w = 0;
            for (int i = 0; i < analyseBaseData.dataGridViewAnalyseTotal.ColumnCount; i++)
            {
                w += analyseBaseData.dataGridViewAnalyseTotal.Columns[i].Width + 1;
            }
            h = analyseBaseData.dataGridViewAnalyseTotal.ColumnHeadersHeight;
            for (int i = 0; i < analyseBaseData.dataGridViewAnalyseTotal.RowCount; i++)
            {
                h += analyseBaseData.dataGridViewAnalyseTotal.Rows[i].Height;
            }
            h += 2;
            analyseBaseData.dataGridViewAnalyseTotal.Size = new Size(w, h);
        }

        public void ShowCurrentPrices()
        {
            priceLists.ShowCurrentPrices();
        }

        public string CreatePDFReport(string file, DataTable dtCalculated, DataTable dtAdditional)
        {
            PDF pdf = new PDF(Program.pageSettings);
            DataTable data = new DataTable();
            DataTable tmpData = new DataTable();
            Double appTotal;

            data.Columns.Add(new DataColumn("rowtype", typeof(int)));
            data.Columns.Add(new DataColumn("app", typeof(string)));
            data.Columns.Add(new DataColumn("object", typeof(string)));
            data.Columns.Add(new DataColumn("account", typeof(string)));
            data.Columns.Add(new DataColumn("cost", typeof(double)));

            tmpData.Columns.Add(new DataColumn("rowtype", typeof(int)));
            tmpData.Columns.Add(new DataColumn("object", typeof(string)));
            tmpData.Columns.Add(new DataColumn("account", typeof(string)));
            tmpData.Columns.Add(new DataColumn("cost", typeof(double)));

            pdf.WriteLine(pdf.y, 0, Program.currentReportPeriod.ReportPeriod.FilePrefix, XStringFormats.BaseLineCenter);

            //Coalesce all debits
            foreach (DataRow rowDt in dtCalculated.Rows)
            {
                appTotal = 0d;

                if ((Double)rowDt[2].NVL(0d) != 0d)
                {
                    appTotal += (Double)rowDt[2].NVL(0d);
                    tmpData.Rows.Add(new Object[] { 10, "Tvättstuga", "3211", (Double)rowDt[2].NVL(0d) });
                }
                if ((Double)rowDt[4].NVL(0d) != 0d)
                {
                    appTotal += (Double)rowDt[4].NVL(0d);
                    tmpData.Rows.Add(new Object[] { 20, "Relax", "3212", (Double)rowDt[4].NVL(0d) });
                }
                if ((Double)rowDt[6].NVL(0d) != 0d)
                {
                    appTotal += (Double)rowDt[6].NVL(0d);
                    tmpData.Rows.Add(new Object[] { 30, "Gästlägenhet", "3250", (Double)rowDt[6].NVL(0d) });
                }
                if ((Double)rowDt[8].NVL(0d) != 0d)
                {
                    appTotal += (Double)rowDt[8].NVL(0d);
                    tmpData.Rows.Add(new Object[] { 40, "Gästparkering", "3049", (Double)rowDt[8].NVL(0d) });
                }
                if ((Double)rowDt[10].NVL(0d) != 0d)
                {
                    appTotal += (Double)rowDt[10].NVL(0d);
                    tmpData.Rows.Add(new Object[] { 50, "Elbilsladdning", "3124 (Momspliktigt)", (Double)rowDt[10].NVL(0d) });
                }
                /* Check for extra costs for this appartment */
                foreach (DataRow rowDtExtra in dtAdditional.Rows)
                {
                    if (rowDtExtra[0].ToString().Equals(rowDt[0]))
                    {
                        appTotal += (Double)rowDtExtra[3].NVL(0d);
                        tmpData.Rows.Add(new Object[] { 100, rowDtExtra[1], rowDtExtra[2], (Double)rowDtExtra[3].NVL(0d) });
                    }
                }
                /* If this apartment has any costs, add a total and move everything to the real table */
                if (appTotal != 0d)
                {
                    data.Rows.Add(new Object[] { 1000, rowDt[0], "Totalt", "", appTotal });
                    foreach (DataRow rowTemp in tmpData.Rows)
                    {
                        data.Rows.Add(new Object[] { rowTemp[0], rowDt[0], rowTemp[1], rowTemp[2], rowTemp[3] });
                    }
                    tmpData.Rows.Clear();
                }
            }


            if (data.Rows.Count > 0) 
            {
                /* Sum up the table to a total */
                DataTable dtTotal = data.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["object"], Col2 = r["account"], Col3 = r["rowtype"] })
                    .Select(g =>
                    {
                        var row = data.NewRow();

                        row["object"] = g.Key.Col1;
                        row["account"] = g.Key.Col2;
                        row["rowtype"] = g.Key.Col3;
                        row["cost"] = g.Sum(r => r.Field<double>("cost"));

                        return row;
                    })
                    .OrderBy(r => r["rowtype"])
                        .ThenBy(r => r["object"])
                    .CopyToDataTable();


                pdf.y += 30;
                pdf.WriteLine(pdf.y, 1, "Startdatum: " + Program.currentReportPeriod.ReportPeriod.Start.ToString("yyyy-MM-dd"));
                pdf.WriteLine(pdf.y, 1, "Slutdatum: " + Program.currentReportPeriod.ReportPeriod.Stop.ToString("yyyy-MM-dd"));

                pdf.y += 30;
                pdf.WriteLine(pdf.y, 2, "Elpris att använda för denna period: " +
                    string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", Program.GetPrice("charging", Program.currentReportPeriod.ReportPeriod.Stop).PriceDbl));
                pdf.y += 4;
                pdf.WriteLine(pdf.y, 1, "Observera att det är detta pris som skall användas till all el-debitering denna period.");
                pdf.WriteLine(pdf.y, 1, "Från Infometric-rapporten skall endast förbrukningen användas, ej det där angivna el-priset.");

                pdf.y += 30;
                pdf.WriteLine(pdf.y, 2, "Sammanfattning denna period");
                pdf.y += 4;
                pdf.DrawRectangle(0, pdf.y, (int)(pdf.page.Width - pdf.pageSettings.margin.Horizontal), 1);
                pdf.y += 2;
                foreach (DataRow rowDt in dtTotal.Rows)
                {
                    if (rowDt.Field<int>(0) == 1000)
                        pdf.WriteTwoColumn(pdf.y,
                        2, rowDt[2].ToString() + " " + rowDt[3].ToString(), 5,
                        2, string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00}", (Double)rowDt[4].NVL(0d)) + " SEK", 0, true);
                    else
                        pdf.WriteTwoColumn(pdf.y,
                            1, rowDt[2].ToString() + (rowDt[3].ToString().Equals("") ? "" : " (konto " + rowDt[3].ToString() + ")"), 5,
                            1, string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00}", (Double)rowDt[4].NVL(0d)), 0, true);
                }


                pdf.y += 30;
                pdf.WriteLine(pdf.y, 2, "Per lägenhet");
                pdf.y += 4;
                pdf.DrawRectangle(0, pdf.y, (int)(pdf.page.Width - pdf.pageSettings.margin.Horizontal), 1);
                pdf.y -= 12;
                foreach (DataRow rowDt in data.Rows)
                {
                    if ((int)rowDt[0] == 1000)
                    {
                        pdf.WriteTwoColumn(pdf.y + 20,
                                        2, "Lägenhet " + rowDt[1].ToString(),
                                        2, string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00}", (Double)rowDt[4].NVL(0d)) + " SEK", true);
                        pdf.y += 2;
                    }
                    else
                    {
                        pdf.WriteTwoColumn(pdf.y,
                                       1, rowDt[2].ToString() + (rowDt[3].ToString().Equals("") ? "" : " (konto " + rowDt[3].ToString() + ")"),
                                       1, string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00}", (Double)rowDt[4].NVL(0d)), false);

                    }

                    if (pdf.y + 16 >= (pdf.page.Height - pdf.pageSettings.margin.Vertical))
                    {
                        pdf.AddPage();
                        pdf.y = 0;
                        //y = 0;
                    }

                }

                // Save the document...
                pdf.document.Save(file);
                return file;
            }
            else 
                Dialog.ShowMessage("Ingen data", "Det finns inget data för denna period att basera debiteringsunderlaget på", Dialog.Buttons.Ok,this);

            return null;
        }

        private void ButtonInstallLatestVersion_Click(object sender, EventArgs e)
        {
            Program.iniFile.SetValueBool("Show.installbutton." + Environment.MachineName.ToLower(), false);

            System.Diagnostics.Process.Start(Program.programPath + "\\publish\\setup.exe");
            this.Dispose();
        }

        private void PanelCurrentAction_Resize_1(object sender, EventArgs e)
        {
            loadBaseData.Size = panelCurrentAction.Size;
            additionalData.Size = panelCurrentAction.Size;
            analyseBaseData.Size = panelCurrentAction.Size;
            priceLists.Size = panelCurrentAction.Size;
            setReportPeriod.Size = panelCurrentAction.Size;
        }

       
    }

    internal class TotalCosts
    {
        private double totalActualLaundry;
        public double TotalActualLaundry
        {
            get { return totalActualLaundry; }
            set { totalActualLaundry += value; }
        }
        private double totalActualApartment;
        public double TotalActualApartment
        {
            get { return totalActualApartment; }
            set { totalActualApartment += value; }
        }
        private double totalActualParking;
        public double TotalActualParking
        {
            get { return totalActualParking; }
            set { totalActualParking += value; }
        }
        private double totalActualRelax;
        public double TotalActualRelax
        {
            get { return totalActualRelax; }
            set { totalActualRelax += value; }
        }
        private double totalActualCharging;
        public double TotalActualCharging
        {
            get { return totalActualCharging; }
            set { totalActualCharging += value; }
        }


        private double totalAdjustedLaundry;
        public double TotalAdjustedLaundry
        {
            get { return totalAdjustedLaundry; }
            set { totalAdjustedLaundry += value; }
        }
        private double totalAdjustedApartment;
        public double TotalAdjustedApartment
        {
            get { return totalAdjustedApartment; }
            set { totalAdjustedApartment += value; }
        }
        private double totalAdjustedParking;
        public double TotalAdjustedParking
        {
            get { return totalAdjustedParking; }
            set { totalAdjustedParking += value; }
        }
        private double totalAdjustedRelax;
        public double TotalAdjustedRelax
        {
            get { return totalAdjustedRelax; }
            set { totalAdjustedRelax += value; }
        }
        private double totalAdjustedCharging;
        public double TotalAdjustedCharging
        {
            get { return totalAdjustedCharging; }
            set { totalAdjustedCharging += value; }
        }

        public double TotalAdjusted
        {
            get { return totalAdjustedLaundry + totalAdjustedApartment + totalAdjustedParking + totalAdjustedRelax + totalAdjustedCharging; }
            set { }
        }
        public double TotalActual
        {
            get { return totalActualLaundry + totalActualApartment + totalActualParking + totalActualRelax + totalActualCharging; }
            set { }
        }

        public TotalCosts()
        {
            totalActualLaundry = 0d;
            totalActualApartment = 0d;
            totalActualParking = 0d;
            totalActualRelax = 0d;
            totalActualCharging = 0d;
            totalAdjustedLaundry = 0d;
            totalAdjustedApartment = 0d;
            totalAdjustedParking = 0d;
            totalAdjustedRelax = 0d;
            totalAdjustedCharging = 0d;
        }

    }

    internal class TimeSlot
    {
        public DateTime timeSlotStart;
        public DateTime timeSlotEnd;
        public String app;

        public TimeSlot(String app, DateTime timeSlotStart, DateTime timeSlotEnd)
        {
            this.app = app;
            this.timeSlotStart = timeSlotStart;
            this.timeSlotEnd = timeSlotEnd;
        }
    }

}
