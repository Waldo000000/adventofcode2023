using AdventOfCode;
using AdventOfCode.Day1;
using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCodeTests.Day1;

public class Day1Tests
{
    [Test]
    public void GetSumOfCalibrationValue_SampleData_ReturnsExpectedResult()
    {
        var frequencyChanges = ReadCalibrationDocument("Day1\\Part1.sample.txt");
        var sumOfCalibrationValues = Day1Puzzle.GetSumOfCalibrationValues(frequencyChanges);
        sumOfCalibrationValues.Should().Be(142);
    }
    
    [Test]
    public void GetSumOfCalibrationValue_RealData_ReturnsExpectedResult()
    {
        var frequencyChanges = ReadCalibrationDocument("Day1\\Part1.real.txt");
        var sumOfCalibrationValues = Day1Puzzle.GetSumOfCalibrationValues(frequencyChanges);
        sumOfCalibrationValues.Should().Be(53080);
    }

    private string[] ReadCalibrationDocument(string inputFilePath)
    {
        return File.ReadLines(inputFilePath).ToArray();
    }
}