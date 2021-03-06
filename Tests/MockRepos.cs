using Autokool.Aids;
using Autokool.Data.Common;
using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Domain.DrivingSchool.Repos;
using Autokool.Tests.PagesTests.Autokool.Base;
using System;
using System.Threading.Tasks;

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
        private class MockCourseRepo : RepoMock<Course>, ICourseRepo 
        {
            public async Task Added(Course c)
            {
                var d = c?.Data;
                if (d == null) return;
                d.ValidFrom = DateTime.Now;
                await Update(c);
            }
        }
        private class MockExamTypeRepo : RepoMock<ExamType>, IExamTypeRepo { }
        private class MockExamRepo : RepoMock<Exam>, IExamRepo
        {
            public async Task Added(Exam e)
            {
                var d = e?.Data;
                if (d == null) return;
                d.ValidFrom = DateTime.Now;
                await Update(e);
            }
        }
        private class MockTeacherRepo : RepoMock<Teacher>, ITeacherRepo
        {
            public async Task CreateValidFrom(Teacher t)
            {
                var d = t?.Data;
                if (d == null) return;
                d.ValidFrom = DateTime.Now;
                await Update(t);
            }
        }
        private class MockRegisterCourseRepo : RepoMock<RegisterCourse>, IRegisterCourseRepo
        {
            public Task RegisterDataToUser(RegisterCourseData rData, ApplicationUser currentUser, IRegisterCourseRepo r, string id)
            {
                throw new NotImplementedException();
            }
        }
        private class MockRegisterExamRepo : RepoMock<RegisterExam>, IRegisterExamRepo
        {
            public Task RegisterDataToUser(RegisterExamData rData, ApplicationUser currentUser, IRegisterExamRepo r, string id)
            {
                throw new NotImplementedException();
            }
        }
        private class MockRegisterDrivingPracticeRepo : RepoMock<RegisterDrivingPractice>, IRegisterDrivingPracticeRepo
        {
            public Task RegisterDataToUser(RegisterDrivingPracticeData rData, ApplicationUser currentUser, IRegisterDrivingPracticeRepo r, string id)
            {
                throw new NotImplementedException();
            }
        }
        private class MockDrivingPracticeRepo : RepoMock<DrivingPractice>, IDrivingPracticeRepo { }
        private class MockUserRolesRepo : RepoMock<UserRoles>, IUserRolesRepo { }
        public static IUserRolesRepo UserRolesRepos()
           => createMockRepo<MockUserRolesRepo, UserRoles, UserRolesData>();
        public static ICourseRepo CourseRepos(string id, out CourseData data)
            => createMockRepo<MockCourseRepo, Course, CourseData>(
                id, d => new Course(d), out data);
        public static ICourseRepo CourseRepos()
           => createMockRepo<MockCourseRepo, Course, CourseData>();
        public static IRegisterCourseRepo RegisterCourseRepos()
           => createMockRepo<MockRegisterCourseRepo, RegisterCourse, RegisterCourseData>();
        public static IExamRepo ExamRepos()
           => createMockRepo<MockExamRepo, Exam, ExamData>();
        public static IRegisterExamRepo RegisterExamRepos()
           => createMockRepo<MockRegisterExamRepo, RegisterExam, RegisterExamData>();
        public static IExamTypeRepo ExamTypeRepos()
          => createMockRepo<MockExamTypeRepo, ExamType, ExamTypeData>();
        public static ITeacherRepo TeacherRepos()
           => createMockRepo<MockTeacherRepo, Teacher, TeacherData>();
        public static IDrivingPracticeRepo DrivingPracticeRepos()
           => createMockRepo<MockDrivingPracticeRepo, DrivingPractice, DrivingPracticeData>();
        public static IRegisterDrivingPracticeRepo RegisterDrivingPracticeRepos()
           => createMockRepo<MockRegisterDrivingPracticeRepo, RegisterDrivingPractice, RegisterDrivingPracticeData>();
        public static ICourseTypeRepo CourseTypeRepos()
           => createMockRepo<MockCourseTypeRepo, CourseType, CourseTypeData>();
        public static ICourseTypeRepo CourseTypeRepos(string id, out CourseTypeData data)
       => createMockRepo<MockCourseTypeRepo, CourseType, CourseTypeData>(
               id, d => new CourseType(d), out data);
        public static IExamTypeRepo ExamTypeRepos(string id, out ExamTypeData data)
      => createMockRepo<MockExamTypeRepo, ExamType, ExamTypeData>(
              id, d => new ExamType(d), out data);
        public static IExamRepo ExamRepos(string id, out ExamData data)
    => createMockRepo<MockExamRepo, Exam, ExamData>(
            id, d => new Exam(d), out data);
        public static ITeacherRepo TeacherRepos(string id, out TeacherData data)
     => createMockRepo<MockTeacherRepo, Teacher, TeacherData>(
             id, d => new Teacher(d), out data);
        public static IRegisterCourseRepo RegisterCourseRepos(string id, out RegisterCourseData data)
    => createMockRepo<MockRegisterCourseRepo, RegisterCourse, RegisterCourseData>(
            id, d => new RegisterCourse(d), out data);
        public static IDrivingPracticeRepo DrivingPracticeRepos(string id, out DrivingPracticeData data)
    => createMockRepo<MockDrivingPracticeRepo, DrivingPractice, DrivingPracticeData>(
            id, d => new DrivingPractice(d), out data);
    }
}