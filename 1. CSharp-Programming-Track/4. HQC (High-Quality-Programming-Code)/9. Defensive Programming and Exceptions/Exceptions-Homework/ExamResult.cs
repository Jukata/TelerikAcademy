using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        // grade initialize after minGrade and maxGrade to ensure correct data
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.minGrade || value > this.maxGrade)
            {
                string msg = string.Format("Grade must be between {0} and {1}", this.minGrade, this.maxGrade);
                throw new ArgumentOutOfRangeException(msg);
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Min grade can't be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.minGrade)
            {
                throw new ArgumentOutOfRangeException("Max grade must be greater than min grade.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Comment can't be null or empty.");
            }

            this.comments = value;
        }
    }

    public double ExamPercentage()
    {
        double percentage = (double)(this.Grade - this.MinGrade) / (this.MaxGrade - this.MinGrade);
        return percentage;
    }
}
