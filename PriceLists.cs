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
    public partial class PriceLists : UserControl
    {
        readonly PriceList myPriceListLaundry;
        readonly PriceList myPriceListRelax;
        readonly PriceList myPriceListApartment;
        readonly PriceList myPriceListParking;
        readonly PriceList myPriceListCharging;

        public PriceLists(Form parent)
        {
            myPriceListLaundry = new PriceList("laundry", parent);
            myPriceListRelax = new PriceList("relax", parent);
            myPriceListApartment = new PriceList("apartment", parent);
            myPriceListParking = new PriceList("parking", parent);
            myPriceListCharging = new PriceList("charging", parent);

            InitializeComponent();
            ShowCurrentPrices();

            int w=0, h=0;
            TabPage x = new TabPage("Tvättstuga");
            w = (w > myPriceListLaundry.Size.Width ? w : myPriceListLaundry.Size.Width);
            x.Controls.Add(myPriceListLaundry);
            tabControl1.Controls.Add(x);
            x = new TabPage("Relax");
            w = (w > myPriceListRelax.Size.Width ? w : myPriceListRelax.Size.Width);
            x.Controls.Add(myPriceListRelax);
            tabControl1.Controls.Add(x);
            x = new TabPage("Gästlägenhet");
            w = (w > myPriceListApartment.Size.Width ? w : myPriceListApartment.Size.Width);
            x.Controls.Add(myPriceListApartment);
            tabControl1.Controls.Add(x);
            x = new TabPage("Gästparkering");
            w = (w > myPriceListParking.Size.Width ? w : myPriceListParking.Size.Width);
            x.Controls.Add(myPriceListParking);
            tabControl1.Controls.Add(x);
            x = new TabPage("Elektricitet");
            w = (w > myPriceListCharging.Size.Width ? w : myPriceListCharging.Size.Width);
            x.Controls.Add(myPriceListCharging);
            tabControl1.Controls.Add(x);
            h = myPriceListCharging.Size.Height + 30;
            tabControl1.ClientSize = new Size(w, h);

        }

        public void ShowCurrentPrices()
        {

            labelCurrentLaundryPrice.Text = "Tvättstuga: " + Program.GetPrice("laundry", DateTime.Now).Price + " per " + Program.GetPrice("laundry", DateTime.Now).unitname;
            labelCurrentRelaxPrice.Text = "Relax: " + Program.GetPrice("relax", DateTime.Now).Price + " per " + Program.GetPrice("relax", DateTime.Now).unitname;
            labelCurrentApartmentPrice.Text = "Gästlägenhet: " + Program.GetPrice("apartment", DateTime.Now).Price + " per " + Program.GetPrice("apartment", DateTime.Now).unitname;
            labelCurrentParkingPrice.Text = "Gästparkering: " + Program.GetPrice("parking", DateTime.Now).Price + " per " + Program.GetPrice("parking", DateTime.Now).unitname;
            labelCurrentElectricityPrice.Text = "Elpris: " + Program.GetPrice("charging", DateTime.Now).Price + " per " + Program.GetPrice("charging", DateTime.Now).unitname;

        }



    }
}
