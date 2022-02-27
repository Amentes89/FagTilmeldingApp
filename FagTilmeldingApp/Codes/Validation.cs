using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes
{
    internal class Validation
    {
        public static int StudentId { get; set; }
        public static int CourseId { get; set; }

        private static List<Student>? _students;

        private static List<Course>? _courses;

        #region Public methods

        public static string? ValidateStudent(string studentId, List<Student> students)
        {
            string? errorMessage = null;
            int value;
            bool isInt = int.TryParse(studentId, out value);

            if (!isInt)
                errorMessage = "Det angivet elev id er af forkert format!";
            else
            {
                StudentId = value;
                _students = students;
                errorMessage = ValidateStudentExist(value);
            }

            return errorMessage;
        }

        public static string? ValidateCourse(string courseId, List<Course> courses)
        {
            string? errorMessage = null;
            int value;
            bool isInt = int.TryParse(courseId, out value);

            if (!isInt)
                errorMessage = "Det angivet fag id er af forkert format!";
            else
            {
                CourseId = value;
                _courses = courses;
                errorMessage = ValidateCourseExist(value);
            }

            return errorMessage;
        }

        public static string? ValidateEnrollment(List<Enrollment> enrollments)
        {
            string? errorMessage = null;

            var matchedObject = enrollments.FirstOrDefault(a => a.StudentId == StudentId && a.CourseId == CourseId);
            if (matchedObject != null)
            {
                Student? matchedStudent = _students.FirstOrDefault(a => a.Id == StudentId);
                Course? matchedCourse = _courses.FirstOrDefault(a => a.Id == CourseId);
                errorMessage = $"Elev {matchedStudent.FirstName} {matchedStudent.LastName} er alleredet tilmeld fag {matchedCourse.CourseName} ";
            }

            return errorMessage;
        }

        #endregion

        #region Private methods

        private static string? ValidateStudentExist(int studentId)
        {
            string? errorMessage = null;
            Student? matchedStudent = _students.FirstOrDefault(a => a.Id == studentId);
            if (matchedStudent == null)
                errorMessage = $"Det angivet elev med id {studentId} findes ikke!";

            return errorMessage;
        }

        private static string? ValidateCourseExist(int courseId)
        {
            string? errorMessage = null;
            Course? matchedCourse = _courses.FirstOrDefault(a => a.Id == courseId);
            if (matchedCourse == null)
                errorMessage = $"Det angivet fag med id {courseId} findes ikke!";

            return errorMessage;
        }

        #endregion
    }
}