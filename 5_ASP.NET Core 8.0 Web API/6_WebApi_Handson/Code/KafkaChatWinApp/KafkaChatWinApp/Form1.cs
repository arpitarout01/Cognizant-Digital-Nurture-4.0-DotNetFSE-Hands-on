using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;


namespace KafkaChatWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            string message = txtMessage.Text;

            await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });

            lstMessages.Items.Add("[You] " + message);
            txtMessage.Clear();

            producer.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => StartConsumer());
        }
        private void StartConsumer()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "winapp-chat-consumer",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("chat-topic");

            try
            {
                while (true)
                {
                    var cr = consumer.Consume();
                    Invoke(new Action(() =>
                    {
                        lstMessages.Items.Add("[Received] " + cr.Message.Value);
                    }));
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
            finally
            {
                consumer.Dispose();
            }
        }
    }
}
