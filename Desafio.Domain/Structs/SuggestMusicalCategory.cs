namespace Desafio.Domain.Structs
{
    public struct SuggestMusicalCategory
    {
        public static string CategoryAccordingToTemperature(decimal value)
        {
            if (value > 30M)
                return "party";
            else if (value >= 15M)
                return "pop";
            else if (value >= 10M)
                return "rock";

            return "classical";
        }
    }
}
