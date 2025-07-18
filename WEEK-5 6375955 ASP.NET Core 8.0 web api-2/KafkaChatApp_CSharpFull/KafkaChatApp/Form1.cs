using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace KafkaChatApp
{
    public partial class Form1 : Form
    {
        private KafkaProducer? _producer;
        private KafkaConsumer? _consumer;
        private const string BootstrapServers = "localhost:9092";
        private const string Topic = "chat_topic";
        private string _clientName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Choose a name: use textbox if filled, else auto.
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                _clientName = Environment.UserName + "-" + Guid.NewGuid().ToString("N").Substring(0, 4);
                txtName.Text = _clientName;
            }
            else
            {
                _clientName = txtName.Text.Trim();
            }

            _producer = new KafkaProducer(BootstrapServers, Topic);

            // Use unique group per client to receive all messages (broadcast)
            var groupId = "chat-" + Guid.NewGuid().ToString("N").Substring(0, 8);
            _consumer = new KafkaConsumer(BootstrapServers, groupId, Topic);

            await _consumer.StartAsync(OnIncomingMessage);
            AppendChatLine($"[{_clientName}] connected.");
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (_producer == null) return;
            if (string.IsNullOrWhiteSpace(_clientName))
            {
                _clientName = txtName.Text.Trim();
                if (string.IsNullOrEmpty(_clientName))
                    _clientName = Environment.UserName;
            }

            var text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            var outbound = $"{_clientName}: {text}";
            AppendChatLine(outbound);
            await _producer.ProduceMessageAsync(outbound);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void OnIncomingMessage(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(OnIncomingMessage), msg);
                return;
            }
            AppendChatLine(msg);
        }

        private void AppendChatLine(string line)
        {
            txtChat.AppendText(line + Environment.NewLine);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _consumer?.Stop();
            _consumer?.Dispose();
            _producer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
