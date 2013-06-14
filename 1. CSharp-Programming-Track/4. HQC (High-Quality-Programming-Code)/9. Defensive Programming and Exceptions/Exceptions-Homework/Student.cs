using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("First name can't be null, whitespace or null.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Last name can't be null, whitespace or null.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return new ReadOnlyCollection<Exam>(this.exams);
        }

        private set
        {
            this.exams = value ?? new List<Exam>();
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException("Student hasn't exams.");
        }

        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        List<double> resultsPercentage = new List<double>();

        IList<ExamResult> examResults = this.CheckExams();
        foreach (ExamResult examResult in examResults)
        {
            double currentPercentage = examResult.ExamPercentage();
            resultsPercentage.Add(currentPercentage);
        }

        return resultsPercentage.Average();
    }
}
