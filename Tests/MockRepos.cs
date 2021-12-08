using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using System;

namespace Autokool.Tests
{
    internal static class MockRepos
    {
        private static TRepo createMockRepo<TRepo, TObj, TData>()
         where TRepo : IRepo<TObj>, new()
         where TData : BaseData => new TRepo();
        private static TRepo createMockRepo<TRepo, TObj, TData>(string id, Func<TData, TObj> toObject, out TData data)
         where TRepo : IRepo<TObj>, new()
         where TData : BaseData
        {
            data = null;
            var count = GetRandom.UInt8(10, 20);
            var idx = GetRandom.UInt8(0, count);
            var repo = new TRepo();
            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.ObjectOf<TData>();
                if (idx == i)
                {
                    d.ID = id;
                    data = d;
                }
                repo.Add(toObject(d)).GetAwaiter();
            }
            return repo;
        }
        private class MockCourseTypeRepo : RepoMock<CourseType>, ICourseTypeRepo { }
        private class MockCourseRepo : RepoMock<Course>, ICourseRepo { }
        private class MockExamTypeRepo : RepoMock<ExamType>, IExamTypeRepo { }
        private class MockExamRepo : RepoMock<Exam>, IExamRepo { }
        private class MockStudentRepo : RepoMock<Student>, IStudentRepo { }
        private class MockRoleTypeRepo : RepoMock<RoleType>, IRoleTypeRepo { }
        private class MockTeacherRepo : RepoMock<Teacher>, ITeacherRepo { }

        public static ICourseRepo CourseRepos(string id, out CourseData data)
            => createMockRepo<MockCourseRepo, Course, CourseData>(
                id, d => new Course(d), out data);
        public static ICourseRepo CourseRepos()
           => createMockRepo<MockCourseRepo, Course, CourseData>();
        public static IExamRepo ExamRepos()
           => createMockRepo<MockExamRepo, Exam, ExamData>();
        public static ITeacherRepo TeacherRepos()
           => createMockRepo<MockTeacherRepo, Teacher, TeacherData>();
        public static ICourseTypeRepo CourseTypeRepos(string id, out CourseTypeData data)
       => createMockRepo<MockCourseTypeRepo, CourseType, CourseTypeData>(
               id, d => new CourseType(d), out data);
        public static IExamTypeRepo ExamTypeRepos(string id, out ExamTypeData data)
      => createMockRepo<MockExamTypeRepo, ExamType, ExamTypeData>(
              id, d => new ExamType(d), out data);
        public static IStudentRepo StudentRepos(string id, out StudentData data)
     => createMockRepo<MockStudentRepo, Student, StudentData>(
             id, d => new Student(d), out data);
        public static IRoleTypeRepo RoleTypeRepos(string id, out RoleTypeData data)
     => createMockRepo<MockRoleTypeRepo, RoleType, RoleTypeData>(
             id, d => new RoleType(d), out data);
        public static ITeacherRepo TeacherRepos(string id, out TeacherData data)
     => createMockRepo<MockTeacherRepo, Teacher, TeacherData>(
             id, d => new Teacher(d), out data);
    }
}