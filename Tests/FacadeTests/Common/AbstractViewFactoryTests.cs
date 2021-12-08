using Autokool.Data.DrivingSchool;
using Autokool.Domain.DrivingSchool.Model;
using Autokool.Facade.Common;
using Autokool.Facade.DrivingSchool.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autokool.Tests.FacadeTests.Common
{
    [TestClass]
    public class AbstractViewFactoryTests : AbstractTests<object>
    {
        private class testClass : AbstractViewFactory<CourseData, Course, CourseView>
        {
            protected override Course toObject(CourseData d) => new(d);
        }
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateObjectTest()
        {
            var v = random<CourseView>();
            var o = (obj as testClass).Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = random<CourseData>();
            var v = (obj as testClass).Create(new Course(d));
            areEqualProperties(d, v);
        }
        protected override object createObject() => new testClass();
    }
}
