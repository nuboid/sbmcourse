using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoRefitInterfaces;
using Refit;

namespace RefitClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = RestService.For<IWeatherForecastController>("http://localhost:5000");

            try
            {
                var wf = await client.Get();
            }
            catch (Refit.ApiException ex)
            {
               
            }
        }
    }
}
