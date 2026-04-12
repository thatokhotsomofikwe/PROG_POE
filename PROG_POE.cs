using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;

namespace PROG_POE
{
    internal class PROG_POE
    {
        private string userName = "User";
        private string botName = "A.J";

        public void Run()
        {
            Console.Title = $"{botName} - Cybersecurity Awareness Bot";
            Console.SetWindowSize(120, 40);
            Console.SetBufferSize(120, 300);
            Console.Clear();

            ShowHeader();
            ShowAsciiLogo();
            PlayGreeting();
            GetUserName();
            StartChat();
        }

        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("I'm here to help you stay safe online.");
            Console.WriteLine("==================================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void ShowAsciiLogo()
        {
            try
            {
                string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "logo.jpg");

                if (!File.Exists(imagePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[logo not found. Skipping logo.]");
                    Console.ResetColor();
                    return;
                }

                Bitmap image = new Bitmap(imagePath);

                int width = 100;
                int height = (image.Height * width) / image.Width/2;

                Bitmap resized = new Bitmap(image, new Size(width, height));

                string asciiChars = "@#S%?*+;:,. ";

                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color pixel = resized.GetPixel(x, y);
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;
                        int index = (gray * (asciiChars.Length - 1)) / 255;
                        Console.Write(asciiChars[index]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Logo could not be displayed.]");
                Console.ResetColor();
            }
        }

        private void PlayGreeting()
        {
            try
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "Assets", "greet.wav");

                if (!File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[greet.wav not found. Continuing without sound.]");
                    Console.ResetColor();
                    return;
                }

                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Audio could not be played. Continuing without sound.]");
                Console.ResetColor();
            }
        }

        private void GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please enter your name: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter a valid name: ");
                Console.ResetColor();
                input = Console.ReadLine();
            }

            userName = input.Trim();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hello, {userName}! I'm {botName}.");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void StartChat()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Type a question or type 'exit/quit/bye' to end the session.");
            Console.ResetColor();
            Console.WriteLine();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{userName}: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintBotResponse("I don't quite understand that. Please enter a valid input.");
                    continue;
                }

                string message = input.Trim().ToLower();

                if (message == "exit" || message == "quit" || message == "bye" || message == "goodbye")
                {
                    PrintBotResponse($"Goodbye, {userName}. Stay safe on the net! I'm always available if you have questions about cybersecurity and online safety.");
                    break;
                }

                PrintBotResponse(GetResponse(message));
            }
        }

        private string GetResponse(string message)
        {
            if (message.Contains("how are you"))
                return $"I'm alright, {userName}. Ready to help you browse the net safely.";

            if (message.Contains("purpose") || message.Contains("what can you do"))
                return "My purpose is to help you learn about cybersecurity and avoid common online threats.";

            if (message.Contains("what can i ask") || message.Contains("what can i ask you about"))
                return "You can ask me about passwords, phishing, safe browsing, suspicious links, and online safety.";

            if (message.Contains("password"))
                return "Strong passwords should contain at least 8 characters and use a mix of upper and lower case letters, numbers, and special characters. Avoid using the same password across multiple accounts.";

            if (message.Contains("phishing"))
                return "Phishing messages often pressure you to act quickly or click suspicious links. Check the sender's details carefully before responding. If the message is from an organisation, compare it with the official contact details.";

            if (message.Contains("browsing") || message.Contains("link") || message.Contains("website"))
                return "Only open trusted links, look for correct website addresses, and avoid downloading files from unknown sources.";

            if (message.Contains("safety") || message.Contains("safe"))
                return "To improve safe browsing, always look for a padlock icon next to the website address.";

            return "I don't quite understand that. Try asking about purpose, passwords, phishing, browsing, or online safety.";
        }

        private void PrintBotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Bot: ");
            Console.ResetColor();

            SimulateTyping(message);
            Console.WriteLine();
            Console.WriteLine();
        }

        private void SimulateTyping(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
        }
    }
}