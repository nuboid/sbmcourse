using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyResearch.APIGateway.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyApplication.APIHost\bin\Debug\netcoreapp3.1\MyApplication.APIHost.exe", "http://localhost:9001;https://localhost:10001");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyApplication.APIHost\bin\Debug\netcoreapp3.1\MyApplication.APIHost.exe", "http://localhost:9002;https://localhost:10002");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.File.Copy(Environment.CurrentDirectory + @"\..\..\..\MySoftwareCompany.APIGateway.Host\ocelot.json", Environment.CurrentDirectory + @"\ocelot.json", true);
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MySoftwareCompany.APIGateway.Host\bin\Debug\netcoreapp3.1\MySoftwareCompany.APIGateway.Host.exe");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10000; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(@"https://localhost:10000/gateway/ping");
                    var json = await response.Content.ReadAsStringAsync();
                    label1.Text = "call #" + i.ToString() + " executed by node " + json.Substring(json.Length - 1, 1);

                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "docker run -p 8500:8500 consul";
            label1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:8500");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 13; i <= 23; i++)
            {
                var par = string.Format("http://localhost:90{0};https://localhost:100{0}", i);

                System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyApplication.APIHost\bin\Debug\netcoreapp3.1\MyApplication.APIHost.exe", par);
            }
            
        }
    }
}
