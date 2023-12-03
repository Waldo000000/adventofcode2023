namespace AdventOfCode.Day1;

public static class Day1Puzzle
{
    public static int GetSumOfCalibrationValues(string[] calibrationValues)
    {
        return calibrationValues
            .Select(GetCalibrationValue)
            .ToArray()
            .Sum();
    }

    private static int GetCalibrationValue(string calibrationValue)
    {
        var firstDigit = calibrationValue.First(char.IsDigit);
        var lastDigit = calibrationValue.Last(char.IsDigit);
        return int.Parse($"{firstDigit}{lastDigit}");
    }
}