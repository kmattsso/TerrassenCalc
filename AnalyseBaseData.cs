using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Helper;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Drawing;

namespace TerrassenCalc
{
    public partial class AnalyseBaseData : UserControl

    {
        public DataTable reportTotal;
        public HighLight[] highLight = new HighLight[23];

        public AnalyseBaseData()
        {
            InitializeComponent();
        }


        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            String tmpPath = Path.GetTempPath();
            if (File.Exists(tmpPath + "\\rapportunderlag.csv"))
            {
                File.SetAttributes(tmpPath + "\\rapportunderlag.csv", FileAttributes.Normal);
                File.Delete(tmpPath + "\\rapportunderlag.csv");
            }


            if (dataGridViewAnalyseBaseData.Rows.Count > 0)
            {
                try
                {
                    int columnCount = dataGridViewAnalyseBaseData.Columns.Count;
                    string columnNames = "";
                    string[] outputCsv = new string[dataGridViewAnalyseBaseData.Rows.Count + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dataGridViewAnalyseBaseData.Columns[i].HeaderText.ToString().Replace("\n"," ") + ";";
                    }
                    outputCsv[0] += columnNames;

                    for (int i = 1; (i - 1) < dataGridViewAnalyseBaseData.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCsv[i] += dataGridViewAnalyseBaseData.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(tmpPath + "\\rapportunderlag.csv", outputCsv, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }

            File.SetAttributes(tmpPath + "\\rapportunderlag.csv", FileAttributes.Temporary);
            File.SetAttributes(tmpPath + "\\rapportunderlag.csv", FileAttributes.ReadOnly);
            System.Diagnostics.Process.Start(tmpPath + "\\rapportunderlag.csv");
        }

        private void DataGridView1_Sorted(object sender, EventArgs e)
        {
            dataGridViewAnalyseBaseData.ClearSelection();
            richTextBox1.Rtf = null;
        }

       

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAnalyseBaseData.SelectedRows.Count > 0 && dataGridViewAnalyseBaseData.SelectedRows[0].Index >= 0)
            {
                string[] apartmentList = new string[] { "101", "102", "103", "104", "105", "106", "107", "108", "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", "301", "302" };
                string app = dataGridViewAnalyseBaseData.Rows[dataGridViewAnalyseBaseData.SelectedRows[0].Index].Cells[0].Value.ToString();
                for (int i = 0; i < apartmentList.Length; i++)
                {
                    if (apartmentList[i] == app)
                    {
                        if (highLight[i] != null) richTextBox1.Rtf = highLight[i].ToString();
                        break;
                    }
                    richTextBox1.Rtf = new HighLight(app).ToString();
                }
            }
        }



        private void DataGridView2_DoubleClick(object sender, EventArgs e)
        {

            String tmpPath = Path.GetTempPath();
            if (File.Exists(tmpPath + "\\totaler.csv"))
            {
                File.SetAttributes(tmpPath + "\\totaler.csv", FileAttributes.Normal);
                File.Delete(tmpPath + "\\totaler.csv");
            }


            if (dataGridViewAnalyseTotal.Rows.Count > 0)
            {
                try
                {
                    int columnCount = dataGridViewAnalyseTotal.Columns.Count;
                    string columnNames = "";
                    string[] outputCsv = new string[dataGridViewAnalyseTotal.Rows.Count + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dataGridViewAnalyseTotal.Columns[i].HeaderText.ToString().Replace("\n", " ") + ";";
                    }
                    outputCsv[0] += columnNames;

                    for (int i = 1; (i - 1) < dataGridViewAnalyseTotal.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCsv[i] += dataGridViewAnalyseTotal.Rows[i - 1].Cells[j].Value.ToString() + ";";
                        }
                    }

                    File.WriteAllLines(tmpPath + "\\totaler.csv", outputCsv, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }

            File.SetAttributes(tmpPath + "\\totaler.csv", FileAttributes.Temporary);
            File.SetAttributes(tmpPath + "\\totaler.csv", FileAttributes.ReadOnly);
            System.Diagnostics.Process.Start(tmpPath + "\\totaler.csv");
        }

        private void DataGridView2_Resize(object sender, EventArgs e)
        {
            dataGridViewAnalyseBaseData.Top = dataGridViewAnalyseTotal.Top + dataGridViewAnalyseTotal.Height + 14;
            dataGridViewAnalyseBaseData.Height = richTextBox1.Top - dataGridViewAnalyseBaseData.Top - 14;
        }
    }

    

    
    public class HighLight
    {
        private String appartment;
        public String Appartment
        {
            get { return appartment; }
            set { appartment = value + "\n"; }
        }

        private String laundry;
        public String Laundry 
        { 
            get { return laundry; }
            set { laundry = value + "\n"; } 
        }
        
        private String relax;
        public String Relax 
        {
            get { return relax; }
            set { relax = value + "\n"; } 
        }
        
        private String parking;
        public String Parking
        {
            get { return parking; }
            set { parking = value + "\n"; }
        }

        private String charging;
        public String Charging
        {
            get { return charging; }
            set { charging = value + "\n"; }
        }

        public int appcount;
        private readonly string app;

        private readonly String[] apartmentList = new string[] { "101", "102", "103", "104", "105", "106", "107", "108", 
                                                        "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", 
                                                        "301", "302" };

        public HighLight(String app)
        { 
            this.app = "Lägenhet " + app + "\n";
            
            for (int i=0; i< apartmentList.Length; i++)
            {
                if(apartmentList[i] == app)
                {
                    appcount = i;
                    break;
                }
            }

        }

        override
        public string ToString()
        {
            return @"{\rtf1\ansi " + @"\b \ul " + app + @"\b0 \ul0 " + @"\line "
                + @"\b " + "Tvättstuga: " + @"\b0 " + Laundry.NVL("--") + @"\line "
                + @"\b " + "Gästlägenhet: " + @"\b0 " + Appartment.NVL("--") + @"\line "
                + @"\b " + "Relax: " + @"\b0 " + Relax.NVL("--") + @"\line "
                + @"\b " + "Gästparkering: " + @"\b0 " + Parking.NVL("--") + @"\line "
                + @"\b " + "Laddning: " + @"\b0 " + Charging.NVL("--") + "}";
        }


    }
}
