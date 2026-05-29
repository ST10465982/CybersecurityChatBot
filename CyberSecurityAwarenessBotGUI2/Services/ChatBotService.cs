using CyberSecurityAwarenessBotGUI.Models;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class ChatBotService
    {
        private readonly UserMemory memory;
        private readonly SentimentService sentimentService;
        private readonly Random random;

        private readonly Dictionary<string, List<string>> topicResponses;

        public ChatBotService(UserMemory userMemory)
        {
            memory = userMemory;
            sentimentService = new SentimentService();
            random = new Random();

            topicResponses = new Dictionary<string, List<string>>
            {
                {
                    "password",
                    new List<string>
                    {
                        "Use strong, unique passwords for each account. A good password should include uppercase letters, lowercase letters, numbers, and symbols.",
                        "Avoid using your name, birthday, school name, or phone number in your password because those are easy to guess.",
                        "A password manager can help you store strong passwords safely instead of reusing the same password everywhere."
                    }
                },
                {
                    "phishing",
                    new List<string>
                    {
                        "Phishing is when criminals pretend to be trusted companies to trick you into giving personal information.",
                        "Always check the sender's email address before clicking links. Scammers often use addresses that look almost real.",
                        "Do not click suspicious links in emails or SMS messages. Rather visit the official website by typing the address yourself."
                    }
                },
                {
                    "scam",
                    new List<string>
                    {
                        "Online scams often create pressure by saying things like 'act now' or 'your account will be blocked'. Take your time and verify first.",
                        "Never send your banking details, OTP, PIN, or password to anyone, even if they claim to be from a bank.",
                        "If an offer looks too good to be true, it is usually a scam. Always confirm through official channels."
                    }
                },
                {
                    "privacy",
                    new List<string>
                    {
                        "Protect your privacy by limiting what you share online, especially your address, school, phone number, and daily location.",
                        "Review your social media privacy settings so only trusted people can see your personal posts.",
                        "Be careful with apps that ask for unnecessary permissions, such as access to your contacts, camera, or location."
                    }
                },
                {
                    "browsing",
                    new List<string>
                    {
                        "Use secure websites that start with HTTPS, especially when entering personal or payment information.",
                        "Avoid downloading files from unknown websites because they may contain malware.",
                        "Keep your browser updated because updates fix security weaknesses that criminals may use."
                    }
                },
                {
                    "malware",
                    new List<string>
                    {
                        "Malware is harmful software that can damage your device, steal information, or spy on your activity.",
                        "Avoid opening unknown attachments because they may install malware on your device.",
                        "Use antivirus protection and keep your system updated to reduce malware risks."
                    }
                },
                {
                    "social engineering",
                    new List<string>
                    {
                        "Social engineering is when criminals manipulate people into giving away information or access.",
                        "Be careful when someone asks for urgent help, money, passwords, or verification codes.",
                        "Always verify a person's identity before sharing private information."
                    }
                }
            };
        }

        public string GetBotResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please type something so I can help you with cybersecurity awareness.";
            }

            string input = userInput.ToLower().Trim();

            string sentiment = sentimentService.DetectSentiment(input);
            string sentimentMessage = sentimentService.GetSentimentResponse(sentiment);

            // Store user's name
            if (input.StartsWith("my name is "))
            {
                memory.UserName = userInput.Substring(11).Trim();
                memory.HasGreetedUser = true;

                return $"Nice to meet you, {memory.UserName}! I’ll remember your name. You can ask me about passwords, phishing, scams, privacy, malware, or safe browsing.";
            }

            if (input.StartsWith("i am "))
            {
                memory.UserName = userInput.Substring(5).Trim();
                memory.HasGreetedUser = true;

                return $"Great to meet you, {memory.UserName}! I’m your Cybersecurity Awareness Assistant. Ask me about password safety, phishing, scams, privacy, or safe browsing.";
            }

            // Store favourite topic
            if (input.Contains("interested in password") || input.Contains("like password"))
            {
                memory.FavouriteTopic = "password";
                memory.LastTopic = "password";
                return "Great! I’ll remember that you are interested in password safety. Strong passwords are one of the best ways to protect your accounts.";
            }

            if (input.Contains("interested in privacy") || input.Contains("like privacy"))
            {
                memory.FavouriteTopic = "privacy";
                memory.LastTopic = "privacy";
                return "Great! I’ll remember that you are interested in privacy. Privacy helps you control what personal information others can access.";
            }

            if (input.Contains("interested in phishing") || input.Contains("like phishing"))
            {
                memory.FavouriteTopic = "phishing";
                memory.LastTopic = "phishing";
                return "Great! I’ll remember that you are interested in phishing awareness. Learning to spot fake messages can protect you from scams.";
            }

            // General questions
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                if (!string.IsNullOrWhiteSpace(memory.UserName))
                {
                    return $"Hello {memory.UserName}! How can I help you stay safe online today?";
                }

                return "Hello! I’m your Cybersecurity Awareness Assistant. You can tell me your name by typing: My name is Onga.";
            }

            if (input.Contains("how are you"))
            {
                return "I’m doing great, thank you! I’m ready to help you learn how to stay safe online.";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to teach South African citizens about cybersecurity topics like phishing, scams, privacy, password safety, malware, and safe browsing.";
            }

            if (input.Contains("what can i ask") || input.Contains("help"))
            {
                return "You can ask me about password safety, phishing tips, online scams, privacy, malware, social engineering, and safe browsing.";
            }

            // Follow-up conversation
            if (input.Contains("tell me more") || input.Contains("explain more") || input.Contains("another tip") || input.Contains("more"))
            {
                if (!string.IsNullOrWhiteSpace(memory.LastTopic) && topicResponses.ContainsKey(memory.LastTopic))
                {
                    return GetRandomTopicResponse(memory.LastTopic);
                }

                if (!string.IsNullOrWhiteSpace(memory.FavouriteTopic) && topicResponses.ContainsKey(memory.FavouriteTopic))
                {
                    return $"Since you are interested in {memory.FavouriteTopic}, here is another tip: {GetRandomTopicResponse(memory.FavouriteTopic)}";
                }

                return "Sure. Which topic would you like to know more about: password safety, phishing, scams, privacy, malware, or safe browsing?";
            }

            // Keyword recognition
            foreach (var topic in topicResponses.Keys)
            {
                if (input.Contains(topic))
                {
                    memory.LastTopic = topic;

                    if (string.IsNullOrWhiteSpace(memory.FavouriteTopic))
                    {
                        memory.FavouriteTopic = topic;
                    }

                    string response = GetRandomTopicResponse(topic);

                    if (!string.IsNullOrWhiteSpace(sentimentMessage))
                    {
                        return sentimentMessage + Environment.NewLine + Environment.NewLine + response;
                    }

                    return response;
                }
            }

            // Extra recognition for safe browsing
            if (input.Contains("safe browsing") || input.Contains("website") || input.Contains("link") || input.Contains("download"))
            {
                memory.LastTopic = "browsing";
                return GetRandomTopicResponse("browsing");
            }

            // Memory recall
            if (input.Contains("what is my name") || input.Contains("do you remember my name"))
            {
                if (!string.IsNullOrWhiteSpace(memory.UserName))
                {
                    return $"Yes, your name is {memory.UserName}.";
                }

                return "I don’t know your name yet. You can tell me by typing: My name is Onga.";
            }

            if (input.Contains("what is my favourite topic") || input.Contains("favorite topic"))
            {
                if (!string.IsNullOrWhiteSpace(memory.FavouriteTopic))
                {
                    return $"Your favourite cybersecurity topic is {memory.FavouriteTopic}.";
                }

                return "I don’t know your favourite topic yet. You can say something like: I am interested in privacy.";
            }

            // Sentiment without clear topic
            if (!string.IsNullOrWhiteSpace(sentimentMessage))
            {
                return sentimentMessage + Environment.NewLine + Environment.NewLine +
                       "You can ask me about password safety, phishing, scams, privacy, malware, or safe browsing.";
            }

            // Default response
            return "I'm not sure I understand. Can you try rephrasing? You can ask me about passwords, phishing, scams, privacy, malware, or safe browsing.";
        }

        private string GetRandomTopicResponse(string topic)
        {
            List<string> responses = topicResponses[topic];
            int index = random.Next(responses.Count);

            return responses[index];
        }
    }
}