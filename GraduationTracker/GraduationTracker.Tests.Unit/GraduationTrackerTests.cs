using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        Student[] _students = new[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }
            };

        Diploma _diploma = new Diploma
        {
            Id = 1,
            Credits = 4,
            Requirements = new int[] { 100, 102, 103, 104 }
        };

        bool[] passed = { true, true, true, false };

        int[] expectedCredits = { 4, 4, 0, 0 };

        //test if student has all required courses

        //test if each required course has minimum mark

        //test if standing matches mark average

        [TestMethod]
        public void TestHasGraduated()
        {
            var repository = new Repository();

            var tracker = new GraduationTracker(repository);

            var graduated = new List<Tuple<bool, STANDING>>();

            for(int i=0; i < 4; i++)
            {
                var actualResult = tracker.HasGraduated(_diploma, _students[i]).Item1;
                var expectedResult = passed[i];
                Assert.AreEqual(actualResult, expectedResult);
            }

        }

        [TestMethod]
        public void TestCredits()
        {
            var repository = new Repository();

            var tracker = new GraduationTracker(repository);

            var graduated = new List<Tuple<bool, STANDING>>();

            for (int i = 0; i < 4; i++)
            {
                var actualResult = tracker.HasGraduated(_diploma, _students[i]).Item3;
                var expectedResult = expectedCredits[i];
                Assert.AreEqual(actualResult, expectedResult);
            }
        }

        //[TestMethod]
        //public void TestHasCredits()
        //{
        //    var repository = new Repository();

        //    var tracker = new GraduationTracker(repository);

        //    var graduated = new List<Tuple<bool, STANDING>>();

        //    foreach (var student in _students)
        //    {
        //        graduated.Add(tracker.HasGraduated(_diploma, student));
        //    }


        //    Assert.IsFalse(graduated.Any());

        //}


    }
}
