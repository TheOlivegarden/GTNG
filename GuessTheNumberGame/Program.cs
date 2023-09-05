namespace GuessTheNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DifficultyLevel difficulty = DifficultyLevel.Medium;
            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("Welcome to Guess the Number!");
                Console.WriteLine($"Difficulty: {GetDifficultyName(difficulty)}");
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
                        PlayGame(difficulty);
                        break;
                    case 2:
                        difficulty = SelectDifficulty();
                        break;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

        static void PlayGame(DifficultyLevel difficulty)
        {
            Console.Clear();

            int maxRange = difficulty.MaxRange;
            int maxAttempts = difficulty.MaxAttempts;

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

        static DifficultyLevel SelectDifficulty()
        {
            Console.WriteLine("Select a difficulty level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Enter the level number (1/2/3): ");

            bool validInput = int.TryParse(Console.ReadLine(), out int choice);

            while (!validInput || (choice < 1 || choice > 3))
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3 for the difficulty level.");
                Console.Write("Enter the level number (1/2/3): ");
                validInput = int.TryParse(Console.ReadLine(), out choice);
            }

            return choice switch
            {
                1 => DifficultyLevel.Easy,
                2 => DifficultyLevel.Medium,
                3 => DifficultyLevel.Hard,
                _ => DifficultyLevel.Medium,
            };
        }

        static string GetDifficultyName(DifficultyLevel difficulty)
        {
            if (difficulty.MaxRange == 100 && difficulty.MaxAttempts == 15)
                return "Easy";
            else if (difficulty.MaxRange == 200 && difficulty.MaxAttempts == 10)
                return "Medium";
            else if (difficulty.MaxRange == 500 && difficulty.MaxAttempts == 7)
                return "Hard";
            else
                return "Unknown";
        }
    }
}
