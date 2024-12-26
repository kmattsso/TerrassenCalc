using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace TerrassenCalc
{
    public partial class AdditionalData : UserControl, IObserver<Program.ReportPeriod>
    {
        //private readonly IDisposable unsubscriber;
        public Form myParent;
        private String dbPath;
        private String dbFile;

        public AdditionalData(Form parent)
        {
            myParent = parent;
            InitializeComponent();
            _ = Program.currentReportPeriod.Subscribe(this);
        }


        void IObserver<Program.ReportPeriod>.OnNext(Program.ReportPeriod value)
        {
            dbPath = Program.programPath + "\\" + Program.iniFile.GetValueStr("database.folder") + "\\" + Program.currentReportPeriod.ReportPeriod.DisplayName;
            dbFile = dbPath + "\\extra.csv";
            labelReportPeriod.Text = "Vald rapportperiod: " + Program.currentReportPeriod.ReportPeriod.DisplayName;
            LoadFileAdditonal();
        }

        private void LoadFileAdditonal()
        {
            int n;

            Program.dtAdditional = new DataTable();
            Program.dtAdditional.Columns.Add("Lägenhet", typeof(string));
            Program.dtAdditional.Columns.Add("Text", typeof(string));
            Program.dtAdditional.Columns.Add("Konto", typeof(string));
            Program.dtAdditional.Columns.Add("Belopp", typeof(double));

            if (File.Exists(dbFile))
            {
                string[] lines = System.IO.File.ReadAllLines(dbFile);

                n = 0;
                foreach (string line in lines)
                {
                    n++;
                    if (n > Program.iniFile.GetValueInt("bookings.additional.dataload.headers"))
                    {
                        String fileLine = line + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;";
                        var cols = fileLine.Split(';');

                        DataRow dr = Program.dtAdditional.NewRow();
                        dr[0] = cols[0];
                        dr[1] = cols[1];
                        dr[2] = cols[2];
                        dr[3] = Double.Parse(cols[3],NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.GetCultureInfo("se-SV"));

                        Program.dtAdditional.Rows.Add(dr);
                    }
                }

                Program.dtAdditional.DefaultView.Sort = "Lägenhet ASC, Text ASC";

                System.IO.File.Delete(dbFile);
                foreach (DataRow dr in Program.dtAdditional.DefaultView.ToTable().Rows)
                {
                    System.IO.File.AppendAllText(dbFile, dr[0] + ";" + dr[1] + ";" + dr[2] + ";" + dr[3] + "\n");
                }
            }
            

            dataGridViewAdditional.SuspendLayout();

            dataGridViewAdditional.Columns.Clear();
            dataGridViewAdditional.Refresh();

            dataGridViewAdditional.DataSource = Program.dtAdditional;

            var deleteButton = new System.Windows.Forms.DataGridViewButtonColumn
            {
                HeaderText = "Radera",
                UseColumnTextForButtonValue = true,
                Text = "Radera"
            };
            var editButton = new DataGridViewButtonColumn
            {
                HeaderText = "Ändra",
                UseColumnTextForButtonValue = true,
                Text = "Ändra"
            };
            this.dataGridViewAdditional.Columns.Add(editButton);
            this.dataGridViewAdditional.Columns.Add(deleteButton);

            dataGridViewAdditional.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAdditional.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAdditional.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewAdditional.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewAdditional.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewAdditional.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewAdditional.ResumeLayout();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EditAdditionCost(-1);
        }

        private void EditAdditionCost(int row)
        {
            Panel p = new Panel();
            int col = 0;
            int left = 12;
            int lineHeight = 12;
            string caption;

            p.AutoSize = true;

            Label labelAppartment = new Label() { Text = "Lägenhet:" };
            labelAppartment.Top = lineHeight;
            labelAppartment.Left = left;
            labelAppartment.AutoSize = true;
            labelAppartment.TextAlign = ContentAlignment.MiddleLeft;
            col = (col < labelAppartment.PreferredWidth ? labelAppartment.PreferredWidth : col);

            ComboBox comboBox = new ComboBox();
            ComboBox comboBoxAppartment = comboBox;
            comboBoxAppartment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAppartment.Items.AddRange(new object[] { "101", "102", "103", "104", "105", "106", "107", "108",
                                                             "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213",
                                                             "301", "302" });
            comboBoxAppartment.SelectedIndex = 0;
            comboBoxAppartment.Top = labelAppartment.Top + labelAppartment.PreferredHeight / 2 - comboBoxAppartment.PreferredHeight / 2;
            comboBoxAppartment.Width = 50;

            Label labelText = new Label() { Text = "Text:" };
            labelText.Top = labelAppartment.Top + labelAppartment.Height + lineHeight;
            labelText.Left = left;
            labelText.AutoSize = true;
            labelText.TextAlign = ContentAlignment.MiddleLeft;
            col = (col < labelText.PreferredWidth ? labelText.PreferredWidth : col);

            TextBox textBoxText = new TextBox();
            textBoxText.Top = labelText.Top + labelText.PreferredHeight / 2 - textBoxText.PreferredHeight / 2;
            textBoxText.Width = 250;

            Label labelAccount = new Label() { Text = "Konto:" };
            labelAccount.Top = labelText.Top + labelText.Height + lineHeight;
            labelAccount.Left = left;
            labelAccount.AutoSize = true;
            labelAccount.TextAlign = ContentAlignment.MiddleLeft;
            col = (col < labelAccount.PreferredWidth ? labelAccount.PreferredWidth : col);

            TextBox textBoxAccount = new TextBox();
            textBoxAccount.Top = labelAccount.Top + labelAccount.PreferredHeight / 2 - textBoxAccount.PreferredHeight / 2;
            textBoxAccount.Width = 100;

            Label labelAmount = new Label() { Text = "Belopp:" };
            labelAmount.Top = labelAccount.Top + labelAccount.Height + lineHeight;
            labelAmount.Left = left;
            labelAmount.AutoSize = true;
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;
            col = (col < labelAmount.PreferredWidth ? labelAmount.PreferredWidth : col);

            TextBox textBoxAmount = new TextBox();
            textBoxAmount.Top = labelAmount.Top + labelAmount.PreferredHeight / 2 - textBoxAmount.PreferredHeight / 2;
            textBoxAmount.Width = 100;

            col += 2;
            comboBoxAppartment.Left = left + col;
            textBoxText.Left = left + col;
            textBoxAccount.Left = left + col;
            textBoxAmount.Left = left + col;

            p.Controls.Add(labelAppartment);
            p.Controls.Add(comboBoxAppartment);
            p.Controls.Add(labelText);
            p.Controls.Add(textBoxText);
            p.Controls.Add(labelAccount);
            p.Controls.Add(textBoxAccount);
            p.Controls.Add(labelAmount);
            p.Controls.Add(textBoxAmount);

            caption = "Lägg till en debitering";
            if (row > -1)
            {
                caption = "Ändra debitering";
                comboBoxAppartment.SelectedItem = dataGridViewAdditional.Rows[row].Cells["Lägenhet"].Value;
                textBoxText.Text = dataGridViewAdditional.Rows[row].Cells["Text"].Value.ToString();
                textBoxAccount.Text = dataGridViewAdditional.Rows[row].Cells["Konto"].Value.ToString();
                textBoxAmount.Text = dataGridViewAdditional.Rows[row].Cells["Belopp"].Value.ToString();
            }

            while (Dialog.Show(caption, p, Dialog.Buttons.Ok | Dialog.Buttons.Cancel, myParent) != Dialog.Buttons.Cancel)
            {
                if (textBoxText.Text.Trim().Length > 0 &&
                    Double.TryParse(textBoxAmount.Text.Trim(), NumberStyles.Number | NumberStyles.AllowDecimalPoint,
                            System.Globalization.CultureInfo.GetCultureInfo("se-SV"),
                            out double amt)
                    && amt > 0d)
                {
                    List<string> dr = new List<string>
                    {
                        comboBoxAppartment.SelectedItem.ToString() + ";" +
                        textBoxText.Text + ";" +
                        textBoxAccount.Text + ";" +
                        string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:###0.00}", amt)
                    };
                    if (row > -1) RemoveRecord(row);
                    if (!File.Exists(dbFile))
                    {
                        Directory.CreateDirectory(dbPath);
                        var x = File.CreateText(dbFile);
                        x.Close();
                    }
                    File.AppendAllLines(dbFile, dr, Encoding.UTF8);
                    LoadFileAdditonal();
                    break;
                }
            }
        }

        private void RemoveRecord(int record)
        {
            System.IO.File.Copy(dbFile, dbFile + ".temp");
            System.IO.File.Delete(dbFile);
            int line = 0;
            foreach (var x in System.IO.File.ReadAllLines(dbFile + ".temp"))
            {
                if (line != record) System.IO.File.AppendAllText(dbFile, x + "\n");
                line++;
            }
            System.IO.File.Delete(dbFile + ".temp");
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridViewAdditional.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Ändra"))
            {
                EditAdditionCost(e.RowIndex);
                //MessageBox.Show("Ändra " + e.RowIndex.ToString());
            }
            else if (e.RowIndex > -1 && dataGridViewAdditional.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("Radera"))
            {
                RemoveRecord(e.RowIndex);
            }
            
            LoadFileAdditonal();
        }

        public void OnError(Exception error) { throw new NotImplementedException(); }
        public void OnCompleted() { throw new NotImplementedException(); }
    }
}
