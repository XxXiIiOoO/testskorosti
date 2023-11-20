using Microsoft.VisualStudio.TestPlatform.ObjectModel;

internal class TypingTest
{
    public object? CorrectCount { get; internal set; }
    public bool? TestInProgress { get; internal set; }

    internal void RunTypingTest()
    {
        throw new NotImplementedException();
    }

    internal void SaveResultsToJson(string userName, List<TestResult> testResults)
    {
        throw new NotImplementedException();
    }

    internal void Timer(int testDurationSeconds)
    {
        throw new NotImplementedException();
    }
}