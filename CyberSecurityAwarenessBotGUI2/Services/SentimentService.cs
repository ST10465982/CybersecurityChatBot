namespace CyberSecurityAwarenessBotGUI.Services
{
    public class SentimentService
    {
        public string DetectSentiment(string userInput)
        {
            string input = userInput.ToLower();

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid") || input.Contains("nervous"))
            {
                return "worried";
            }

            if (input.Contains("curious") || input.Contains("interested") || input.Contains("want to know") || input.Contains("tell me"))
            {
                return "curious";
            }

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("confused") || input.Contains("annoyed"))
            {
                return "frustrated";
            }

            return "neutral";
        }

        public string GetSentimentResponse(string sentiment)
        {
            switch (sentiment)
            {
                case "worried":
                    return "It's completely understandable to feel worried. Cyber threats can seem scary, but learning simple safety steps can protect you.";

                case "curious":
                    return "I like that you're curious. Cybersecurity is easier to understand when we break it into simple steps.";

                case "frustrated":
                    return "I understand that this can feel frustrating. Let me explain it in a simple and clear way.";

                default:
                    return "";
            }
        }
    }
}