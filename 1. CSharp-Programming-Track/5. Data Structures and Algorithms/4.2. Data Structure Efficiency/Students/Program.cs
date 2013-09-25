using System;
using System.IO;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
        OrderedMultiDictionary<string, Student> students = new OrderedMultiDictionary<string, Student>(true);

        using (StreamReader reader = new StreamReader(@"../../Students.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] arguments = ParseInput(line);
                if (arguments.Length == 3)
                {
                    string firstName = arguments[0].Trim();
                    string lastName = arguments[1].Trim();
                    string course = arguments[2].Trim();

                    students.Add(course, new Student(firstName, lastName));
                }

                line = reader.ReadLine();
            }
        }

        foreach (var course in students)
        {
            Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
        }
    }

    private static string[] ParseInput(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Input can't be null.");
        }

        string[] result = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
        return result;
    }
}
