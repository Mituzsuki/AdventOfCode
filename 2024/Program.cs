﻿using _2024;
using _2024.DayFive;
using _2024.DaySix;
using _2024.Utilities;
using _2024.WeekFour;
using _2024.WeekOne;
using _2024.WeekThree;
using _2024.WeekTwo;

List<(ISolution solution, string week)> solutions = new List<(ISolution solutions, string week)>()
{
    //( new DayOneSolution(), "One pt. 1" ),
    //( new DayOnePartTwoSolution(), "One pt. 2" ),
    //(new WeekTwoSolution(), "Two pt. 1" ),
    //(new WeekThreeSolution(), "Three, pt. 1"),
    //(new WeekThreePartTwoSolution(), "Three pt. 2"),
    //(new DayFourSolution(), "Four pt. 1"),
    //(new DayFourPartTwoSolution(), "Four pt. 2"),
    //(new DayFiveSolution(), "Five pt. 1"),
    //(new DayFivePartTwoSolution(), "Five pt. 2"),
    (new DaySixSolution(), "Six pt. 1"),
    (new DaySixPartTwoSolution(), "Six pt. 2"),
};

foreach (var solution in solutions)
{
    ConsoleUtilities.PrintSolution(() => solution.solution.GetSolution(), solution.week);
}