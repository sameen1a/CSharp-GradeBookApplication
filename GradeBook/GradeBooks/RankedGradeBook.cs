/*
Provide the appropriate grades based on where input grade compares to other students. 
(One way to solve this is to figure out how many students make up 20%, 
then loop through all the grades and check how many were more than the input average, 
every N students where N is that 20% value drop a letter grade.)
 */
using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        override public char GetLetterGrade(double averageGrade)
        {
            int studentCount = 0;

            foreach (var student in Students){
                studentCount++;
            }
            if (studentCount < 5)
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            double [] studentGrades = new double[studentCount];
            int i = 0;

            foreach (var student in Students)
            {
                studentGrades[i] = student.AverageGrade;
                i++;
            }
            Array.Sort(studentGrades);
            Array.Reverse(studentGrades);

            int twentyPercent = Convert.ToInt32(studentCount * .2);
            int fortyPercent = twentyPercent + twentyPercent;
            int sixtyPercent = fortyPercent + twentyPercent;
            int eightyPercent = sixtyPercent + twentyPercent;

            if (averageGrade >= studentGrades[twentyPercent])
                return 'A';
            else if (averageGrade >= studentGrades[fortyPercent])
                return 'B';
            else if (averageGrade >= studentGrades[sixtyPercent])
                return 'C';
            else if (averageGrade >= studentGrades[eightyPercent])
                return 'D';
            else
                return 'F';

            // if (averageGrade >= studentGrades[twentyPercent])
            //     return 'A';
            // else if (averageGrade < studentGrades[twentyPercent] & averageGrade >= studentGrades[fortyPercent])
            //     return 'B';
            // else if (averageGrade < studentGrades[fortyPercent] && averageGrade >= studentGrades[sixtyPercent])
            //     return 'C';
            // else if (averageGrade < studentGrades[sixtyPercent] && averageGrade >= studentGrades[eightyPercent])
            //     return 'D';
            // else
            //     return 'F';    
        }
        
    }
}