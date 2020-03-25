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
            try
            {
                if (_senderChannel != null)
                {

                    string message = tbSenderMessage.Text.Trim() + " " + DateTime.Now.Ticks.ToString() + " " + tbSenderRoutingKey.Text;
                    var body = Encoding.UTF8.GetBytes(message);

                    _senderChannel.ConfirmSelect();

                    _senderChannel.BasicPublish(
                            exchange: tbSenderExhangeName.Text,
                            routingKey: tbSenderRoutingKey.Text,
                            basicProperties: null,
                            body: body);

                    _senderChannel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 5));

                    label10.Text = "Sent : " + message;
                }
                else
                {
                    MessageBox.Show("SenderChannel not created");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetType().ToString());
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

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:15672");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management";
            label10.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyReseach.QueueListener\bin\Debug\netcoreapp3.1\MyReseach.QueueListener.exe", "Queue001");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyReseach.QueueListener\bin\Debug\netcoreapp3.1\MyReseach.QueueListener.exe", "Queue002");
        }

        private IModel _senderChannel;
        private void button20_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _senderChannel = connection.CreateModel();

            MessageBox.Show("Channel created");
        }
    }

}
