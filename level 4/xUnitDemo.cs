using System;
using Xunit; // Requires xUnit NuGet package

// The class we want to test
public class Calculator
{
    public int Add(int a, int b) => a + b;
}

// The Test Class
public class CalculatorTests
{
    [Fact] // Defines a test without parameters
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(5, 3);

        // Assert
        Assert.Equal(8, result);
    }

    [Theory] // Defines a test that takes multiple sets of data
    [InlineData(2, 3, 5)]
    [InlineData(-2, -3, -5)]
    [InlineData(0, 0, 0)]
    public void Add_MultipleScenarios_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}

// Note: To run this in an actual project, you use the 'dotnet test' command 
// in the terminal, or the Test Explorer in Visual Studio.