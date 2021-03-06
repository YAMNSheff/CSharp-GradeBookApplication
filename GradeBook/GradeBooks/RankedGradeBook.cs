﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isweighted) : base(name, isweighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.20);
            var grades = Students.OrderByDescending(x => x.AverageGrade).ToList();

            if (averageGrade >= grades[threshold - 1].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade >= grades[(threshold * 2) - 1].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade >= grades[(threshold * 3) - 1].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade >= grades[(threshold * 4) - 1].AverageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
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
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
