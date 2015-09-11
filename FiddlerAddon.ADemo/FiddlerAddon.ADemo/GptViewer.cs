using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FiddlerAddon.ADemo
{
    public partial class GptViewer : UserControl
    {
        public GptViewer()
        {
            InitializeComponent();
        }

        public void DisplayData(GptRecord gptRecord)
        {
            lstvGpt.Items.Clear();

            lstvGpt.Items.Add("DartSite").SubItems.Add(gptRecord.DartSite);

            lstvGpt.Items.Add("Size").SubItems.Add(gptRecord.Size);

            lstvGpt.Items.Add("Sponsorship").SubItems.Add(gptRecord.Sponsorship);

            lstvGpt.Items.Add("CustParams").SubItems.Add(gptRecord.CustParams);

            this.Refresh();
        }
    }

    public class GptRecord
    {
        public string DartSite { get; set; }
        public string Size { get; set; }
        public string Sponsorship { get; set; }
        public string CustParams { get; set; }
    }
}
