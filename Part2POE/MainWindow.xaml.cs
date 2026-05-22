using CyberSecurityChatbot.Models;
using CyberSecurityChatbot.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatbot
{
    public partial class MainWindow : Window
    {
        private User currentUser;
        private string previousTopic = "";
        private ResponseManager responseManager;
        private KeywordHandler keywordHandler;

        public MainWindow()
        {
            InitializeComponent();

            currentUser = new User("Guest");
            responseManager = new ResponseManager();
            keywordHandler = new KeywordHandler();

            AddBotMessage("Welcome to CyberSecurity Chatbot!");
            AddBotMessage("Please enter your name to begin.");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessInput();
            }
        }

        private void ProcessInput()
        {
            string input = UserInputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                AddBotMessage("Type something please.");
                return;
            }

            AddUserMessage(input);
            HandleInput(input.ToLower());

            UserInputTextBox.Clear();
        }

        private void HandleInput(string input)
        {
            // STEP 1: Set username
            if (currentUser.Username == "Guest")
            {
                currentUser.Username = input;
                AddBotMessage($"Nice to meet you {currentUser.Username}!");
                return;
            }

            // STEP 2: detect topic
            string topic = keywordHandler.GetTopic(input);

            // STEP 3: tips
            if (input.Contains("tip"))
            {
                previousTopic = topic;

                string tip = responseManager.GetRandomTip(topic);

                AddBotMessage(tip);
                return;
            }

            // STEP 4: normal response
            string response = keywordHandler.GetKeywordResponse(input);

            if (!string.IsNullOrEmpty(response))
            {
                previousTopic = topic;
                AddBotMessage(response);
                return;
            }

            AddBotMessage("Sorry, I don't understand. Try phishing, password, malware, or privacy.");
        }

        private void AddUserMessage(string message)
        {
            ChatPanel.Children.Add(new System.Windows.Controls.TextBlock
            {
                Text = "You: " + message
            });

            ChatScrollViewer.ScrollToEnd();
        }

        private void AddBotMessage(string message)
        {
            ChatPanel.Children.Add(new System.Windows.Controls.TextBlock
            {
                Text = "Bot: " + message
            });

            ChatScrollViewer.ScrollToEnd();
        }
    }
}