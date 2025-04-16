using System;
using System.Media;
using System.Threading;


class ChatBot
{
    public string UserName { get; set; }

    // Display the ASCII art Logo of a virus
    public void ShowVirusAscii()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        string bugsArt = @"  
██████╗ ██╗   ██╗ ██████╗ ███████╗  
██╔══██╗██║   ██║██╔════╝ ██╔════╝  
██████╔╝██║   ██║██║  ███╗███████╗  
██╔══██╗██║   ██║██║   ██║╚════██║  
██████╔╝╚██████╔╝╚██████╔╝███████║  
╚═════╝  ╚═════╝  ╚═════╝ ╚══════╝  
";

        TypeText(bugsArt, 2);   
        Console.ResetColor();
    }

    // Simulated typing effect
    protected void TypeText(string message, int delay = 30)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    // The audio file path
    public void PlayAudioGreeting()
    {
        string filePath = @"C:\Users\kntok\OneDrive\Desktop\PROG PART 1\PRog PART 1\audio\Welcome.wav"; 
        try
        {
            SoundPlayer player = new SoundPlayer(filePath);
            player.PlaySync(); // Play before continuing
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to play audio: " + ex.Message);
            Console.ResetColor();
        }
    }

    // ASCII banner
    public void ShowBanner()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        string banner = @"
╔════════════════════════════════════════════════════════════╗
║         CYBERSECURITY AWARENESS BOT LAUNCHING...           ║
╚════════════════════════════════════════════════════════════╝";
        TypeText(banner, 5);
        Console.ResetColor();
    }

    // Ask user their name and greet them
    public virtual void GreetUser()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nWhat is your name? ");
        Console.ResetColor();
        UserName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(UserName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Name cannot be empty. Please enter your name: ");
            Console.ResetColor();
            UserName = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n" + new string('-', 50));
        TypeText($" Welcome {UserName}! I'm your Cybersecurity Awareness Bot.", 50);
        Console.WriteLine(new string('-', 50) + "\n");
        Console.ResetColor();
    }

    // Main method to handle questions and info
    public virtual void HandleQuestion(string question)
    {
        question = question.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(question))
        {
            TypeText(" You entered nothing. Please ask a question.");
            return;
        }

        switch (question)
        {
            case "how are you?":
                TypeText(" I am good, thanks for asking! What can I assist you with today?");
                break;

            case "what is your purpose?":
                ShowCyberEducationMenu();
                break;

            case "what can i ask you about?":
                ShowAskMenu();
                break;

            case "good food to buy":
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║              GOOD FOOD TO BUY                      ║
╠════════════════════════════════════════════════════╣
║ I like pizza pies! They're cheap and filling.      ║
╚════════════════════════════════════════════════════╝");
                Console.ResetColor();
                break;

            case "movie suggestion":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║                MOVIE SUGGESTION                    ║
╠════════════════════════════════════════════════════╣
║ • The Godfather                                    ║
║ • The Wolf of Wall Street                          ║
╚════════════════════════════════════════════════════╝");
                Console.ResetColor();
                break;


            default:
                TypeText(" I didn’t quite understand that. Could you rephrase?");
                break;
        }
    }

    // Shows cybersecurity topic info and loops until user exits
    protected void ShowCyberEducationMenu()
    {
        string topic = "";
        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("My purpose is to educate you on Cybersecurity topics that can help you in the future");
            Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║        Learn more about Cybersecurity Topics       ║
╠════════════════════════════════════════════════════╣
║ - password safety                                  ║
║ - phishing                                         ║
║ - safe browsing                                    ║
║ - exit                                             ║
╚════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nEnter a topic: ");
            topic = Console.ReadLine()?.Trim().ToLower();

            switch (topic)
            {
                case "password safety":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║                PASSWORD SAFETY                     ║
╠════════════════════════════════════════════════════╣
║ • Prevents unauthorized access to your accounts.   ║
║ • Keeps your personal data safe.                   ║
╚════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                    break;

                case "phishing":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║                PHISHING ATTACKS                    ║
╠════════════════════════════════════════════════════╣
║ • Tricks users into giving away info.              ║
║ • Can lead to identity theft or data loss.         ║
╚════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                    break;

                case "safe browsing":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(@"
╔════════════════════════════════════════════════════╗
║                  SAFE BROWSING                     ║
╠════════════════════════════════════════════════════╣
║ • Avoid visiting harmful websites.                 ║
║ • Reduces risk of malware and viruses.             ║
╚════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                    break;

                case "exit":
                    TypeText(" Returning to main chat...\n");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Sorry, topic not recognized. Try again.");
                    Console.ResetColor();
                    break;
            }

        } while (topic != "exit");
    }

    // Shows options the bot can answer about and loops until exit
    protected void ShowAskMenu()
    {
        string ask = "";
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
╔════════════════════════════════════════════╗
║        CYBERSECURITY CHAT OPTIONS          ║
╠════════════════════════════════════════════╣
║ You can ask about:                         ║
║ - good food to buy                         ║
║ - movie suggestion                         ║
║ - exit                                     ║
╚════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nEnter a question: ");
            ask = Console.ReadLine()?.Trim().ToLower();

            switch (ask)
            {
                case "good food to buy":
                    HandleQuestion("good food to buy");
                    break;
                case "movie suggestion":
                    HandleQuestion("movie suggestion");
                    break;
                case "exit":
                    TypeText(" Back to main chat...\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Option not recognized. Try again.");
                    Console.ResetColor();
                    break;
            }

        } while (ask != "exit");
    }
}

// Inherited bot class with chat loop
class CyberSecurityBot : ChatBot
{
    public void StartChat()
    {
        Console.Clear();
        PlayAudioGreeting();
        ShowVirusAscii();
        ShowBanner();
        GreetUser();

        string input = "";
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"\n{UserName}, ask me something or type 'bye' to quit: ");
            Console.ResetColor();
            input = Console.ReadLine()?.Trim().ToLower();

            if (input != "bye")
                HandleQuestion(input);

        } while (input != "bye");

        Console.ForegroundColor = ConsoleColor.Green;
        TypeText("\n Goodbye! Stay safe online!");
        Console.ResetColor();
    }
}

// Entry point
class Program
{
    static void Main(string[] args)
    {
        CyberSecurityBot bot = new CyberSecurityBot();
        bot.StartChat();
    }
}
