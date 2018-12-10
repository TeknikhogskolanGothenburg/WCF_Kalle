using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarServiceWindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarService.CarServiceClient client = new
                CarService.CarServiceClient("NetTcpBinding_ICarService");
            label1.Text = client.GetMessage(textBox1.Text);
        }
    }
}
