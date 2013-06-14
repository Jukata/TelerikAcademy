using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0 && value > 2)
            {
                throw new ArgumentOutOfRangeException("Problems solved must be between 0 and 2");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult result;
        if (this.ProblemsSolved == 0)
        {
            result = new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            result = new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else // if (ProblemsSolved == 2)
        {
            result = new ExamResult(6, 2, 6, "Excelent result: everything done.");
        }

        return result;
    }
}
