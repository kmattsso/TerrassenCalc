using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerrassenCalc
{
    public partial class PriceList : UserControl
    {
        public string currentTag;
        public string currentTagName;
        public Form myParent;

        public PriceList(String tag, Form parent)
        {
            myParent = parent;
            InitializeComponent();
            PreparePriceList(tag);
            LoadPriceList(tag);
        }

        private void ButtonRemovePrice_Click(object sender, EventArgs e)
        {

            if (listBoxPriceList.SelectedIndex > -1)
            {

                this.listBoxPriceList.ForeColor = SystemColors.GrayText;
                this.Enabled = false;
                this.SuspendLayout();

                string tag = ((Program.PriceListEntry)listBoxPriceList.SelectedItem).Tag;
                string dt = ((Program.PriceListEntry)listBoxPriceList.SelectedItem).Dt;
                string dates = Program.iniFile.GetValueStr("pricelist." + currentTag + ".dates") + ";";

                HashSet<String> dateList = dates.Split(';').ToHashSet();
                dateList.Remove(dt);
                Program.iniFile.SetValueStr("pricelist." + currentTag + ".dates", String.Join(";", dateList));

                Program.iniFile.DeleteValue("pricelist." + tag + "." + dt + ".price");
                Program.iniFile.DeleteValue("pricelist." + tag + "." + dt + ".usebulkprice");
                Program.iniFile.DeleteValue("pricelist." + tag + "." + dt + ".bulkprice");
                Program.iniFile.DeleteValue("pricelist." + tag + "." + dt + ".bulkpriceresetperiod");

                ((MainForm)myParent).RecalculateReport();
                LoadPriceList(tag);
                this.listBoxPriceList.ForeColor = SystemColors.WindowText;
                this.Enabled = true;
                this.ResumeLayout();

                ((MainForm)myParent).ShowCurrentPrices();

            }
        }

        public void LoadPriceList(string tag)
        {
            string dates = Program.iniFile.GetValueStr("pricelist." + tag + ".dates") + ";";
            HashSet<String> dateList = dates.Split(';').ToHashSet();

            listBoxPriceList.Items.Clear();
            foreach (string dt in dateList.OrderBy(key => key))
            {
                if (dt != "") listBoxPriceList.Items.Add(new Program.PriceListEntry(tag, dt));
            }
        }

        public void PreparePriceList(string tag)
        {
            currentTag = tag;

            switch (tag)
            {
                case "laundry":
                    currentTagName = "Tvättstuga";
                    break;
                case "relax":
                    currentTagName = "Relax";
                    break;
                case "apartment":
                    currentTagName = "Gästlägenhet";
                    break;
                case "parking":
                    currentTagName = "Gästparkering";
                    break;
                case "charging":
                    currentTagName = "Elektricitet";
                    break;

            }

            labelNewPriceHeader.Text = "Skapa nytt pris för " + currentTagName + ":";
            textBoxPrice.Text = null;
            textBoxBulkPrice.Text = null;
            textBoxMaxDebitResetPeriod.Text = null;

            labelPriceUnitName.Text = "per " + Program.iniFile.GetValueStr("price." + tag + ".unitname");
            labelPriceUnitsName.Text = Program.iniFile.GetValueStr("price." + tag + ".unitsname");

            groupBoxUseMaxDebit.Enabled = Program.iniFile.GetValueBool("price." + tag + ".allowmaxdebit");
            checkBoxUseMaxDebit.Enabled = Program.iniFile.GetValueBool("price." + tag + ".allowmaxdebit");

            checkBoxUseMaxDebit.Checked = Program.iniFile.GetValueBool("price." + tag + ".enablemaxdebit");
            CheckBoxUseMaxDebit_CheckedChanged(null, null);
        }

        private void TextBoxPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                textBoxPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", double.Parse(textBoxPrice.Text));
            }
            catch { }
        }
        private void TextBoxBulkPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                textBoxBulkPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", double.Parse(textBoxBulkPrice.Text));
            }
            catch { }
        }
        private void TextBoxMaxDebitResetPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                textBoxMaxDebitResetPeriod.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#0}", int.Parse(textBoxMaxDebitResetPeriod.Text));
            }
            catch { }
        }

        private void CheckBoxUseMaxDebit_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUseMaxDebit.Enabled = checkBoxUseMaxDebit.Checked;
            Program.iniFile.SetValueBool("price." + currentTag + ".enablemaxdebit", checkBoxUseMaxDebit.Checked);
        }

        
        private void ButtonSaveNewPrice_Click(object sender, EventArgs e)
        {
            string msg = TestPriceValidity();
            if (msg == null)
            {


                
                this.listBoxPriceList.ForeColor = SystemColors.GrayText;
                this.Enabled = false;
                this.SuspendLayout();
                string dates = Program.iniFile.GetValueStr("pricelist." + currentTag + ".dates") + ";";
                string currentDate = dateTimePickerPriceDate.Value.ToString("yyyyMMdd");
                //HashSet<String> dateList = dates.Split(';').ToHashSet();
                SortedSet<string> dateList = new SortedSet<String>(dates.Split(';'))
                {
                    currentDate
                };
                Program.iniFile.SetValueStr("pricelist." + currentTag + ".dates", String.Join(";", dateList));

                Program.iniFile.SetValueDbl("pricelist." + currentTag + "." + currentDate + ".price", double.Parse(textBoxPrice.Text));
                Program.iniFile.SetValueBool("pricelist." + currentTag + "." + currentDate + ".usebulkprice", checkBoxUseMaxDebit.Checked);
                if (checkBoxUseMaxDebit.Checked)
                {
                    Program.iniFile.SetValueDbl("pricelist." + currentTag + "." + currentDate + ".bulkprice", double.Parse(textBoxBulkPrice.Text));
                    Program.iniFile.SetValueInt("pricelist." + currentTag + "." + currentDate + ".bulkpriceresetperiod", int.Parse(textBoxMaxDebitResetPeriod.Text));
                } else
                {
                    Program.iniFile.DeleteValue("pricelist." + currentTag + "." + currentDate + ".bulkprice");
                    Program.iniFile.DeleteValue("pricelist." + currentTag + "." + currentDate + ".bulkpriceresetperiod");
                }

                ((MainForm)myParent).RecalculateReport();
                LoadPriceList(currentTag);
                this.Enabled = true;
                this.listBoxPriceList.ForeColor = SystemColors.WindowText;
                this.ResumeLayout();

                ((MainForm)myParent).ShowCurrentPrices();
            }
            else
            {
                Helper.Dialog.ShowMessage("Felaktig inmatning", msg, Helper.Dialog.Buttons.Ok, myParent);
            }

        }
        private string TestPriceValidity()
        {
            string x;
            string msg = null;
            try
            {
                msg = "Pris är inte angivet korrekt";
                x = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", double.Parse(textBoxPrice.Text.Replace(".",",")));
                textBoxPrice.Text = x;
                if (checkBoxUseMaxDebit.Checked)
                {
                    msg = "Maxdebitering är inte angivet korrekt";
                    x = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#,##0.00#}", double.Parse(textBoxBulkPrice.Text.Replace(".", ",")));
                    textBoxBulkPrice.Text = x;
                    msg = "Maxdebiteringsperiod är inte angivet korrekt";
                    x = string.Format(System.Globalization.CultureInfo.GetCultureInfo("se-SV"), "{0:#0}", int.Parse(textBoxMaxDebitResetPeriod.Text.Replace(".", ",")
                        ));
                    textBoxMaxDebitResetPeriod.Text = x;

                    if ((double.Parse(textBoxBulkPrice.Text) == 0d && int.Parse(textBoxMaxDebitResetPeriod.Text) != 0) ||
                        (double.Parse(textBoxBulkPrice.Text) != 0d && int.Parse(textBoxMaxDebitResetPeriod.Text) == 0))
                    {
                        msg = "Maxdebitering kräver att både ett maxpris och en period anges";
                        return msg;
                    }
                }
                else
                {
                    textBoxBulkPrice.Text = "";
                    textBoxMaxDebitResetPeriod.Text = "";
                }


                return null;
            }
            catch
            {
                return msg;
            }
        }
    }
}
