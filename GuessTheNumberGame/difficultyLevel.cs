namespace GuessTheNumberGame
{
    internal class DifficultyLevel
    {
        public int MaxRange { get; private set; }
        public int MaxAttempts { get; private set; }

        public DifficultyLevel(int maxRange, int maxAttempts)
        {
            MaxRange = maxRange;
            MaxAttempts = maxAttempts;
        }

        public static DifficultyLevel Easy => new(100, 15);
        public static DifficultyLevel Medium => new(200, 10);
        public static DifficultyLevel Hard => new(500, 7);
    }
}