using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullSequence()
    {
        LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(null);
    }

    [TestMethod]
    public void EmptySequence()
    {
        List<int> numbers = new List<int>();

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(0, longestSequenceOfEqualNumbers.Count);
    }

    [TestMethod]
    public void SequenceWithOneInteger()
    {
        List<int> numbers = new List<int>() { 157 };

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(1, longestSequenceOfEqualNumbers.Count);
        Assert.AreEqual(157, longestSequenceOfEqualNumbers[0]);
    }

    [TestMethod]
    public void LongestSequenceInTheBegining()
    {
        List<int> numbers = new List<int>() { 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 };

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(4, longestSequenceOfEqualNumbers.Count);
        Assert.AreEqual(1, longestSequenceOfEqualNumbers[0]);
        Assert.AreEqual(1, longestSequenceOfEqualNumbers[1]);
        Assert.AreEqual(1, longestSequenceOfEqualNumbers[2]);
        Assert.AreEqual(1, longestSequenceOfEqualNumbers[3]);
    }

    [TestMethod]
    public void LongestSequenceInTheMiddle()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 4, 4, 1, 2, 3, 4, 4, 1, 1, 4 };

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(3, longestSequenceOfEqualNumbers.Count);
        Assert.AreEqual(4, longestSequenceOfEqualNumbers[0]);
        Assert.AreEqual(4, longestSequenceOfEqualNumbers[1]);
        Assert.AreEqual(4, longestSequenceOfEqualNumbers[2]);
    }

    [TestMethod]
    public void TwoLongestSequences() //must return first
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 5, 5, 5, 6, 6, 6, 3, 2, 1 };

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(3, longestSequenceOfEqualNumbers.Count);
        Assert.AreEqual(5, longestSequenceOfEqualNumbers[0]);
        Assert.AreEqual(5, longestSequenceOfEqualNumbers[1]);
        Assert.AreEqual(5, longestSequenceOfEqualNumbers[2]);
    }

    [TestMethod]
    public void LongestSequenceInTheEnd()
    {
        List<int> numbers = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 3, 3, 3, 3, 3 };

        var longestSequenceOfEqualNumbers =
            LongestSubsequenceOfEqualNumbers.GetLongestSubsequenceOfEqualNumbers(numbers);

        Assert.AreEqual(5, longestSequenceOfEqualNumbers.Count);
        Assert.AreEqual(3, longestSequenceOfEqualNumbers[0]);
        Assert.AreEqual(3, longestSequenceOfEqualNumbers[1]);
        Assert.AreEqual(3, longestSequenceOfEqualNumbers[2]);
        Assert.AreEqual(3, longestSequenceOfEqualNumbers[3]);
        Assert.AreEqual(3, longestSequenceOfEqualNumbers[4]);
    }
}

