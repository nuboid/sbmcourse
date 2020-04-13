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

namespace MyResearch.Auth.JWTToken.DemoClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            var tokenAsText = File.ReadAllText(Environment.CurrentDirectory + @"\..\..\..\MyResearch.Auth.JWTToken.Generator\bin\Debug\netcoreapp3.1\jwttoken.txt");

            try
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization
                   =
                   new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenAsText);

                var url = @"http://localhost:9001/api/pingsecure";
                textBox2.Text = url;

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                textBox1.Text = json;
            }
            catch (Exception ex) 
            {
                textBox1.Text = ex.ToString();
            }
          
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            try
            {
                var httpClient = new HttpClient();

                var url = @"http://localhost:9001/api/pingsecure";
                textBox2.Text = url;
                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();


                textBox1.Text = json;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.ToString();
            }
        }
    }
}
