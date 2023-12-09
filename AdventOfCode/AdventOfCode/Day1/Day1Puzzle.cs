namespace AdventOfCode.Day1;

public static class Day1Puzzle
{
    private static readonly Dictionary<int, string> SpelledDigits = new()
    {
        {1, "one"},
        {2, "two"},
        {3, "three"},
        {4, "four"},
        {5, "five"},
        {6, "six"},
        {7, "seven"},
        {8, "eight"},
        {9, "nine"}
    };

    public static int GetSumOfCalibrationValues(string[] calibrationValues, Func<string, int> getCalibrationValueStrategy)
    {
        return calibrationValues
            .Select(getCalibrationValueStrategy)
            .ToArray()
            .Sum();
    }
    
    public static int GetCharCalibrationValue(string calibrationValue)
    {
        var firstDigit = calibrationValue.First(char.IsDigit);
        var lastDigit = calibrationValue.Last(char.IsDigit);
        return int.Parse($"{firstDigit}{lastDigit}");
    }

    public static int GetCharOrSpelledCalibrationValue(string calibrationValue)
    {
        var indexes = Enumerable.Range(0, calibrationValue.Length).ToList();
        var parsedDigits = indexes
            .Select((c, i) => TryParseCharDigitAt(i, calibrationValue) ?? TryParseSpelledDigitEndingAt(i, calibrationValue))
            .ToList();
        var firstDigit = parsedDigits.First(number => number != null);
        var lastDigit = parsedDigits.Last(number => number != null);
        return int.Parse($"{firstDigit}{lastDigit}");
    }

    private static int? TryParseCharDigitAt(int index, string calibrationValue)
    {
        return char.IsDigit(calibrationValue[index]) ? int.Parse(calibrationValue[index].ToString()) : null;
    }

    private static int? TryParseSpelledDigitEndingAt(int index, string calibrationValue)
    {
        return SpelledDigits
            .Where(kv => calibrationValue[index..].StartsWith(kv.Value))
            .Select(kv => kv.Key)
            .Cast<int?>()
            .FirstOrDefault();
    }
}