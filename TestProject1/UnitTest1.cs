using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

[TestFixture]
public class TypingTestTests
{
    [Test]
    public void RunTypingTest_CorrectInput_ShouldIncrementCorrectCount()
    {
        TypingTest typingTest = new TypingTest();
        string input = "пыццы";

        using (StringReader stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);

            typingTest.RunTypingTest();

            Assert.AreEqual(1, typingTest.CorrectCount);
        }
    }

    [Test]
    public void RunTypingTest_IncorrectInput_ShouldNotIncrementCorrectCount()
    {
        TypingTest typingTest = new TypingTest();
        string input = "неверно";

        using (StringReader stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);

            typingTest.RunTypingTest();

            Assert.AreEqual(0, typingTest.CorrectCount);
        }
    }

    [Test]
    public void Timer_TypingTestInProgress_ShouldSetTestInProgressToFalseAfterTimeout()
    {
        TypingTest typingTest = new TypingTest();
        int testDurationSeconds = 1; 

        typingTest.Timer(testDurationSeconds);

        Assert.IsFalse(typingTest.TestInProgress);
    }

    [Test]
    public void SaveResultsToJson_ValidUserName_ShouldSaveResultsToFile()
    {
        TypingTest typingTest = new TypingTest();
        string userName = "TestUser";

        typingTest.CorrectCount = 5; 

        typingTest.SaveResultsToJson(userName, new List<TestResult>());

        string json = File.ReadAllText("test_results.json");
        List<TestResult> loadedResults = JsonConvert.DeserializeObject<List<TestResult>>(json);

        // Assert the loaded results
        Assert.AreEqual(1, loadedResults.Count);
        Assert.AreEqual(userName, loadedResults[0].UserName);
        Assert.AreEqual(5, loadedResults[0].CorrectCount);
    }

    [Test]
    public void SaveResultsToJson_InvalidUserName_ShouldThrowException()
    {
        TypingTest typingTest = new TypingTest();
        string userName = "Invalid/UserName"; 

        Assert.Throws<ArgumentException>(() => typingTest.SaveResultsToJson(userName, new List<TestResult>()));
    }
}
