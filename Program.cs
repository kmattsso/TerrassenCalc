using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using PdfSharp.Drawing;

namespace TerrassenCalc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        public static IniFile iniFile;
        public static LogFile logFile;
        public static string programPath;

        public static DataTable dtCharging;
        public static DataTable dtRelax;
        public static DataTable dtParking;
        public static DataTable dtApartment;
        public static DataTable dtLaundry;
        public static DataTable dtAdditional;

        public static DataTable report;

        public static CurrentReportPeriod currentReportPeriod = new CurrentReportPeriod();

        public const string keyName = "HKEY_CURRENT_USER\\Software\\Whetstone\\TerrassenCalc";
        public static PDFPageSettings pageSettings;



        [STAThread]
        static void Main()
        {


            try
            {
                string myIniFile = "TerrassenCalc.parameter"; ;
                string myLogFile = "TerrassenCalc.log"; ;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (Microsoft.Win32.Registry.GetValue(keyName, "Program Folder", "X") == null)
                {
                    Microsoft.Win32.Registry.SetValue(keyName, "", "");
                };


                programPath = Microsoft.Win32.Registry.GetValue(keyName, "Program Folder", "").ToString();

                while (!File.Exists(programPath + "\\" + myIniFile))
                {
                    /*   using (FolderBrowserDialog d = new FolderBrowserDialog() { SelectedPath = programPath, Description = "Filen " + iniFile + " kan inte hittas\nAnge var filen finns:" })
                       {
                           if (d.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                               throw new FileNotFoundException("Filen " + iniFile + " kan inte hittas");
                           programPath = d.SelectedPath;
                       }
                       */
                    Panel p = new Panel();
                    int left = 12;
                    int lineHeight = 12;

                    p.AutoSize = true;

                    Label labelText = new Label() { Text = "Ange Windows-sökvägen till var filen " + myIniFile + " finns:" };
                    labelText.Top = lineHeight;
                    labelText.Left = left;
                    labelText.AutoSize = true;
                    labelText.TextAlign = ContentAlignment.MiddleLeft;
                    
                    TextBox textBoxText = new TextBox();
                    textBoxText.Top = labelText.Top + labelText.PreferredHeight + 4;
                    textBoxText.Left = left;
                    textBoxText.Width = 800;
                    p.Controls.Add(labelText);
                    p.Controls.Add(textBoxText);

                    
                    if (Dialog.Show("Hittar inte parameter-filen", p, Dialog.Buttons.Ok | Dialog.Buttons.Cancel, null) == Dialog.Buttons.Cancel)
                        throw new FileNotFoundException("Filen " + myIniFile + " kan inte hittas");
                    programPath = textBoxText.Text;
                }

                Microsoft.Win32.Registry.SetValue(keyName, "Program Folder", programPath);

                iniFile = new IniFile(programPath + "\\" + myIniFile, new System.Text.UTF8Encoding(false));
                logFile = new LogFile(programPath + "\\" + myLogFile, new System.Text.UTF8Encoding(false));

                // Set PDF
                pageSettings = new PDFPageSettings();
                pageSettings.SetPageSize("A4");
                pageSettings.AddFont(  //0
                    "Verdana", 12, "Bold");
                pageSettings.AddFont(  //1
                    "Verdana", 10, "Regular");
                pageSettings.AddFont(  //2
                    "Verdana", 10, "Bold");
                pageSettings.AddFont(  //3
                    "Verdana", 10, "Underline");
                pageSettings.SetMargin(60, 35, 40, 25); // L T R B


                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                if (logFile != null)
                {
                    logFile.Log(e.Message);
                    logFile.Trace(e);
                }
                _ = MessageBox.Show(e.Message, "Error");

                try
                {
                    //CleanUp();
                }
                catch { }

                Application.Exit();
            }
        }


        public class ReportPeriod
        {
            public DateTime Start { get; set; }
            public DateTime Stop { get; set; }
            public string DisplayName { get; set; }
            public string FilePrefix { get; set; }
            public DateTime Next { get; set; }

            public ReportPeriod(DateTime startDate)
            {
                Start = startDate;
                Next = this.Start.AddMonths(Program.iniFile.GetValueInt("bookings.reports.periodlength"));
                Stop = Next.AddDays(-1);
                DisplayName = (Start.ToString("yyyy-PMM MMM", new CultureInfo("sv-SE")) + "-" + Stop.ToString("MMM", new CultureInfo("sv-SE"))).InitCapAll();
                DisplayName = DisplayName.Replace("P01", "1");
                DisplayName = DisplayName.Replace("P02", "1");
                DisplayName = DisplayName.Replace("P03", "1");
                DisplayName = DisplayName.Replace("P04", "2");
                DisplayName = DisplayName.Replace("P05", "2");
                DisplayName = DisplayName.Replace("P06", "2");
                DisplayName = DisplayName.Replace("P07", "3");
                DisplayName = DisplayName.Replace("P08", "3");
                DisplayName = DisplayName.Replace("P09", "3");
                DisplayName = DisplayName.Replace("P10", "4");
                DisplayName = DisplayName.Replace("P11", "4");
                DisplayName = DisplayName.Replace("P12", "4");
                FilePrefix = "Gröndalsterrassen debiteringsunderlag " + DisplayName;
            }

            override
            public string ToString()
            {
                return DisplayName;
            }

        }
        internal class CurrentReportPeriod : IObservable<ReportPeriod>
        {
            private ReportPeriod reportPeriod;

            public ReportPeriod ReportPeriod {
                get { return reportPeriod;  }
                set { reportPeriod = value;
                    foreach (var observer in observers)
                        observer.OnNext(reportPeriod);
                }
            }

            readonly List<IObserver<ReportPeriod>> observers;

            public CurrentReportPeriod()
            {
                observers = new List<IObserver<ReportPeriod>>();
            }

            public IDisposable Subscribe(IObserver<ReportPeriod> observer)
            {
                observers.Add(observer);
                return new Unsubscriber(observers, observer);
            }

            private class Unsubscriber : IDisposable
            {
                private readonly List<IObserver<ReportPeriod>> _observers;
                private readonly IObserver<ReportPeriod> _observer;

                public Unsubscriber(List<IObserver<ReportPeriod>> observers, IObserver<ReportPeriod> observer)
                {
                    this._observers = observers;
                    this._observer = observer;
                }

                public void Dispose()
                {
                    if (!(_observer == null)) _observers.Remove(_observer);
                }
            }
            
        }


        internal class PriceListEntry
        {
            public string Price;
            public double PriceDbl;
            public bool UseBulkPrice;
            public string BulkPrice;
            public double BulkPriceDbl;
            public string BulkResetPeriod;
            public int BulkResetPeriodInt;
            public string Dt { get; set; }
            public DateTime DtDt { get; set; }
            public string Tag { get; set; }
            public string unitname;
            public string unitsname;

            public PriceListEntry(string tag, DateTime dt)
            {
                this.DtDt = (DateTime)dt.NVL(new DateTime(1901, 01, 01));
                this.Dt = this.DtDt.ToString("yyyyMMdd");
                this.Tag = tag;
                Constructor(this.Tag, this.Dt);
            }
            public PriceListEntry(string tag, string dt)
            {
                this.Dt = dt.NVL("19010101");
                this.DtDt = DateTime.ParseExact(this.Dt, "yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("se-SV"));
                this.Tag = tag;
                Constructor(this.Tag, this.Dt);
            }

            internal void Constructor(string tag, string dt) 
            {

                PriceDbl = (double)Program.iniFile.GetValueDbl("pricelist." + tag + "." + dt + ".price").NVL(0d);
                Price = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", PriceDbl);

                UseBulkPrice = (bool)Program.iniFile.GetValueBool("pricelist." + tag + "." + dt + ".usebulkprice");

                if (UseBulkPrice)
                {
                    BulkPriceDbl = (double)Program.iniFile.GetValueDbl("pricelist." + tag + "." + dt + ".bulkprice").NVL(0d);
                    BulkPrice = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", BulkPriceDbl);
                    BulkResetPeriodInt = Program.iniFile.GetValueInt("pricelist." + tag + "." + dt + ".bulkpriceresetperiod");
                    BulkResetPeriod = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#0}", BulkResetPeriodInt);
                }
                else
                {
                    BulkPrice = Price;
                    BulkPriceDbl = 999999999d;
                    BulkResetPeriodInt = 999999999;
                    BulkResetPeriod = "999999999";
                }

                unitsname = Program.iniFile.GetValueStr("price." + tag + ".unitsname");
                unitname = Program.iniFile.GetValueStr("price." + tag + ".unitname");
                
            }

            override
            public string ToString()
            {
                string retval;
                retval = "Från och med " + Dt + " är priset " + Price + " per " + unitname;
                if (UseBulkPrice)
                {
                    retval = retval + ", max " + BulkPrice + " per " + BulkResetPeriod + " " + unitsname;
                }
                return retval;
            }
        }

        

        internal static IEnumerable<DateTime> EachDay(DateTime start, DateTime stop)
        {
            for (var day = start.Date; day.Date <= stop.Date; day = day.AddDays(1))
                yield return day;
        }

        public static void Backup()
        {
            
        }

        public static PriceListEntry GetPrice(String tag, DateTime date)
        {
            Program.PriceListEntry retVal = new Program.PriceListEntry(tag, null); ;
            String PriceListDates = Program.iniFile.GetValueStr("pricelist." + tag + ".dates");
            SortedSet<String> dateList = new SortedSet<String>(PriceListDates.Split(';'));


            foreach (String dtStr in dateList)
            {
                if (dtStr == "") continue;
                DateTime dt = DateTime.ParseExact(dtStr, "yyyyMMdd", CultureInfo.CurrentCulture);
                if (dt.Date <= date.Date)
                {
                    retVal = new Program.PriceListEntry(tag, dt);
                }
                else if (dt.Date > date.Date) break;
            }

            return retVal;
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

    }
}
