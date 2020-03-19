using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyResearch.Messaging.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: tbQueueName.Text,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            }
            MessageBox.Show("Done");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: tbExchangeName.Text,
                                        durable: true,
                                        type: "topic");
            }
            MessageBox.Show("Done");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueBind(queue: tbQueueName.Text,
                                 exchange: tbExchangeName.Text,
                                 routingKey: tbRoutingKey.Text);
            }
            MessageBox.Show("Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                string message = tbSenderMessage.Text.Trim() + " " + DateTime.Now.Ticks.ToString() + " " + tbSenderRoutingKey.Text;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: tbSenderExhangeName.Text,
                                     routingKey: tbSenderRoutingKey.Text,
                                     basicProperties: null,
                                     body: body);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbQueueName.Text = "Queue001";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbQueueName.Text = "Queue002";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tbExchangeName.Text = "Exchange";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tbRoutingKey.Text = "KEY.A";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tbRoutingKey.Text = "KEY.B";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tbSenderExhangeName.Text = "Exchange";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbSenderMessage.Text = "Message 1 ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbSenderMessage.Text = "Message 2 ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbSenderMessage.Text = "Message 3 ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tbSenderRoutingKey.Text = "KEY.A";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tbSenderRoutingKey.Text = "KEY.B";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tbRoutingKey.Text = "KEY.*";
        }
    }

}
