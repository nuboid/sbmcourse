using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyResearch.ServiceDiscovery.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label8.Text = "docker run -p 8500:8500 consul";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyResearch.ServiceDiscovery.Service001\bin\Debug\netcoreapp3.1\MyResearch.ServiceDiscovery.Service001.exe", "http://localhost:9001;https://localhost:10001");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyResearch.ServiceDiscovery.Service001\bin\Debug\netcoreapp3.1\MyResearch.ServiceDiscovery.Service001.exe", "http://localhost:9002;https://localhost:10002");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:8500");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //https://www.consul.io/api/index.html
            var httpClient = new HttpClient();
            var url = "http://localhost:8500/v1/catalog/services";
            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            textBox2.Text = json;
        }

        private async void button4_Click(object sender, EventArgs e)
        {

        //http://localhost:8500/v1/health/service/myservice
            textBox2.Text = "";
            var httpClient = new HttpClient();
            var url = "http://localhost:8500/v1/catalog/service/MyService";

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                textBox2.Text = JsonPrettify(json);
            }
            catch (Exception ex)
            {

                textBox2.Text = ex.ToString();
            }
           
        }

        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
