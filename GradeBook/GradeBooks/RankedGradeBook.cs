using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            Students = new List<Student>();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Number of students must be 5 or greater");
            }
            int fifth = Students.Count / 5;
            int higherScoreCount = 0;
            for(int i = 0; i < Students.Count; i++)
            {
                if(averageGrade <= Students[i].AverageGrade)
                {
                    higherScoreCount++;
                }
            }
            if (higherScoreCount <= fifth)
                return 'A';
            else if (higherScoreCount > fifth && higherScoreCount <= 2*fifth)
                return 'B';
            else if (higherScoreCount > 2*fifth && higherScoreCount <= 3*fifth)
                return 'C';
            else if (higherScoreCount > 3*fifth && higherScoreCount <= 4*fifth)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

    }
}
