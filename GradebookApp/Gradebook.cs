using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    public class GradebookApp
    {
        static void Main(string[] args)
        {
            Gradebook gradebook = new Gradebook();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nGradebook Menu");
                Console.WriteLine("1. Add grade");
                Console.WriteLine("2. View summary");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter grade (0–100): ");
                        string input = Console.ReadLine();

                        if (double.TryParse(input, out double grade))
                        {
                            try
                            {
                                gradebook.AddGrade(grade);
                                Console.WriteLine("Grade added.");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nGrade Summary");
                        Console.WriteLine(
                            $"Count: {gradebook.GetCount()}\n" +
                            $"Average: {gradebook.GetAverage():F2}\n" +
                            $"Highest: {gradebook.GetHighest()}\n" +
                            $"Lowest: {gradebook.GetLowest()}"
                        );
                        break;

                    case "3":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }

    public class Gradebook
    {
        private List<double> grades = new List<double>();

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");
            grades.Add(grade);
        }

        public void AddGrade(IEnumerable<double> grades)
        {
            foreach (var grade in grades)
                AddGrade(grade);
        }

        public double GetAverage() => grades.Count == 0 ? 0 : grades.Average();
        public double GetHighest() => grades.Count == 0 ? 0 : grades.Max();
        public double GetLowest() => grades.Count == 0 ? 0 : grades.Min();
        public int GetCount() => grades.Count;
        public void Clear() => grades.Clear();
    }
}