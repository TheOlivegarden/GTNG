namespace GuessTheNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int difficultyLevel = 2;
            bool playAgain = true;

            while (playAgain)
            {   
                Console.WriteLine("Welcome to Guess the Number!");
                Console.WriteLine($"Difficulty: {GetDifficultyName(difficultyLevel)}");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Change difficulty");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                bool validInput = int.TryParse(Console.ReadLine(), out int choice);

                while (!validInput || (choice < 0 || choice > 2))
                {
                    Console.WriteLine("Invalid input. Please enter 0, 1, or 2 for your choice.");
                    Console.Write("Enter your choice: ");
                    validInput = int.TryParse(Console.ReadLine(), out choice);
                }

                switch (choice)
                {
                    case 0:
                        playAgain = false;
                        break;
                    case 1:
                        PlayGame(difficultyLevel);
                        break;
                    case 2:
                        difficultyLevel = SelectDifficulty();
                        break;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

        static void PlayGame(int difficulty)
        {
            Console.Clear();

            int maxRange;
            int maxAttempts;

            switch (difficulty)
            {
                case 1:
                    maxRange = 100;
                    maxAttempts = 15;
                    break;
                case 2:
                    maxRange = 200;
                    maxAttempts = 10;
                    break;
                case 3:
                    maxRange = 500;
                    maxAttempts = 7;
                    break;
                default:
                    Console.WriteLine("Invalid difficulty level. Defaulting to Medium.");
                    maxRange = 200;
                    maxAttempts = 10;
                    break;
            }

            Random random = new();
            int SNum = random.Next(1, maxRange + 1);

            int attempts = 0;
            int guess = 0;

            Console.WriteLine($"Try to guess the secret number between 1 and {maxRange}.");
            Console.WriteLine($"You have {maxAttempts} attempts.");

            while (guess != SNum && attempts < maxAttempts)
            {
                Console.Write("Enter your guess: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out guess) || guess < 1 || guess > maxRange)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid number between 1 and {maxRange}.");
                    continue;
                }

                attempts++;

                if (guess < SNum)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > SNum)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the number {SNum} in {attempts} attempts.");
                }
            }

            if (guess != SNum)
            {
                Console.WriteLine($"Sorry, you've run out of attempts. The secret number was {SNum}.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static int SelectDifficulty()
        {
            Console.WriteLine("Select a difficulty level:");
            Console.WriteLine("1. Easy (1-100)");
            Console.WriteLine("2. Medium (1-200)");
            Console.WriteLine("3. Hard (1-500)");
            Console.Write("Enter the level number (1/2/3): ");

            bool validInput = int.TryParse(Console.ReadLine(), out int choice);

            while (!validInput || (choice < 1 || choice > 3))
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3 for the difficulty level.");
                Console.Write("Enter the level number (1/2/3): ");
                validInput = int.TryParse(Console.ReadLine(), out choice);
            }

            return choice;
        }

        static string GetDifficultyName(int difficulty)
        {
            return difficulty switch
            {
                1 => "Easy",
                2 => "Medium",
                3 => "Hard",
                _ => "Unknown",
            };
        }
    }
}
