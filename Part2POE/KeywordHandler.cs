using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot.Services
{
    public class KeywordHandler
    {
        private Dictionary<string, List<string>> keywordMap;

        public KeywordHandler()
        {
            keywordMap = new Dictionary<string, List<string>>()
            {
                { "phishing", new List<string> { "phishing", "fake email", "scam email", "fraud email", "suspicious link" } },
                { "password", new List<string> { "password", "strong password", "password safety", "change password" } },
                { "malware", new List<string> { "malware", "virus", "trojan", "spyware", "ransomware" } },
                { "hacking", new List<string> { "hacking", "hacked", "breach", "account stolen" } },
                { "privacy", new List<string> { "privacy", "data protection", "personal data", "online safety" } }
            };
        }

        // This fixes GetTopic() error
        public string GetTopic(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "";

            userInput = userInput.ToLower();

            foreach (var category in keywordMap)
            {
                foreach (var keyword in category.Value)
                {
                    if (userInput.Contains(keyword))
                    {
                        return category.Key;
                    }
                }
            }

            return "";
        }

        // This fixes GetKeywordResponse() error
        public string GetKeywordResponse(string userInput)
        {
            string topic = GetTopic(userInput);

            switch (topic)
            {
                case "phishing":
                    return "Phishing is a fake email or message used to steal personal information.";

                case "password":
                    return "Use strong passwords with letters, numbers, and symbols.";

                case "malware":
                    return "Malware is harmful software such as viruses, spyware, or ransomware.";

                case "hacking":
                    return "Hacking is unauthorized access to systems or accounts.";

                case "privacy":
                    return "Privacy means protecting your personal information online.";

                default:
                    return "";
            }
        }
    }
}