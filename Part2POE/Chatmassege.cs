using System;

namespace CyberSecurityChatbot.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }   // "User" or "Bot"
        public string Message { get; set; }
        public DateTime TimeSent { get; set; }

        public ChatMessage(string sender, string message)
        {
            Sender = sender;
            Message = message;
            TimeSent = DateTime.Now;
        }
    }
}