using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;

class Program
{
    private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
    private static string userName;

    static async Task Main()
    {

        synthesizer.SelectVoice("Microsoft David Desktop");
        synthesizer.Rate = 2;

        // Asynchronously speak the text
        await SpeakAsync("Hi there! Welcome to the Cybersecurity Awareness Bot. I'm Grace, here to help you stay safe online. Can you please tell me your name?");

        DisplayASCIIArt();
        await InteractWithUser();
    }

    static void DisplayASCIIArt()
    {
        string asciiArt = @" 
******************
*  GRACE AI   *
******************
      .-'`   `'-.
   _,.'.===   ===.'.,_
  / /  .___. .___.  \ \
 / /   ( o ) ( o )   \ \                                            _
: /|    '-'___'-'    |\ ;                                          (_)
| |`\_,.-'`   `""-.,_/'| |                                          /|
| |  \             /  | |                                         /\;
| |   \           /   | | _                              ___     /\/
| |    \   __    /\   | |' `\-.-.-.-.-.-.-.-.-.-.-.-.-./`   `""-,/\/ 
| |     \ (__)  /\ `-'| |    `\ \ \ \ \ \ \ \ \ \ \ \ \`\       \/
| |      \-...-/  `-,_| |      \`\ \ \ \ \ \ \ \ \ \ \ \ \       \
| |       '---'    /  | |       | | | | | | | | | | | | | |       |
| |               |   | |       | | | | | | | | | | | | | |       |
\_/               |   \_/       | | | | | | | | | | | | | | .--.  ;
                  |       .--.  | | | | | | | | | | | | | | |  | /
                   \      |  | / / / / / / / / / / / / / /  |  |/
                   |`-.___|  |/-'-'-'-'-'-'-'-'-'-'-'-'-'`--|  |
            ,.-----'~~;   |  |                  (_(_(______)|  |
           (_(_(_______)  |  |                        ,-----`~~~\
                    ,-----`~~~\                      (_(_(_______)
                   (_(_(_______)
**********************************
*  Cybersecurity awareness bot   *
**********************************
"

;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    static async Task InteractWithUser()

    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintWithTypingAnimation("GRACE AI: Hey there! I'm GRACE, your friendly Cybersecurity Awareness Bot.");
        Console.ResetColor();

        PrintWithTypingAnimation("\nGRACE AI: What can I call you? (Please enter your name): ");
        userName = Console.ReadLine();

        if (!string.IsNullOrEmpty(userName))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"GRACE AI: WOW! Nice name, {userName}!");
            await SpeakAsync($"now let's text {userName}!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation("GRACE AI: Oops! I didn't catch your name. Could you try again? ");
            Console.ResetColor();
        }

        await AskHowAreYou();
        await AskQuestions();
    }

    static async Task SpeakAsync(string message)
    {
        await Task.Run(() => synthesizer.SpeakAsync(message));
    }

    static async Task AskHowAreYou()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation($"GRACE AI: Otherwise, {userName}, how is your day going?? ");
        Console.ResetColor();
        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string response = Console.ReadLine();
        Console.ResetColor();

        if (response.ToLower() == "stop" || response.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("GRACE AI: Goodbye! Stay safe and take care! ");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (response.ToLower().Contains("good and you") || response.ToLower().Contains("great and you"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"GRACE AI: That's awesome, {userName}! I am a bot, and I am happy if you are happy!");
        }
        else if (response.ToLower().Contains("good") || response.ToLower().Contains("great"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation($"GRACE AI: That's awesome, {userName}! I am glad to hear that!");
        }
        else if (response.ToLower().Contains("bad") || response.ToLower().Contains("not good"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation($"GRACE AI: Oh no, {userName}. I hope your day gets better soon!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintWithTypingAnimation($"GRACE AI: Thanks for sharing, {userName}!");
        }
        Console.ResetColor();

    }

    static async Task AskQuestions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("GRACE AI: What can I help you with today? Here are some topics I can assist you with:");
        Console.ResetColor();
        PrintWithTypingAnimation("GRACE AI: 1. Phishing");
        PrintWithTypingAnimation("GRACE AI: 2. Password Safety");
        PrintWithTypingAnimation("GRACE AI: 3. Two-Factor Authentication");
        PrintWithTypingAnimation("GRACE AI: 4. Ransomware");
        PrintWithTypingAnimation("GRACE AI: 5. Social Engineering");
        PrintWithTypingAnimation("GRACE AI: 6. Safe Browsing");
        PrintWithTypingAnimation("GRACE AI: 7. Malware");
        PrintWithTypingAnimation("GRACE AI: 8. Cyber Hygiene");
        PrintWithTypingAnimation("GRACE AI: Type the number or name of your chosen topic, or type 'exit' to say goodbye.");

        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string userQuestion = Console.ReadLine().ToLower();
        Console.ResetColor();

        if (userQuestion == "stop" || userQuestion == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("GRACE AI: Goodbye! Stay safe and take care! ");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (int.TryParse(userQuestion, out int choice) && choice >= 1 && choice <= 8)
        {
            switch (choice)
            {
                case 1:
                    PhishingResponse();
                    break;
                case 2:
                    PasswordSafetyResponse();
                    break;
                case 3:
                    TwoFactorAuthenticationResponse();
                    break;
                case 4:
                    RansomwareResponse();
                    break;
                case 5:
                    SocialEngineeringResponse();
                    break;
                case 6:
                    SafeBrowsingResponse();
                    break;
                case 7:
                    MalwareResponse();
                    break;
                case 8:
                    CyberHygieneResponse();
                    break;
            }
        }
        else
        {
            switch (userQuestion)
            {
                case "phishing":
                    PhishingResponse();
                    break;
                case "password safety":
                    PasswordSafetyResponse();
                    break;
                case "two-factor authentication":
                    TwoFactorAuthenticationResponse();
                    break;
                case "ransomware":
                    RansomwareResponse();
                    break;
                case "social engineering":
                    SocialEngineeringResponse();
                    break;
                case "safe browsing":
                    SafeBrowsingResponse();
                    break;
                case "malware":
                    MalwareResponse();
                    break;
                case "cyber hygiene":
                    CyberHygieneResponse();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintWithTypingAnimation("GRACE AI: Oops! I don't have information on that topic. Please choose one of the listed topics, like phishing, password safety, ransomware, or cyber hygiene.");
                    Console.ResetColor();
                    break;
            }
        }

        await AskNextStep();
    }


    static async Task AskNextStep()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("GRACE AI: Would you like to go back to the main menu or type a topic to learn more? (Type 'menu' to go back or type a topic): ");
        Console.ResetColor();
        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string nextStep = Console.ReadLine();
        Console.ResetColor();

        if (nextStep.ToLower() == "stop" || nextStep.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("GRACE AI: Goodbye! Stay safe and take care! ");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (nextStep == "menu")
        {
            await AskQuestions();
        }
        else
        {
            switch (nextStep)
            {
                case "phishing":
                    PhishingResponse();
                    break;
                case "password safety":
                    PasswordSafetyResponse();
                    break;
                case "two-factor authentication":
                    TwoFactorAuthenticationResponse();
                    break;
                case "ransomware":
                    RansomwareResponse();
                    break;
                case "social engineering":
                    SocialEngineeringResponse();
                    break;
                case "safe browsing":
                    SafeBrowsingResponse();
                    break;
                case "malware":
                    MalwareResponse();
                    break;
                case "cyber hygiene":
                    CyberHygieneResponse();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintWithTypingAnimation("GRACE AI: Oops! I don't have information on that topic. Please choose one of the listed topics, like phishing, password safety, ransomware, or cyber hygiene.");
                    Console.ResetColor();
                    break;
            }
            await AskNextStep();
        }
    }

    static void PhishingResponse()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        PrintWithTypingAnimation("GRACE AI: Phishing is a form of cyber attack where attackers deceive individuals into sharing sensitive information such as usernames, passwords, or financial information by impersonating legitimate entities. The attackers usually do this through emails, messages, or fake websites that look like those from trusted organizations, banks, or even your friends. Phishing emails often contain urgent messages or links that trick you into entering your personal details. A major risk of phishing attacks is that they can lead to identity theft, financial loss, and malware installation.");
        PrintWithTypingAnimation("GRACE AI: To protect yourself, be cautious of unsolicited emails or messages, especially those requesting personal information. Avoid clicking on links or downloading attachments from unfamiliar sources. Always verify the sender's email address and, when in doubt, contact the organization directly through official channels.");
        Console.ResetColor();
        AskForFeedback("Phishing");
    }

    static void PasswordSafetyResponse()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintWithTypingAnimation("GRACE AI: Password safety is crucial in preventing unauthorized access to your online accounts. A good password is long, unique, and complex, combining letters (both uppercase and lowercase), numbers, and special characters. It's essential to avoid reusing passwords across multiple sites, as a breach on one website can compromise other accounts. Password managers are great tools to store and generate strong passwords, and they can also help you avoid password fatigue. Also, consider changing your passwords periodically and enabling two-factor authentication (2FA) for added security.");
        PrintWithTypingAnimation("GRACE AI: Here are some tips for creating a strong password: 1. Use at least 12 characters. 2. Include a mix of letters, numbers, and symbols. 3. Avoid easily guessable information like names or birthdays. 4. Use a password manager to store and generate secure passwords.");
        Console.ResetColor();
        AskForFeedback("Password Safety");
    }

    static void TwoFactorAuthenticationResponse()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintWithTypingAnimation("GRACE AI: Two-factor authentication (2FA) is an extra layer of protection for your accounts. It requires something you know (your password) and something you have (a one-time code sent to your phone or generated by an app like Google Authenticator). Even if someone steals your password, they won't be able to access your account without this second factor. Most online services offer 2FA, including email providers, social media, and financial institutions. It's a simple yet effective way to prevent unauthorized access and enhance your overall security.");
        PrintWithTypingAnimation("GRACE AI: When you enable 2FA, always choose a method that is secure, such as an authentication app or hardware key, rather than relying on SMS, which can be vulnerable to SIM swapping attacks. Enable 2FA on as many of your online accounts as possible.");
        Console.ResetColor();
        AskForFeedback("Two-Factor Authentication");
    }

    static void RansomwareResponse()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        PrintWithTypingAnimation("GRACE AI: Ransomware is a malicious software that encrypts the files on your computer or network, making them inaccessible until you pay a ransom to the attackers. These attacks usually happen when you click on a malicious link in an email, visit a compromised website, or download a harmful attachment. The ransom demands are often paid in cryptocurrency, and paying does not guarantee that you will regain access to your files. To protect against ransomware, regularly back up your data, avoid clicking on suspicious links, and keep your system and antivirus software up-to-date.");
        PrintWithTypingAnimation("GRACE AI: It's essential to have a good backup strategy. Use external drives or cloud services to back up critical data regularly. Avoid paying the ransom, as it encourages the attackers and doesn't guarantee your data will be restored.");
        Console.ResetColor();
        AskForFeedback("Ransomware");
    }

    static void SocialEngineeringResponse()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintWithTypingAnimation("GRACE AI: Social engineering is a manipulative technique used by cybercriminals to deceive individuals into revealing confidential information. This can include tactics such as phishing, pretexting, baiting, and tailgating. Social engineers often exploit human emotions like fear, curiosity, or urgency to manipulate their victims. It's essential to be aware of social engineering tactics and always verify requests for sensitive information before taking any action.");
        PrintWithTypingAnimation("GRACE AI: Always be cautious when receiving unsolicited requests for sensitive information, especially if they seem unusual or come from unexpected sources. If you're ever in doubt, contact the person or organization directly through trusted means.");
        Console.ResetColor();
        AskForFeedback("Social Engineering");
    }

    static void SafeBrowsingResponse()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        PrintWithTypingAnimation("GRACE AI: Safe browsing refers to the practice of using the internet in a secure manner. This includes using updated browsers, avoiding suspicious websites, and protecting your personal data from malicious attacks. Always ensure that the websites you visit are secure, indicated by 'HTTPS' in the URL, and avoid downloading files from untrusted sources. It's also a good idea to use browser extensions that block ads and prevent trackers, which can help safeguard your privacy.");
        PrintWithTypingAnimation("GRACE AI: Additionally, consider using a Virtual Private Network (VPN) to encrypt your internet connection, especially when browsing on public Wi-Fi networks. This adds an extra layer of security and privacy to your online activities.");
        Console.ResetColor();
        AskForFeedback("Safe Browsing");
    }

    static void MalwareResponse()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        PrintWithTypingAnimation("GRACE AI: Malware is software that is designed to harm or exploit any device, service, or network. There are different types of malware, including viruses, worms, Trojans, and spyware. Malware can cause a wide range of problems, from stealing personal information to damaging files or even locking users out of their devices (ransomware). To protect against malware, install and maintain up-to-date antivirus software, avoid downloading files from untrusted sources, and be cautious when clicking on links or opening attachments in emails.");
        PrintWithTypingAnimation("GRACE AI: If you suspect that your device is infected, run a full system scan with antivirus software, and consider using specialized malware removal tools. Keeping your operating system and applications updated is also crucial for preventing malware infections.");
        Console.ResetColor();
        AskForFeedback("Malware");
    }

    static void CyberHygieneResponse()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintWithTypingAnimation("GRACE AI: Cyber hygiene refers to the routine practices and actions that users take to maintain the security of their devices and online accounts. This includes updating software, using strong passwords, enabling two-factor authentication (2FA), and being cautious when sharing personal information online. Regularly cleaning up your digital devices and securing your online accounts are also important aspects of good cyber hygiene.");
        PrintWithTypingAnimation("GRACE AI: Practicing good cyber hygiene helps protect your personal information, prevent data breaches, and reduce the risk of cyberattacks. It's an ongoing effort that should be part of your daily routine to ensure online safety.");
        Console.ResetColor();
        AskForFeedback("Cyber Hygiene");
    }

    static void AskForFeedback(string topic)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintWithTypingAnimation($"GRACE AI: Did this information on {topic} help you?");
        Console.ResetColor();
        Console.Write($"{userName}: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string feedback = Console.ReadLine();
        Console.ResetColor();

        if (feedback.ToLower() == "stop" || feedback.ToLower() == "exit")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("GRACE AI: Goodbye! Stay safe and take care! ");
            Console.ResetColor();
            Environment.Exit(0);
        }

        if (feedback.ToLower().Contains("yes"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithTypingAnimation("GRACE AI: Great! I'm glad it was helpful. ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithTypingAnimation("GRACE AI: Sorry to hear that. Please note that this program is still in development, and we're working hard to improve it. Your feedback is valuable to us, and we'll do our best to provide more accurate and helpful information in the future. ");
            Console.ResetColor();
        }
    }

    static void PrintWithTypingAnimation(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Task.Delay(60).Wait();
        }
        Console.WriteLine();
    }
}
