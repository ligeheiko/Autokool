using System;
using Domain.Common;
using System.Collections.Generic;
using Data;

namespace Domain
{
    public class School : BaseEntity<SchoolData>
    {
        public List<Administrator> Administrators { get; }
        public List<Exam> Exams { get; }
        public List<Course> Courses { get; }
        public List<Student> Students { get; }
        public List<Teacher> Teachers { get; }
        public void AddNewCourse(Course c, Teacher t, Administrator a) { throw new NotImplementedException(); }
        public void AddTeacher(Teacher t, Administrator a) { throw new NotImplementedException(); }
        public void Remove(Teacher t, Administrator a) { throw new NotImplementedException(); }
        public void AddStudent(Student s, Administrator a) { throw new NotImplementedException(); }
        public void RemoveStudent(Student s, Administrator a) { throw new NotImplementedException(); }
        public void UpdateTeacher(Teacher oldT, Teacher newT, Administrator a) { throw new NotImplementedException(); }
        public void UpdateCourse(Course oldC, Course newC, Administrator a) { throw new NotImplementedException(); }


    }
}
