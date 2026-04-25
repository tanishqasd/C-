using System;
using NUnit.Framework; // Requires NUnit NuGet package

// The class we want to test
public class StringFormatter
{
    public string MakeUppercase(string input) => input?.ToUpper();
}

// The Test Class
[TestFixture] // NUnit attribute marking this as a test class
public class StringFormatterTests
{
    private StringFormatter _formatter;

    [SetUp] // Runs before EVERY test to reset the state
    public void Setup()
    {
        _formatter = new StringFormatter();
    }

    [Test] // NUnit attribute for a single test
    public void MakeUppercase_ValidString_ReturnsUppercase()
    {
        // Act
        string result = _formatter.MakeUppercase("hello");

        // Assert
        Assert.AreEqual("HELLO", result);
    }

    [TestCase("tanishqa", "TANISHQA")] // NUnit's way of doing parameterized tests
    [TestCase("mba", "MBA")]
    public void MakeUppercase_MultipleInputs_ReturnsUppercase(string input, string expected)
    {
        // Act
        string result = _formatter.MakeUppercase(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}