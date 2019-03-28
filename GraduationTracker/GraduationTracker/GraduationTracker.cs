using System;

namespace GraduationTracker
{
    public class GraduationTracker
    {
        private readonly Repository _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public GraduationTracker(Repository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diploma"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public Tuple<bool, STANDING, int>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var sumOfMarks = 0;
        
            for(int i = 0; i < diploma.Requirements.Length; i++)
            {
                for(int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = _repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            sumOfMarks += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            var averageMark = sumOfMarks / student.Courses.Length;
            //credits added to have ability to create unit test
            return new Tuple<bool, STANDING, int>(StudentHasGraduated(averageMark), StudentStanding(averageMark), credits);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="averageMark"></param>
        /// <returns></returns>
        private bool StudentHasGraduated(int averageMark)
        {
            if (averageMark < 50)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentAverage"></param>
        /// <returns></returns>
        private STANDING StudentStanding(int studentAverage )
        {
            //fix me: not clear what range maps to SumaCumLaude
            if (studentAverage < 50)
                return STANDING.Remedial;
            else if (studentAverage < 80)
                return STANDING.Average;
            else if (studentAverage < 95)
                return STANDING.MagnaCumLaude;
            else
                return STANDING.MagnaCumLaude;
        }
    }
}
