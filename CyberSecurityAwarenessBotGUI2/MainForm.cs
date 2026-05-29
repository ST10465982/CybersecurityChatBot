using System;
using System.Drawing;
using System.Windows.Forms;
using CyberSecurityAwarenessBotGUI.Models;
using CyberSecurityAwarenessBotGUI.Services;

namespace CyberSecurityAwarenessBotGUI
{
    public partial class MainForm : Form
    {
        private TextBox txtUserInput;
        private Button btnSend;
        private RichTextBox rtbChat;
        private Label lblTitle;
        private Label lblAsciiArt;
        private Panel topPanel;
        private Panel inputPanel;

        private readonly UserMemory memory;
        private readonly ChatBotService chatBotService;
        private readonly AudioService audioService;

        public MainForm()
        {
            InitializeComponent();

            memory = new UserMemory();
            chatBotService = new ChatBotService(memory);
            audioService = new AudioService();

            BuildInterface();
            LoadWelcomeMessage();
            audioService.PlayGreeting();
        }

        private void BuildInterface()
        {
            this.Text = "Cybersecurity Awareness Bot - Part 2";
            this.Width = 950;
            this.Height = 700;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 23, 42);
            this.MinimumSize = new Size(850, 600);

            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 170;
            topPanel.BackColor = Color.FromArgb(30, 41, 59);
            this.Controls.Add(topPanel);

            lblTitle = new Label();
            lblTitle.Text = "Cybersecurity Awareness Assistant";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 55;
            topPanel.Controls.Add(lblTitle);

            lblAsciiArt = new Label();
            lblAsciiArt.Text =
@"   ____      _               
  / ___|   _| |__   ___ _ __ 
 | |  | | | | '_ \ / _ \ '__|
 | |__| |_| | |_) |  __/ |   
  \____\__, |_.__/ \___|_|   
       |___/  SECURITY BOT";

            lblAsciiArt.Font = new Font("Consolas", 11, FontStyle.Bold);
            lblAsciiArt.ForeColor = Color.FromArgb(56, 189, 248);
            lblAsciiArt.AutoSize = false;
            lblAsciiArt.TextAlign = ContentAlignment.MiddleCenter;
            lblAsciiArt.Dock = DockStyle.Fill;
            topPanel.Controls.Add(lblAsciiArt);

            inputPanel = new Panel();
            inputPanel.Dock = DockStyle.Bottom;
            inputPanel.Height = 80;
            inputPanel.BackColor = Color.FromArgb(30, 41, 59);
            this.Controls.Add(inputPanel);

            txtUserInput = new TextBox();
            txtUserInput.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtUserInput.Left = 20;
            txtUserInput.Top = 20;
            txtUserInput.Width = 700;
            txtUserInput.Height = 35;
            txtUserInput.Text = "";
            txtUserInput.KeyDown += TxtUserInput_KeyDown;
            inputPanel.Controls.Add(txtUserInput);

            btnSend = new Button();
            btnSend.Text = "Send";
            btnSend.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSend.BackColor = Color.FromArgb(14, 165, 233);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Left = 740;
            btnSend.Top = 18;
            btnSend.Width = 160;
            btnSend.Height = 40;
            btnSend.Click += BtnSend_Click;
            inputPanel.Controls.Add(btnSend);

            rtbChat = new RichTextBox();
            rtbChat.Dock = DockStyle.Fill;
            rtbChat.ReadOnly = true;
            rtbChat.BackColor = Color.FromArgb(2, 6, 23);
            rtbChat.ForeColor = Color.White;
            rtbChat.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            rtbChat.BorderStyle = BorderStyle.None;
            this.Controls.Add(rtbChat);

            this.Resize += MainForm_Resize;
        }

        private void LoadWelcomeMessage()
        {
            AddBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot.");
            AddBotMessage("I am here to help you stay safe online.");
            AddBotMessage("You can start by typing: My name is Onga");
            AddBotMessage("You can ask me about password safety, phishing, scams, privacy, malware, social engineering, or safe browsing.");
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendUserMessage();
        }

        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendUserMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void SendUserMessage()
        {
            string userMessage = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                AddBotMessage("Please type a message before pressing Send.");
                return;
            }

            AddUserMessage(userMessage);

            string botResponse = chatBotService.GetBotResponse(userMessage);
            AddBotMessage(botResponse);

            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        private void AddUserMessage(string message)
        {
            rtbChat.SelectionColor = Color.FromArgb(125, 211, 252);
            rtbChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            rtbChat.AppendText("You: ");

            rtbChat.SelectionColor = Color.White;
            rtbChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Regular);
            rtbChat.AppendText(message + Environment.NewLine + Environment.NewLine);

            rtbChat.ScrollToCaret();
        }

        private void AddBotMessage(string message)
        {
            rtbChat.SelectionColor = Color.FromArgb(34, 197, 94);
            rtbChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            rtbChat.AppendText("Bot: ");

            rtbChat.SelectionColor = Color.White;
            rtbChat.SelectionFont = new Font("Segoe UI", 11, FontStyle.Regular);
            rtbChat.AppendText(message + Environment.NewLine + Environment.NewLine);

            rtbChat.ScrollToCaret();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (txtUserInput != null && btnSend != null && inputPanel != null)
            {
                txtUserInput.Width = inputPanel.Width - 220;
                btnSend.Left = txtUserInput.Right + 20;
            }
        }
    }
}