using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot.Services
{
    public class ResponseManager
    {
        private Random random = new Random();

        // Password Tips
        private List<string> passwordTips = new List<string>
        {
            "Use a strong password with letters, numbers, and symbols.",
            "Never use your name or birthdate as a password.",
            "Change your passwords regularly.",
            "Use different passwords for different accounts."
        };

        // Phishing Tips
        private List<string> phishingTips = new List<string>
        {
            "Do not click suspicious email links.",
            "Check the sender’s email address carefully.",
            "Never share personal information through email.",
            "Watch out for urgent messages asking for money or passwords."
        };

        // Scam Tips
        private List<string> scamTips = new List<string>
        {
            "Avoid offers that seem too good to be true.",
            "Never send money to unknown people online.",
            "Verify company details before making payments.",
            "Scammers often create urgency to trick victims."
        };

        // Privacy Tips
        private List<string> privacyTips = new List<string>
        {
            "Review your privacy settings on social media.",
            "Do not share personal information publicly.",
            "Use secure websites (HTTPS).",
            "Limit app permissions on your phone."
        };

        // Safe Browsing Tips
        private List<string> safeBrowsingTips = new List<string>
        {
            "Only visit trusted websites.",
            "Avoid downloading files from unknown sites.",
            "Keep your browser updated.",
            "Look for HTTPS before entering sensitive information."
        };

        // Random tip methods
        public string GetRandomPasswordTip()
        {
            return passwordTips[random.Next(passwordTips.Count)];
        }

        public string GetRandomPhishingTip()
        {
            return phishingTips[random.Next(phishingTips.Count)];
        }

        public string GetRandomScamTip()
        {
            return scamTips[random.Next(scamTips.Count)];
        }

        public string GetRandomPrivacyTip()
        {
            return privacyTips[random.Next(privacyTips.Count)];
        }

        public string GetRandomSafeBrowsingTip()
        {
            return safeBrowsingTips[random.Next(safeBrowsingTips.Count)];
        }

        // Topic-based random tip
        public string GetRandomTip(string topic)
        {
            switch (topic.ToLower())
            {
                case "password":
                case "password tips":
                case "password safety":
                case "password safety tips":
                    return GetRandomPasswordTip();

                case "phishing":
                case "phishing tips":
                    return GetRandomPhishingTip();

                case "scam":
                case "scam tips":
                    return GetRandomScamTip();

                case "privacy":
                case "privacy tips":
                    return GetRandomPrivacyTip();

                case "safe browsing":
                case "safe browsing tips":
                    return GetRandomSafeBrowsingTip();

                default:
                    return "I don’t have tips for that topic yet.";
            }
        }

        // Basic direct responses
        public string GetKeywordResponse(string keyword)
        {
            switch (keyword.ToLower())
            {
                case "password":
                    return "Passwords protect your accounts. Use strong and unique passwords.";

                case "phishing":
                    return "Phishing is a fake message or email designed to steal your information.";

                case "scam":
                    return "Scams trick people into giving money or personal information.";

                case "privacy":
                    return "Privacy means protecting your personal information online.";

                case "safe browsing":
                    return "Safe browsing means using the internet carefully and avoiding dangerous websites.";

                default:
                    return "I’m not sure about that. Can you ask in another way?";
            }
        }
    }
}